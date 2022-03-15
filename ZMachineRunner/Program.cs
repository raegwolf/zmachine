using System;
using System.IO;
using ZMachine.V3;
using ZMachine.V3.Objects;
using ZMachineRunner;

namespace ZMachineRunnerCore
{
    class Program
    {

        static void Main(string[] args)
        {
            var gameFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "game", "zork1.dat");
            if (!File.Exists(gameFilePath))
            {
                throw new FileNotFoundException();
            }

            var newGameMemory = File.ReadAllBytes(gameFilePath);

            // In stateless mode, the memory of the game (i.e. it's state) is emitted after each command
            // and then injected back in when the next command is received. This pattern is useful
            // if you want to build a version that allows users to play on a server without actually storing
            // anything server-side or keeping memory allocated when users may take a long time to make a next move.
            // In the default mode, the zmachine is spun up and interactively requests commands from the player
            var playStateless = true;

            // In walkthrough mode, game commands will be automatically executed to progress the game to completion
            var playWalkthrough = false;

            
            if (playStateless)
            {
                if (playWalkthrough)
                {
                    throw new Exception("Walkthrough mode isn't supported with stateless mode.");
                }

                PlayGameStateless(newGameMemory);
            }
            else
            {
                PlayGame(newGameMemory, playWalkthrough);
            }


        }

        static void PlayGame(byte[] newGameMemory, bool playWalkthrough)
        {
            var stream = new ZMemoryStream(newGameMemory);

            var zmachine = new ZMachine.V3.ZMachine();

            zmachine.Load(stream);

            zmachine.AssignIOCallbacks(
                (line) =>
                {
                    Console.Write(line);

                },
                () =>
                {
                    string command = "";

                    // in walkthough mode we are going to get the next command from the walkthrough
                    if (playWalkthrough)
                    {
                        command = Walkthrough.GetNextCommand();

                        if (!string.IsNullOrEmpty(command))
                        {
                            Console.WriteLine(command);
                        }
                    }
                    else
                    {
                        command = Console.ReadLine();
                    }

                    return command;
                },
                (min, max) =>
                {
                    var random = Walkthrough.GetNextRandomNumber();
                    if (random == 0)
                    {
                        random = 1;
                    }
                    else
                    {
                        Console.WriteLine("Random between " + min.ToString() + " and " + max.ToString() + ": returning " + random.ToString());
                    }

                    return random;
                }
            );

            zmachine.StartNewGame();
        }

        static void PlayGameStateless(byte[] newGameMemory)
        {
            var state = "";
            var command = "";

            while (true)
            {

                var response = "";

                var newState = PlayMoveStateless(newGameMemory, state, command, out response);


                Console.Write(response);

                command = Console.ReadLine();

                Console.WriteLine(command);
                state = newState;

            }
        }

        /// <summary>
        /// Plays a single move on the game, returns the new state and the text response that should be sent to the user
        /// </summary>
        /// <param name="newGameMemory"></param>
        /// <param name="state"></param>
        /// <param name="command"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        static string PlayMoveStateless(byte[] newGameMemory, string state, string command, out string response)
        {
            var zmachine = new ZMachine.V3.ZMachine();

            zmachine.Load(new ZMachine.V3.ZMemoryStream(newGameMemory));

            var cumulativeResponse = "";
            var newState = "";

            var hasSentCommand = (string.IsNullOrEmpty(command));

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
                        return command;
                    }
                    else
                    {
                        // get game state and terminate game by returning null
                        newState = zmachine.GetState();
                        return null;
                    }
                }
            );

            if (string.IsNullOrEmpty(state))
            {
                // start a new game
                zmachine.StartNewGame();
            }
            else
            {
                // resume a game
                zmachine.ResumeGame(state);
            }

            response = cumulativeResponse;
            return newState;
        }

    }
}
