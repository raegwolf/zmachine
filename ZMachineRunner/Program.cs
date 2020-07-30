using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachineRunner
{
    class Program
    {
        static void scanMemory()
        {
            var buffer = File.ReadAllBytes(@"d:\temp\zmachine\DOSBox.DMP");

            var search = new byte[] { 0x03, 0x00, 0x00, 0x58, 0x4e, 0x37, 0x4f };

            for (int i = 0; i < buffer.Length; i++)
            {
                var match = true;
                for (int j = 0; j < search.Length; j++)
                {
                    if (buffer[i + j] != search[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    Console.WriteLine("Found memory at " + i.ToString("X"));

                    var partialBuffer = new byte[92160];
                    for (int k = 0; k < partialBuffer.Length; k++)
                    {
                        partialBuffer[k] = buffer[i + k];
                    }

                    var path = @"d:\temp\zmachine\zork1-dosbox.bin";
                    if (File.Exists(path)) File.Delete(path);
                    File.WriteAllBytes(path, partialBuffer);

                }
            }

        }

        static void Main(string[] args)
        {
            //scanMemory();





            var machineBytes = File.ReadAllBytes(@"D:\data\src\ZMachine\ZMachine\data\zork1.dat");

            var stream = new ZMachine.V3.ZMemoryStream(machineBytes);

            var zmachine = new ZMachine.V3.ZMachine();
            zmachine.Load(stream);

            ////var path = @"D:\data\src\ZMachine\ZMachine\data\zork1-decoded.txt";
            ////if (File.Exists(path))
            ////{
            ////    File.Delete(path);
            ////}
            ////File.AppendAllText(path, zmachine.ToString());

            zmachine.Run();

        }
    }
}
