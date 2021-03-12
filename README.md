# CheckoutOrderTotalKata
This project is an API for a mock grocery point of sales sytem. The API allows for items to be scanned, removed and for the total checkout price to be retrieved.

## Requirements
[.NET core 3.1.10](https://dotnet.microsoft.com/download)


## How to Use
To start the API navigate to the project directory (../CheckoutOrderKata/CheckoutOrderKata) and execute the commands `dotnet build` and `dotnet run`. Use the localhost url returned to the terminal as the base url for the API.



##### 4 commands for the CheckoutOrderKata

1. Getting products available (GET)

  `https://localhost:5001/api/product/GetProductsAvailable`

2. Creating the order item (POST)
  
  `https://localhost:5001/api/ordercheckout/CreateOrderItem`

3. Removing the order item (POST)

  `https://localhost:5001/api/ordercheckout/RemoveOrderItem`

4. Getting the checkout total (GET)

  `https://localhost:5001/api/ordercheckout/GetCheckoutTotal`

#### Detailed information on how to configure these api calls can be found at this link [Postman Documentation](https://documenter.getpostman.com/view/4352737/Tz5p6dS4)

The table below gives a summary of the item names that can be added and the attributes for those items. This information can also be gathered from using the get request 'api/ordercheckout/GetProductsAvailable'.    

Name | Weight | Markdown | Discounts | Discount Description
---- | ------ | ---- | ----------| --------------------
chips | :x: | :x: | :x: |
cookie | :x: | :heavy_check_mark: | :x: | 
soup | :x: | :heavy_check_mark: | :heavy_check_mark: | Buy 2 get 1 half off, limit 2
banana | :heavy_check_mark: | :x: | :x: |
ground beef | :heavy_check_mark: | :x: | :heavy_check_mark: | Buy 3 get 1 50% off, limit 2 
beer | :x: | :x: | :heavy_check_mark: | Buy 2 For $10, limit 2
