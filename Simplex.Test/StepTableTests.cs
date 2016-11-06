using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Simplex.Test
{
    [TestClass]
    public class StepTableTests
    {
        List<Simplex.StepTable> Tables = new List<Simplex.StepTable>
            (
            new[] 
            {
                new Simplex.StepTable
                (
                    mainCoefficient: new double[] { 2, 3, 0, 0 },
                    basisIndex: new int[] { 2, 3 },
                    freeMember: new double[] { 2, 4 },
                    restrictionCoefficient: new double[][] 
                    {
                        new double[] { 1, 1, 1, 0 },
                        new double[] { 1, -1, 0, 1 }
                    }
                ),
                new Simplex.StepTable
                (
                    mainCoefficient: new double[] { 2, 3, 0, 0 },
                    basisIndex: new int[] { 1, 3 },
                    freeMember: new double[] { 2, 6 },
                    restrictionCoefficient: new double[][]
                    {
                        new double[] { 1, 1, 1, 0 },
                        new double[] { 2, 0, 1, 1 }
                    }
                )
            }
            );
        [TestMethod]
        public void TestingFindValueMethod()
        {
            Assert.AreEqual(Tables[0].Value, 0);
            Assert.AreEqual(Tables[1].Value, 6);
        }
    }
}
