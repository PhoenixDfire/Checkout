using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class SpecialOffer
    {
        public int NofItems { get; set; }
        public int offerprice { get; set; }

        public SpecialOffer(int ItemNumber, int PriceonOffer)
        {
            this.NofItems = ItemNumber;
            this.offerprice = PriceonOffer;
        }
    }
}
