using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LatticePathTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LatticePathTest()
        {
            var paths = LatticePaths.Program.GetPaths(2);
            Assert.AreEqual(6, paths);
        }
    }
}
