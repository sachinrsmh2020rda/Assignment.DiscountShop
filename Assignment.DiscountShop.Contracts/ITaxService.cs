using Assignment.DiscountShop.Models;

namespace Assignment.DiscountShop.Contracts
{
    interface ITaxService
    {
        void CalculateTax(ShoppingCart shoppingCart);
    }
}
