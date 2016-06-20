using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkout;

namespace UnitTestCheckOut
{
    [TestClass]
    public class CheckOutTest   
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void BuyShopping()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("A");

            Assert.Equals(oCheckout.GetTotalPrice(), 0);
        }
    }
}
