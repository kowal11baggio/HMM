using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMM.Algorithm;

namespace HMM
{
    class ProgramRunClass
    {
        static void Main(string[] args)
        {
            var kernel = new Kernel();
            kernel.initialization();
        }
    }
}
