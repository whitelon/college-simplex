using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Simplex.Test
{
    [TestClass]
    public class SolutionTests
    {
        StepTable zeroTable1 = new Simplex.StepTable
                (
                    mainCoefficient: new double[] { 2, 3, 0, 0 },
                    basisIndex: new int[] { 2, 3 },
                    freeMember: new double[] { 2, 4 },
                    restrictionCoefficient: new double[][]
                    {
                        new double[] { 1, 1, 1, 0 },
                        new double[] { 1, -1, 0, 1 }
                    }
                );
        StepTable zeroTable2 = new StepTable
            (
                mainCoefficient: new double[] { -1, -1, -1, 0, 0, 0 },
                basisIndex: new int[] { 0, 1, 2 },
                freeMember: new double[] { 5, 3, 5 },
                restrictionCoefficient: new double[][]
                {
                    new double[] {1,0,0,-1,0,-2},
                    new double[] {0,1,0,2,3,1},
                    new double[] {0,0,1,2,-5,6}
                }
            );
        StepTable zeroTable3 = new StepTable(
            mainCoefficient: new double[] { 100, 17, 0, 0, 0, 0 },
            basisIndex: new int[] { 2, 3, 4, 5 },
            freeMember: new double[] { 20, 15, 25, 10 },
            restrictionCoefficient: new double[][]
            {
                new double[] {8, 11, 1, 0, 0, 0},
                new double[] {4, 0, 0, 1, 0, 0},
                new double[] {10, 12, 0, 0, 1, 0},
                new double[] {0, 5, 0, 0, 0, 1}
            });

        [TestMethod]
        public void SolutionTest()
        {
            var sol1 = new Simplex.Solution(zeroTable1);
            Assert.AreEqual(6, sol1.Value, 0.001);
            Assert.IsTrue(sol1.Unknowns.SequenceEqual(new double[] { 0, 2, 0, 6 }));

            var sol2 = new Simplex.Solution(zeroTable2);
            Assert.AreEqual(-7.1, sol2.Value, 0.001);
            Assert.IsTrue(sol2.Unknowns.SequenceEqual(new double[] { 7.1, 0, 0, 1.3, 0, 0.4 }));

            var sol3 = new Simplex.Solution(zeroTable3);
            Assert.AreEqual(250, sol3.Value, 0.001);
            Assert.IsTrue(sol3.Unknowns.SequenceEqual(new double[] { 2.5, 0, 0, 5, 0, 10 }));
        }
    }
}
