using Assignment.DiscountShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.TaxCalculator
{
    public class PreDiscountTaxCalculator : ITaxCalculator
    {
        private int taxRate; //It is in %

        public PreDiscountTaxCalculator()
        {
            taxRate = 10;
        }
        //This tax Calulator calculates the on full amount (Pre Discount amount).
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            //Here we are not considering Discount Amount
            shoppingCart.TaxAmount = (shoppingCart.TotalBillAmount * taxRate) / 100;
        }
    }
}
