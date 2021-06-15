using flowgear.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3;

namespace ZMachineNode
{
    [Node("ZMachine", "ZMachine", NodeType.Connector, "zmachine.png", RunFrom.DropPointUnrestrictedOnly)]
    public class ZMachineNode
    {
        [Property(FlowDirection.Input, ExtendedType.MultilineText)]
        public string InitialMemory { get; set; }

        [Property(FlowDirection.Input, ExtendedType.MultilineText)]
        public string StateIn { get; set; }

        [Property(FlowDirection.Input, ExtendedType.None)]
        public string Command { get; set; }

        [Property(FlowDirection.Output, ExtendedType.MultilineText)]
        public string StateOut { get; set; }

        [Property(FlowDirection.Output, ExtendedType.MultilineText)]
        public string Response { get; set; }

     
        [Invoke]
        public InvokeResult Invoke()
        {
            var initialMemory = ZUtility.Decompress(System.Convert.FromBase64String(InitialMemory));

            var zmachine = new ZMachine.V3.ZMachine();

            zmachine.Load(new ZMachine.V3.ZMemoryStream(initialMemory));

            var cumulativeResponse = "";
            var newState = "";

            var hasSentCommand = (string.IsNullOrEmpty(Command));

            zmachine.AssignIOCallbacks(
                (line) =>
                {
                    // add the game's output to the output string
                    cumulativeResponse += line;
                },
                () =>
                {
                    if (!hasSentCommand)
                    {
                        // send the command
                        hasSentCommand = true;
                        return Command;
                    }
                    else
                    {
                        // get game state and terminate game by returning null
                        newState = zmachine.GetState();
                        return null;
                    }
                }
            );

            if (string.IsNullOrEmpty(StateIn))
            {
                // start a new game
                zmachine.StartNewGame();
            }
            else
            {
                // resume a game
                zmachine.ResumeGame(StateIn);
            }

            Response = cumulativeResponse;
            StateOut =  newState;

            return new InvokeResult();
        }

    }
}
