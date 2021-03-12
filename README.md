# CheckoutOrderTotalKata
An API for a grocery point-of-sales system

## Requirements
.NET core 3.1.10

## Usage
To start the API navigate to the project directory (../CheckoutOrderKata/CheckoutOrderKata) and execute the following commands
* dotnet build
* dotnet run

Use the localhost url returned to the terminal as the base url for the api.Information on how to configure the api call can be found at this link [Postman Documentation](https://documenter.getpostman.com/view/4352737/Tz5p6dS4)

Name | Weight | Sale | Discounts | Discount Description
---- | ------ | ---- | ----------| --------------------
chips | :x: | :x: | :x: |
cookie | :x: | :heavy_check_mark: | :x: | 
soup | :x: | :heavy_check_mark: | :heavy_check_mark: | Buy 2 get 1 half off, limit 2
banana | :heavy_check_mark: | :x: | :x: |
ground beef | :heavy_check_mark: | :x: | :heavy_check_mark: | Buy 3 get 1 50% off, limit 2 
beer | :x: | :x: | :heavy_check_mark: | Buy 2 For $10, limit 2
