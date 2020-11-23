using Assignment.DiscountShop.Contracts;
using Assignment.DiscountShop.Models;
using Assignment.DiscountShop.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DiscountShop.DiscountShopService
{
    public class TaxCalculatorService : ITaxService
    {
        private ITaxCalculator _taxCalculator;
        private string _state;
        public TaxCalculatorService(string state="")
        {
            _state = state;
            _taxCalculator = null;
        }

        public TaxCalculatorService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }
        public void CalculateTax(ShoppingCart shoppingCart)
        {
            if (_taxCalculator == null)
            {
                //First set the _taxCalulator
                CreateTaxCalculator(_state);
            }
            
            _taxCalculator.CalculateTax(shoppingCart);
        }

        public void CreateTaxCalculator(string state = "")
        {
            _state = state;
            //This is mapper function, where you can create the actual Tax Class required for the specific State.
            //We can have a Tax Admin module which can map the concreate tax class with store and store it in a DB.
            //Here you can use Dictionaly and populate the mapping from DB.
            //Dictionary<String, ITaxCalculator> objTaxCalculatorRepo =
            //     new Dictionary<string, ITaxCalculator>();
            //objTaxCalculatorRepo.Add()

            //But for the current demo, I am just using If condition.
            if ( _state == "")
            {
                _taxCalculator = new BasicTaxCalculator();
            }
            if (_state == "FL" || _state == "NM" || _state == "NV" )
            {
                _taxCalculator = new PreDiscountTaxCalculator();
            }

            if (_state == "IO")  // Let's say Iowa has Item wise tax
            {
                _taxCalculator = new ItemWiseTaxCalculator();
            }
        }
    }
}
