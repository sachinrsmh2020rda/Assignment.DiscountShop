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
        private int taxRate; //It is in %

        public BasicTaxCalculator()
        {
            taxRate = 10;
        }
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            decimal taxableAmount;

            taxableAmount = shoppingCart.TotalBillAmount - shoppingCart.TotalDiscountAmount;
            shoppingCart.TaxAmount = (taxableAmount * taxRate) / 100;
        }
    }
}
