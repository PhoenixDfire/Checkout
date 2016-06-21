using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Product
    {
        public string Description { get; set; }
        public int Price { get; set; }
        public List<SpecialOffer> Offers { get; set; }

        public Product(string Desc, int Price, List<SpecialOffer> Off)
        {
            this.Description = Desc;
            this.Price = Price;
            this.Offers = Off;
        }
    }
}
