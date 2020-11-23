using System;
using System.Collections.Generic;
using System.Text;
using Assignment.DiscountShop.Contracts;
using Assignment.DiscountShop.Models;

namespace Assignment.DiscountShop.TaxCalculator
{
    //This is the most Basic Calculator, Just calculate the Flat % of total amount after discount.
    public class BasicTaxCalculator : ITaxCalculator
    {
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
