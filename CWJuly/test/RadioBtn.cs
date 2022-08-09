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
   
    public class Buttons
    {
        
        private IWebDriver _driver;
        private LoginPage loginPage;
        private AccountPage accountPage;
        private Javascripts javascripts;
        private Buttons buttons;

        //assert with attributes nunits

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
        public void VerifyIfRadioBtn3IsClicked()
        {
            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickOnRadio3();
            Assert.AreNotEqual(accountPage.radio3, accountPage.radioChecked);
             
        }


        [Test]
        public void VerifyIfRadioBtn2IsClicked()
        {
            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickOnRadio2();
            
            Assert.AreNotEqual(accountPage.radio2, accountPage.radioChecked);

        }
       
        [Test]
        public void VerifyIfRadioBtn5IsClicked()
        {
            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickOnRadio5();
            Assert.AreNotEqual(accountPage.radio5 , accountPage.radioChecked);

        }

        [Test]
        public void VerifyRadioBtn1IsClicked()
        {

            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickOnRadio1();
            Assert.AreEqual(accountPage.radio1, accountPage.radioChecked);
        }


        [Test]
        public void VerifyTheRadioBtnAreClickedFromFirstToFifth ()
        {
            loginPage.EnterUsername("admin")
                  .EnterPassword("admin")
                  .ClickOnSubmitBtn();
            accountPage.clickEachRadioBtns();
            Assert.AreNotEqual(accountPage.clickOnRadio5(), accountPage.clickOnRadio4());
        }


       [TearDown]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        } 
    }
}
