using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
        public void TestingFindValue()
        {
            Assert.AreEqual(0, Tables[0].Value);
            Assert.AreEqual(6, Tables[1].Value);
        }

        [TestMethod]
        public void TestingCalculateDelta()
        {
            var d1 = new double[] { 2, 3, 0, 0 };
            var d2 = new double[] { -1, 0, -3, 0 };
            for (int i = 0; i < d1.Length; i++)
            {
                Assert.AreEqual(d1[i], Tables[0].Delta[i]);

                Assert.AreEqual(d2[i], Tables[1].Delta[i]);
            }
            
        }

        [TestMethod]
        public void TestingFinalTable()
        {
            Assert.AreEqual(false, Tables[0].FinalTable);
            Assert.AreEqual(true, Tables[1].FinalTable);
        }

        [TestMethod]
        public void TestingP()
        {
            Assert.AreEqual(1, Tables[0].P);
            Assert.AreEqual(-1, Tables[1].P);
        }
        [TestMethod]
        public void TestingCalculateTheta()
        {
            var d1 = new double[] { 2, -1 };
            for (int i = 0; i < d1.Length; i++)
            {
                Assert.AreEqual(d1[i], Tables[0].Theta[i]);
            }

            Assert.IsNull(Tables[1].Theta);
        }
        [TestMethod]
        public void TestingQ()
        {
            Assert.AreEqual(0, Tables[0].Q);
            Assert.AreEqual(-1, Tables[1].Q);
        }
    }
}
