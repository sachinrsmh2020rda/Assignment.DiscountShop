using Assignment.DiscountShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.TaxCalculator
{
    public class ItemWiseTaxCalculator : ITaxCalculator
    {
        private int taxRate; //It is in %

        public ItemWiseTaxCalculator()
        {
            taxRate = 10;
        }
        //This Tax Calculator calculates Tax for each individual item and add it to finale amount.
        //Tax may differ based on Item Type. i.e. Luxury Item may have double the tax rate as of basic Item.
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            decimal taxAmount = 0;
            //Here we can iterate each cart item and calculate tax based on item type and add them up.
            foreach(var item in shoppingCart.CartItems)
            {
                if (item.Key.Category == ProductCategory.Luxury)
                {
                    //Luxury Items have double the tax rate.
                    taxAmount += ((item.Key.CostPerUnit * item.Value) * (2 * taxRate)) / 100;
                }
                else
                {
                    taxAmount += ((item.Key.CostPerUnit * item.Value) * taxRate) / 100;
                }
            }
            shoppingCart.TaxAmount = taxAmount;
        }
    }
}
