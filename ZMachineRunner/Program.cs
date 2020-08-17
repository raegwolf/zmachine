using System;
using System.IO;

namespace ZMachineRunnerCore
{
    class Program
    {
        static void scanMemory()
        {
            var buffer = File.ReadAllBytes(@"d:\temp\zork\DOSBox-down.DMP");

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

                    var path = @"d:\temp\zork\dosbox-down.bin";
                    if (File.Exists(path)) File.Delete(path);
                    File.WriteAllBytes(path, partialBuffer);

                }
            }

        }

        static void Main(string[] args)
        {

            var machineBytes = File.ReadAllBytes(@"D:\data\src\ZMachine\data\zork1.dat");

            var stream = new ZMachine.V3.ZMemoryStream(machineBytes);
            stream.Watch = true;

            var zmachine = new ZMachine.V3.ZMachine();
            zmachine.Load(stream);

            zmachine.Run();

        }
    }
}
