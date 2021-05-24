# ShoppingBasket

### Clone or download the library and run tests.


#### CartService 
- There is main logic for adding products in the cart and getting Total price.

#### ICartService 
- Inteface for CartService.

#### DiscountStrategies Folder 
- Examples of discount logic. That can be used in CartService to count the Total price.

#### DiscountStrategy 
- Extending this class you can create customized discount logic for each Cart Item. That will be used in CartService to count the Total price.

#### Models
- There are Data Transfer Objects.


#### TESTS
- You can create your discount or use existing. Just create a new Cart Item. Add product, quantity, and discount. And simply add that item to the cart, and get the total price.
