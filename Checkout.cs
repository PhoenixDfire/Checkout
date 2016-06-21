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
            new Product("C", 20, new List<SpecialOffer>()),
            new Product("D", 15, new List<SpecialOffer>())
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
            int[] itemCount = new int[StockList.Count];
 
            // Get the Number of Products
            foreach (string sProduct in ScannedProducts)
            {
                switch (sProduct)
                {
                    case "A":
                        itemCount[0] += 1;
                        break;
                    case "B":
                        itemCount[1] += 1;
                        break;
                    case "C":
                        itemCount[2] += 1;
                        break;
                    case "D":
                        itemCount[3] += 1;
                        break;
                }
            }
            runningtotal += CalculatePrice("A", itemCount[0]);
            runningtotal += CalculatePrice("B", itemCount[1]);
            runningtotal += CalculatePrice("C", itemCount[2]);
            runningtotal += CalculatePrice("D", itemCount[3]);

            return runningtotal;
        }

        private int FindPrice(string ProdDesc)
        {
            return StockList.Find(a => a.Description.Equals(ProdDesc)).Price;
        }

        private int CalculatePrice(string ProdDesc, int ItemCount)
        {
            int ProductTotal = 0;
            Product oProduct = StockList.Find(a => a.Description.Equals(ProdDesc));

            if (oProduct.Offers.Count > 0)
            {
                int iscore = ItemCount / oProduct.Offers[0].NofItems;
                if (iscore > 0)
                {
                    ProductTotal += iscore * oProduct.Offers[0].offerprice;
                }

                //Process the remainder 
                iscore = ItemCount % oProduct.Offers[0].NofItems;
                if (iscore > 0) 
                {
                    ProductTotal += (iscore * oProduct.Price);
                }
            }
            else
            {
                ProductTotal += (ItemCount * oProduct.Price);
            }
            
            return ProductTotal;
        }
    }
}
