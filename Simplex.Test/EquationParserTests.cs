using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplex;
using System.Linq;
namespace Simplex.Test
{
    [TestClass]
    public class EquationParserTests
    {
        [TestMethod]
        public void MainFuncTest()
        {
            Assert.IsTrue(EquatonParser.ParseMainFunction("2х1+3х2+0х3+0х4").SequenceEqual(new double[] { 2, 3, 0, 0 }));
            
        }

        [TestMethod]
        public void ParseRestrictionTest()
        {
            var tuple = EquatonParser.ParseRestriction("1x1 + 1x2 + 1x3 = 2", 4);
            Assert.AreEqual(2, tuple.Item2);
            Assert.IsTrue(tuple.Item1.SequenceEqual(new double[] { 1, 1, 1 , 0 }));

            var tuple2 = EquatonParser.ParseRestriction("5X2+1X6 = 10");
            Assert.AreEqual(10, tuple2.Item2);
            Assert.IsTrue(tuple2.Item1.SequenceEqual(new double[] { 0, 5, 0, 0, 0, 1 }));
        }
    }
}
