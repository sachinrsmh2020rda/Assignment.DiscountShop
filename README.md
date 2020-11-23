# Assignment.DiscountShop
Initial Check In
This is a Test Repo created for "RDA LAB" test

Few assumptions

1. Shopping Cart represnts an Order, it is a collection of Products and it's Qty. It has  Total Amount, Discount Amount and Tax Amountfiels as well.

2. Currently I am using KeyValuePair, it can be easily created a new Model. i.e CartItem.

2. Two types of discounts
   a. Single Item with N qty can have fixed amount deductions. ( 3 qty of product "A", $20 can be deducted right away. It can be linked with some Coupon code.)
   b. A combination of 2 or more items with distinct Qty can have fixed deduction. ( 2 qty of product "B" and 3 qyy of product "C", $15 can be deducted. )

3. Currently I am not using Date checks here, just using IsActive flag as we can have different module where Date validity can be put in DB and 
   based on that IsActive flag set using DB Job/ Middleware job.

4. Tax Calculation
   a. We have 3 different Tax classes. i.e. BasicTax, ItemWiseTax, PreDiscountTax.
   b. We have one TaxService where we can mapp these Tax Classe to one more states.

5. I have testing projects for ShoppingCart service and TaxService.
 
6. I have craeted a Utility Project as well, wher can put any utility classes. i.e. Logger, Printer etc.

Thanks
Sachin Kumar Sharma
8527137555
