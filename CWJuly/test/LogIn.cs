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
   
     class LogIn 
    {
       
        private IWebDriver _driver;
        private LoginPage loginPage;
        private AccountPage accountPage;
        private Javascripts javascripts;
        private KeyboardCmds keyboardCmds;

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
            keyboardCmds = new KeyboardCmds(_driver);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;

        }

        [Test]
        public void ErrorMessageDisplayedWhenLoginUsingEmptyFields()
        {
            loginPage.ClickOnSubmitBtn();
           Assert.NotNull(_driver.FindElements(By.XPath("//div[@id='warning-count-message']")));
          
        }
        [Test]
        public void WelcomeMessageDisplayedWhenSuccessfulLogin()
        {
            loginPage.EnterUsername("admin")
                     .EnterPassword("admin")
                     .ClickOnSubmitBtn();
           // Assert.NotNull(_driver.Url = "https://antonioltd.github.io/operateautomation/practice.html");
            Assert.AreEqual(accountPage.HomeGreeting.Text, "Mabuhay!");
            
        }

        [Test]
        public void ErrorMessageDisplayedWhenUsernameIsValidAndPassworIsInvalid()
        {
            loginPage.EnterUsername("admin")
                     .EnterPassword("mind")
                     .ClickOnSubmitBtn();
            Assert.IsTrue(loginPage.VerifyErrorMessage("Login details not found!"));
              
        }

        public void ErrorMessageDisplayedAfterSecondAttemptOfInvalidLoginInput()
        {
            loginPage.EnterUsername("admin")
                    .EnterPassword("mind")
                    .ClickOnSubmitBtn();
            Assert.NotNull(loginPage.GetGeneralErrorMessage());

        }

       

        [Test]
        public void VerifySuccessfulLoginInThirdAttempts() //-?
        {
            loginPage.EnterUsername("admin")
                     .EnterPassword("adm")
                     .ClickOnSubmitBtn()
                     .EnterDetailsAgain();
           Assert.NotNull(_driver.Url = "https://antonioltd.github.io/operateautomation/practice.html");

        }

        
        [Test]
        public void VerifyIfEnterKeyOfTheKeyboardIsWorkingWhenLogingIn()
        {
            loginPage.EnterUsername("admin")
                     .EnterPassword("admin");
            keyboardCmds.usingEnterKeyInKeyboard();
           Assert.NotNull(_driver.Url = "https://antonioltd.github.io/operateautomation/practice.html");

        }

        
        [TearDown]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        } 
    }
}
