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
        public void BuyShoppingStandard()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("A");

            Assert.AreEqual(oCheckout.GetTotalPrice(), 50);
        }

        [TestMethod]
        public void BuyShoppingA()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("A");

            Assert.AreEqual(oCheckout.GetTotalPrice(), 50);
        }

        [TestMethod]
        public void BuyShoppingB()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("B");

            Assert.AreEqual(oCheckout.GetTotalPrice(), 30);
        }

        [TestMethod]
        public void BuyShoppingC()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("C");

            Assert.AreEqual(oCheckout.GetTotalPrice(), 20);
        }

        [TestMethod]
        public void BuyShoppingD()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("D");

            Assert.AreEqual(oCheckout.GetTotalPrice(), 15);
        }

        [TestMethod]
        public void BuyShoppingList()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("A");
            oCheckout.Scan("C");
            oCheckout.Scan("B");
            oCheckout.Scan("D");
            oCheckout.Scan("A");
         
            Assert.AreEqual(oCheckout.GetTotalPrice(), 165);
        }

        [TestMethod]
        public void BuyShoppingListWithSpecialOffer()
        {
            ICheckout oCheckout = new Checkout.Checkout();

            oCheckout.Scan("A");
            oCheckout.Scan("C");
            oCheckout.Scan("B");
            oCheckout.Scan("D");
            oCheckout.Scan("A");
            oCheckout.Scan("A"); // Three 'A' Mean Special Offer.

            Assert.AreEqual(oCheckout.GetTotalPrice(), 195);
        }
    }
}
