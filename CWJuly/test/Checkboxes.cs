using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using CWJuly;

namespace CWJuly.test
{
    public class Checkbox
    {
      
        private IWebDriver _driver;
        private LoginPage loginPage;
        private AccountPage accountPage;
        private Javascripts javascripts;


      
        [SetUp]
        public void Setup()
        {

            _driver = new ChromeDriver(@"C:\Users\User\source\repos\CWJuly\driver");
            _driver.Url = "https://antonioltd.github.io/operateautomation/ ";
            _driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            loginPage = new LoginPage(_driver);
            accountPage = new AccountPage(_driver);
            javascripts = new Javascripts(_driver);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;

        }

        [Test]
        public void VerifyThatAllCheckoxesAreClicked()
        {
            loginPage.EnterUsername("admin")
                   .EnterPassword("admin")
                   .ClickOnSubmitBtn();
            accountPage.checkAllBoxes();
            Assert.NotNull(accountPage.checkAllBoxes());

        }
        [Test]
        public void VerifyTheFourthCheckBoxIsClicked()
        {
            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickOn4thCheckbox();
            Assert.NotNull(accountPage.clickOn4thCheckbox());

        }

        [TearDown]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        }
    }
}
