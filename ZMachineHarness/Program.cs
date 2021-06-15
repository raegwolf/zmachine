using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachineHarness
{
    class Program
    {
        
       

        static void Main(string[] args)
        {
            // get empty game state
            //var initialMemory = File.ReadAllBytes(@"D:\data\src\ZMachine\data\zork1.dat");

            //var compressedB64 = System.Convert.ToBase64String(ZMachineNode.ZMachineNode.Compress(initialMemory),Base64FormattingOptions.InsertLineBreaks);
            //var path = @"D:\data\src\ZMachine\data\zork1.base64.txt";
            //if (File.Exists(path)) File.Delete(path);
            //File.WriteAllText(path, compressedB64);


            Flowgear.Nodes.TestHarness.NodesTestHarness.AttachNode(typeof(ZMachineNode.ZMachineNode));

            Console.ReadKey();

        }
    }
}
