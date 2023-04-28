using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UmarRiaz_Qualitest.Source.Pages
{
     public class CartPage
     {
            private readonly IWebDriver driver;

            public CartPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public int GetNumberOfItemsInCart()
            {
                driver.Navigate().GoToUrl("https://cms.demo.katalon.com/cart/");
                return driver.FindElements(By.CssSelector(".cart_item")).Count;
            }
      }

    
}
