using Assignment.DiscountShop.Models;

namespace Assignment.DiscountShop.Contracts
{
    public interface ITaxService
    {
        void CreateTaxCalculator(string state = "");
        void CalculateTax(ShoppingCart shoppingCart);
    }
}
