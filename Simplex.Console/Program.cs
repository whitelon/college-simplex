using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex;

namespace Simplex.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution(
                   mainCoefficient: new double[] { -1, -1, -1, 0, 0, 0 },
                basisIndex: new int[] { 0, 1, 2 },
                freeMember: new double[] { 5, 3, 5 },
                restrictionCoefficient: new double[][]
                {
                    new double[] {1,0,0,-1,0,-2},
                    new double[] {0,1,0,2,3,1},
                    new double[] {0,0,1,2,-5,6}
                });
        }
    }
}
