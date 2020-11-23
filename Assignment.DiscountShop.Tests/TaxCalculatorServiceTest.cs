using System.Collections.Generic;
using Assignment.DiscountShop.Contracts;
using Assignment.DiscountShop.DiscountShopService;
using Assignment.DiscountShop.Models;
using NUnit.Framework;

namespace Assignment.DiscountShop.Tests
{
    class TaxCalculatorServiceTest
    {
        [Test]
        public void ComputeTaxForBasicTaxCalulatorWithNoDiscount()
        {
            IDiscountService discountService = new DiscountService();
            ITaxService taxService = new TaxCalculatorService();
            IShoppingCartService scs = new ShoppingCartService(discountService);
            var cs = new CustomerService(scs);
            var custId = cs.CreateCustomer("John Doe");
            var shoppingCart = cs.CreateShoppingCart(custId);


            var ps = new ProductService();
            var pA = ps.CreateProduct("A", "product A", 50, ProductCategory.Basic);
            var pB = ps.CreateProduct("B", "product B", 30, ProductCategory.Luxury);
            var pC = ps.CreateProduct("C", "product C", 20, ProductCategory.Luxury);

            var discountA = discountService.CreateDiscount("Discount on A", "Discount if Purchase 3 As");
            var pAs = new KeyValuePair<Product, int>(pA, 3);
            var discountCombinationAs = new List<KeyValuePair<Product, int>>();
            discountCombinationAs.Add(pAs);
            var dci = new DiscountCombinationItems(discountCombinationAs,
                20, 0);

            discountService.CreateDiscountCombinationItems(discountA.Id, dci);

            scs.AddItem(shoppingCart, pA, 1);
            scs.AddItem(shoppingCart, pB, 1);
            scs.AddItem(shoppingCart, pC, 1);

            shoppingCart = scs.ComputeBill(shoppingCart);
            taxService.CalculateTax(shoppingCart);
            //There is no discount applicable for this card, cart value is 100, Basic Tax is 10.
            Assert.AreEqual(10, shoppingCart.TaxAmount);
        }

        [Test]
        public void ComputeTaxForBasicTaxCalulatorWithDiscount()
        {
            IDiscountService discountService = new DiscountService();
            ITaxService taxService = new TaxCalculatorService();
            IShoppingCartService scs = new ShoppingCartService(discountService);
            var cs = new CustomerService(scs);
            var custId = cs.CreateCustomer("Sachin Sharma");
            var shoppingCart = cs.CreateShoppingCart(custId);


            var ps = new ProductService();
            var pA = ps.CreateProduct("A", "product A", 50, ProductCategory.Basic);
            var pB = ps.CreateProduct("B", "product B", 30, ProductCategory.Luxury);
            var pC = ps.CreateProduct("C", "product C", 20, ProductCategory.Luxury);
            var pD = ps.CreateProduct("D", "product D", 15, ProductCategory.Premium);

            var discountA = discountService.CreateDiscount("Discount on A", "Discount if Purchase 3 As");
            var pAs = new KeyValuePair<Product, int>(pA, 3);
            var discountCombinationAs = new List<KeyValuePair<Product, int>>();
            discountCombinationAs.Add(pAs);
            var dci = new DiscountCombinationItems(discountCombinationAs,
                20, 0);

            discountService.CreateDiscountCombinationItems(discountA.Id, dci);

            //Discount B
            var discountB = discountService.CreateDiscount("Discount on B", "Discount if Purchase 2 Bs");
            var pBs = new KeyValuePair<Product, int>(pB, 2);
            var discountCombinationBs = new List<KeyValuePair<Product, int>>();
            discountCombinationBs.Add(pBs);
            var dc2 = new DiscountCombinationItems(discountCombinationBs,
                15, 0);

            discountService.CreateDiscountCombinationItems(discountB.Id, dc2);

            scs.AddItem(shoppingCart, pA, 5);
            scs.AddItem(shoppingCart, pB, 5);
            scs.AddItem(shoppingCart, pC, 1);

            shoppingCart = scs.ComputeBill(shoppingCart);

            taxService.CalculateTax(shoppingCart);
            //There is $50 discount applicable for this cart, cart value is 420 (370 after discount ), Basic Tax is 37.
            Assert.AreEqual(37, shoppingCart.TaxAmount);
        }

