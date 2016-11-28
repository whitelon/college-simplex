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
            Assert.IsTrue(EquatonParser.ParseMainFunction("-20x1 - 10x2 + 123x3").SequenceEqual(new double[] { -20, -10, +123 }));


            var tuple = EquatonParser.ParseRestriction("-20x1 - 10x2 + 12,3x3 = 100");
            Assert.AreEqual(100, tuple.Item2);
            Assert.IsTrue(tuple.Item1.SequenceEqual(new double[] { -20, -10, +12.3 }));
        }
    }
}
