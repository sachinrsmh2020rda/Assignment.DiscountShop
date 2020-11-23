using Assignment.DiscountShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.TaxCalculator
{
    public interface ITaxCalculator
    {
        public void CalculateTax(ShoppingCart shoppingCart);
    }
}
