using Assignment.DiscountShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.TaxCalculator
{
    public class ItemWiseTaxCalculator : ITaxCalculator
    {
        //This Tax Calculator calculates Tax for each individual item and add it to finale amount.
        //Tax may differ based on Item Type. i.e. Luxury Item may have double the tax rate as of basic Item.
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
