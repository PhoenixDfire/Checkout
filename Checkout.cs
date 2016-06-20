using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    /*
     * Implement the code for a checkout system that handles pricing schemes such as "pineapples cost 50,
     * three pineapples cost 130."

    Implement the code for a supermarket checkout that calculates the total price of a number of items. 
     * In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our store, we’ll use individual 
     * letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multi-priced: buy n of them, 
     * and they’ll cost you y pence. For example, item A might cost 50 individually, but this week we have a special offer: 
     * buy three As and they’ll cost you 130. In fact the prices are:

    SKU	Unit Price	Special Price
    A	50	3 for 130
    B	30	2 for 45
    C	20	
    D	15	
T
     * The checkout accepts items in any order, so that if we scan a B, an A, and another B, 
     * we’ll recognize the two Bs and price them at 45 (for a total price so far of 95). 
     * The pricing changes frequently, so pricing should be independent of the checkout.
     */
    
    public class Checkout : ICheckout
    {
        private static List<Product> StockList = new List<Product>{
            new Product("A", 50, new List<SpecialOffer>{new SpecialOffer(3, 130)}),
            new Product("B", 30, new List<SpecialOffer>{new SpecialOffer(2, 45)}),
            new Product("C", 20, null),
            new Product("D", 15, null)
        };

        private List<string> ScannedProducts = new List<string>();

        public void Scan(String item)
        {
            //throw new System.NotImplementedEception();
            ScannedProducts.Add(item);
        }

        public int GetTotalPrice()
        {
            int runningtotal = 0;

            foreach (string sProduct in ScannedProducts)
            {
                runningtotal += FindPrice(sProduct);
            }

            return runningtotal;
        }

        private int FindPrice(string ProdDesc)
        {
            return StockList.Find(a => a.Description.Equals(ProdDesc)).Price;
        }
    }
}
