using Assignment.DiscountShop.Models;

namespace Assignment.DiscountShop.Contracts
{
    public interface ITaxService
    {
        ITaxService CreateTaxCalculator(string state = "");
        void CalculateTax(ShoppingCart shoppingCart);
    }
}
