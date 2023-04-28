using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpecFlowProject1.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
        }

        public void AddRandomItemsToCart(int count)
        {
            var items = driver.FindElements(By.CssSelector(".woocommerce-loop-product__title"));

            for (int i = 0; i < count; i++)
            {
                int randomIndex = new Random().Next(items.Count);
                items[randomIndex].Click();

                var addToCartButton = driver.FindElement(By.CssSelector(".single_add_to_cart_button"));
                addToCartButton.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".woocommerce-message")));

                var continueShoppingLink = driver.FindElement(By.CssSelector(".woocommerce-message a"));
                continueShoppingLink.Click();

                items = driver.FindElements(By.CssSelector(".woocommerce-loop-product__title"));
            }
        }

        public int GetCartItemCount()
        {
            var cartIcon = driver.FindElement(By.CssSelector(".cart-contents"));
            return int.Parse(cartIcon.Text.Split(' ')[0]);
        }

        public void ViewCart()
        {
            var cartIcon = driver.FindElement(By.CssSelector(".cart-contents"));
            cartIcon.Click();
        }

        public void RemoveLowestPricedItemFromCart()
        {
            var cartRows = driver.FindElements(By.CssSelector(".cart_item"));

            int minPriceIndex = 0;
            decimal minPrice = decimal.MaxValue;

            for (int i = 0; i < cartRows.Count; i++)
            {
                var priceElement = cartRows[i].FindElement(By.CssSelector(".product-price"));
                decimal price = decimal.Parse(priceElement.Text.Substring(1));

                if (price < minPrice)
                {
                    minPrice = price;
                    minPriceIndex = i;
                }
            }

            var removeLink = cartRows[minPriceIndex].FindElement(By.CssSelector(".product-remove a"));
            removeLink.Click();
        }
    }
}
