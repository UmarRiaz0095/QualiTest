using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Pages;
using Xunit;

namespace PageObjectModel.Steps
{
    [Binding]
    public class AddToCartSteps
    {
        private IWebDriver driver;
        private HomePage homePage;
        private CartPage cartPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            cartPage = new CartPage(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            homePage.Navigate();
        }

        [When(@"I add four random items to my cart")]
        public void WhenIAddFourRandomItemsToMyCart()
        {
            homePage.AddRandomItemsToCart(4);
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            homePage.ViewCart();
        }

        [Then(@"I find four items listed in my cart")]
        public void ThenIFindFourItemsListedInMyCart()
        {
            Assert.Equal(4, cartPage.GetNumberOfItems());
        }

        [When(@"I search for the lowest price item")]
        public void WhenISearchForTheLowestPriceItem()
        {
            cartPage.RemoveLowestPriceItem();
        }

        [Then(@"I find three items listed in my cart")]
        public void ThenIFindThreeItemsListedInMyCart()
        {
            Assert.Equal(3, cartPage.GetNumberOfItems());
        }
    }
}
