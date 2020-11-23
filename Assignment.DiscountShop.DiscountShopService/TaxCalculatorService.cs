using Assignment.DiscountShop.Contracts;
using Assignment.DiscountShop.Models;
using Assignment.DiscountShop.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.DiscountShopService
{
    class TaxCalculatorService : ITaxService
    {
        private ITaxCalculator _taxCalculator;

        private TaxCalculatorService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            _taxCalculator.CalculateTax(shoppingCart);
        }

        public ITaxService CreateTaxCalculator(string state = "")
        {
            //This is mapper function, where you can create the actual Tax Class required for the specific State.
            
            ITaxService serviceObject;

            //We can have a Tax Admin module which can map the concreate tax class with store and store it in a DB.
            //Here you can use Dictionaly and populate the mapping from DB.
            //Dictionary<String, ITaxCalculator> objTaxCalculatorRepo =
            //     new Dictionary<string, ITaxCalculator>();
            //objTaxCalculatorRepo.Add()

            //But for the current demo, I am just using If condition.
            if ( state == "")
            {
                serviceObject = new TaxCalculatorService(new BasicTaxCalculator());
            }
            if (state == "FL" || state == "NM" || state == "NV" )
            {
                serviceObject = new TaxCalculatorService(new PreDiscountTaxCalculator());
            }

            if (state == "IO")  // Let's say Iowa has Item wise tax
            {
                serviceObject = new TaxCalculatorService(new ItemWiseTaxCalculator());
            }

            throw new NotImplementedException();
        }
    }
}
