﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VgcApisTests.IPlugableTests
{
    [TestClass]
    public class IPlugableTests
    {
        public IPlugableTests() { }

        [TestMethod]
        public void NormalTest()
        {
            var container = new Container();
            var compLv1 = new CompLv1();
            var compLv2 = new CompLv2();

            container.Plug(container, compLv1);
            compLv1.Plug(compLv1, compLv2);

            var nc = container.Name();
            var n1 = container.GetComponent<CompLv1>().Name();
            var n2 = container.GetComponent<CompLv1>().GetComponent<CompLv2>().Name();

            var c2 = compLv2.Name();
            var c1 = compLv2.GetContainer().Name();
            var cc = compLv2.GetContainer().GetContainer().Name();

            Assert.AreEqual(nc, cc);
            Assert.AreEqual(n2, c2);
            Assert.AreEqual(n1, c1);

            Assert.AreEqual(null, container.GetContainer());

            container.Dispose();

        }
    }
}