        [Test]
        public void ComputeTaxForPreDiscountTaxCalulator()
        {
            IDiscountService discountService = new DiscountService();
            //FL uses PreDiscount Tax Method
            ITaxService taxService = new TaxCalculatorService("FL");
            IShoppingCartService scs = new ShoppingCartService(discountService);
            var cs = new CustomerService(scs);
            var custId = cs.CreateCustomer("Sachin Sharma");
            var shoppingCart = cs.CreateShoppingCart(custId);


            var ps = new ProductService();
            var pA = ps.CreateProduct("A", "product A", 50, ProductCategory.Basic);
            var pB = ps.CreateProduct("B", "product B", 30, ProductCategory.Luxury);
            var pC = ps.CreateProduct("C", "product C", 20, ProductCategory.Luxury);
            var pD = ps.CreateProduct("D", "product D", 15, ProductCategory.Premium);

            var discountA = discountService.CreateDiscount("Discount on A", "Discount if Purchase 3 As");
            var pAs = new KeyValuePair<Product, int>(pA, 3);
            var discountCombinationAs = new List<KeyValuePair<Product, int>>();
            discountCombinationAs.Add(pAs);
            var dci = new DiscountCombinationItems(discountCombinationAs,
                20, 0);

            discountService.CreateDiscountCombinationItems(discountA.Id, dci);

            //Discount B
            var discountB = discountService.CreateDiscount("Discount on B", "Discount if Purchase 2 Bs");
            var pBs = new KeyValuePair<Product, int>(pB, 2);
            var discountCombinationBs = new List<KeyValuePair<Product, int>>();
            discountCombinationBs.Add(pBs);
            var dc2 = new DiscountCombinationItems(discountCombinationBs,
                15, 0);

            discountService.CreateDiscountCombinationItems(discountB.Id, dc2);

            scs.AddItem(shoppingCart, pA, 5);
            scs.AddItem(shoppingCart, pB, 5);
            scs.AddItem(shoppingCart, pC, 1);

            shoppingCart = scs.ComputeBill(shoppingCart);

            taxService.CalculateTax(shoppingCart);
            //There is $50 discount applicable for this cart, cart value is 420 (370 after discount ).
            //Pre Discount Tax is 42.
            Assert.AreEqual(42, shoppingCart.TaxAmount);
        }

        [Test]
        public void ComputeTaxForItemWiseTaxCalulator()
        {
            IDiscountService discountService = new DiscountService();
            ITaxService taxService = new TaxCalculatorService("IO");
            IShoppingCartService scs = new ShoppingCartService(discountService);
            var cs = new CustomerService(scs);
            var custId = cs.CreateCustomer("Paniraj N");
            var shoppingCart = cs.CreateShoppingCart(custId);


            var ps = new ProductService();
            var pA = ps.CreateProduct("A", "product A", 50, ProductCategory.Basic);
            var pB = ps.CreateProduct("B", "product B", 30, ProductCategory.Luxury);
            var pC = ps.CreateProduct("C", "product C", 20, ProductCategory.Luxury);

            var discountA = discountService.CreateDiscount("Discount on A", "Discount if Purchase 3 As");
            var pAs = new KeyValuePair<Product, int>(pA, 3);
            var discountCombinationAs = new List<KeyValuePair<Product, int>>();
            discountCombinationAs.Add(pAs);
            var dci = new DiscountCombinationItems(discountCombinationAs,
                20, 0);

            discountService.CreateDiscountCombinationItems(discountA.Id, dci);

            scs.AddItem(shoppingCart, pA, 1);
            scs.AddItem(shoppingCart, pB, 1);
            scs.AddItem(shoppingCart, pC, 1);

            shoppingCart = scs.ComputeBill(shoppingCart);
            taxService.CalculateTax(shoppingCart);
            //There is no discount applicable for this card, cart value is 100, Basic Tax is 10.
            Assert.AreEqual(15, shoppingCart.TaxAmount);
        }
    }
}
