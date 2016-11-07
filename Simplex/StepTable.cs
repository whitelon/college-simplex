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

        public int UnknownQuantity {
            get
            {
                return MainCoefficient.Length;
            }
        }
        public int RestrictionQuantity {
            get
            {
                return BasisIndex.Length;
            }
        }

        public double[] MainCoefficient { get; set; }
        public double[] FreeMember { get; set; }
        public int[] BasisIndex { get; set; }
        public double[][] RestrictionCoefficient { get; set; }

        public double Value { get; private set; }

        public double[] Delta { get; set; }
        public double[] Theta { get; set; }

        public bool FinalTable { get; private set; } = false;


        public StepTable(double[] mainCoefficient, int[] basisIndex, double[] freeMember, double[][] restrictionCoefficient)
        {
            MainCoefficient = mainCoefficient;
            BasisIndex = basisIndex;
            FreeMember = freeMember;
            RestrictionCoefficient = restrictionCoefficient;
            Value = FindValue();
            Delta = CalculateDelta();
            FinalTable = Delta.All((e) => e <= 0);
        }

        private double FindValue()
        {
            return FreeMember
                .Select((e, i) =>  e * MainCoefficient[BasisIndex[i]])
                .Aggregate((f, s) => f + s);
        }
        private double[] CalculateDelta()
        {
            return MainCoefficient.Select
                (
                    (c, j) =>
                    {
                        var sum = c;
                        for (int i = 0; i < RestrictionQuantity; i++)
                            sum -= RestrictionCoefficient[i][j] * MainCoefficient[BasisIndex[i]];
                        return sum;
                    }
                ).ToArray();
        }

        
    }
}
