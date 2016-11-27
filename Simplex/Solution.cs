using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    class Solution
    {
        public List<StepTable> Steps { get; private set; } = new List<Simplex.StepTable>();
        public FunctionType Type { get; private set; }
        public double Value { get; private set; }
        public double[] Unknowns { get; private set; }


        public Solution(double[] mainCoefficient, int[] basisIndex, double[] freeMember, double[][] restrictionCoefficient)
            : this(new StepTable(mainCoefficient, basisIndex, freeMember, restrictionCoefficient))
        {

        }

        public Solution(StepTable zeroTable)
        {
            Steps.Add(zeroTable);
            while (!Steps.Last().FinalTable) Steps.Add(NextTable(Steps.Last()));
        }

        private StepTable NextTable(StepTable oldTable)
        {
            var n = oldTable.UnknownQuantity;
            var m = oldTable.RestrictionQuantity;
            var q = oldTable.Q;
            var p = oldTable.P;
            var mainElement = oldTable.RestrictionCoefficient[q][p];

            //copying values
            var c = new double[n];
            oldTable.MainCoefficient.CopyTo(c, 0);
            var basis = new int[m];
            oldTable.BasisIndex.CopyTo(basis, 0);
            var b = new double[m];
            oldTable.FreeMember.CopyTo(basis, 0);
            var a = new double[m][];
            var i = 0;
            foreach (var row in oldTable.RestrictionCoefficient) row.CopyTo(a[i++] = new double[n], 0);

            //changing values
            basis[q] = p;
            a[q] = a[q].Select(e => e / mainElement).ToArray();
            b[q] = oldTable.FreeMember[q] / mainElement;

            return new StepTable(c, basis, b, a);
        }
    }
}

