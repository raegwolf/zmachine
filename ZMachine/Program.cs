using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine
{
    class Program

    {
        static void Main(string[] args)
        {

            var machineBytes = File.ReadAllBytes(@"D:\data\src\ZMachine\ZMachine\data\zork1.dat");

            var stream = new MemoryStream(machineBytes);

            var p = new Parser(stream);

        }
    }

}
