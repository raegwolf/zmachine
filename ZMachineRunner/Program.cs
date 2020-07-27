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
        static void Main(string[] args)
        {
            var machineBytes = File.ReadAllBytes(@"D:\data\src\ZMachine\ZMachine\data\zork1.dat");

            var stream = new MemoryStream(machineBytes);

            var zmachine = new ZMachine.V3.ZMachine();
            zmachine.Load(stream);

            var path = @"D:\data\src\ZMachine\ZMachine\data\zork1-decoded.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.AppendAllText(path, zmachine.ToString());

            zmachine.Run();

        }
    }
}
