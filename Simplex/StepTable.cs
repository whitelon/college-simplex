using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex
{
    public enum FunctionType
    {
        Maximum, Minimum
    }

    public class StepTable
    {
        public int Index { get; set; }

        public int UnknownQuantity { get; set; }
        public int RestrictionQuantity { get; set; }

        public double[] MainCoefficient { get; set; }
        public double[] FreeMember { get; set; }
        public double[] BasisIndex { get; set; }
        public double[][] RestrictionCoefficient { get; set; }

        public double Value { get; set; }

        public double[] Delta { get; set; }
        public double[] Theta { get; set; }
    }
}
