using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using CWJuly;
using OpenQA.Selenium.Interactions;

namespace CWJuly.test
{
   
    public class Alert
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

        #region Alert

        [Test]
        public void VerifyAlertBtnIsWorking()
        {
            loginPage.EnterUsername("admin")
                .EnterPassword("admin")
                .ClickOnSubmitBtn();
            javascripts.clickAlertBtn();
            
            Assert.NotNull(javascripts.clickOnAlertOkBtn());
            
           
        }

        [Test]
        public void VerifyAlertPopupMessageIsDisplayed()
        {
            loginPage.EnterUsername("admin")
                .EnterPassword("admin")
                .ClickOnSubmitBtn();
            javascripts.clickAlertBtn();
            Assert.NotNull(javascripts.clickOnAlertOkBtn());
        }

        [Test]
        public void VerifyIfOkBtnInAlertPopupIsWorking()
        {
            loginPage.EnterUsername("admin")
                .EnterPassword("admin")
                .ClickOnSubmitBtn();
            javascripts.clickAlertBtn();
            javascripts.clickOnAlertOkBtn();
            Assert.NotNull(_driver.FindElement(By.XPath("//div[@class='jsAlertMsg']")));
        }

        [Test]
        public void VerifyDismissedAlertMessageIsDisplayed()
        {
            loginPage.EnterUsername("admin")
                .EnterPassword("admin")
                .ClickOnSubmitBtn();
            javascripts.clickAlertBtn();
            javascripts.clickOnAlertOkBtn();
            Assert.AreEqual(javascripts.DismissedMessage.Text, "Dismissed!");

        }

        #endregion

        #region Conrifmatiom

        [Test]
        public void VerifyConfirmBtnIsWorking()
        {
            loginPage.EnterUsername("admin") 
               .EnterPassword("admin")
               .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            Assert.NotNull(javascripts.clickConfirmationOkBtn());
        }

        [Test]
        public void VerifyConfirmPopupMessageIsDisplayed()
        {
            loginPage.EnterUsername("admin") 
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            Assert.NotNull(javascripts.clickConfirmationOkBtn());
          
        }

        [Test]
        public void VerifyIfOkBtnInConfirmPopupIsWorking()
        {
            loginPage.EnterUsername("admin")
               .EnterPassword("admin")
               .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            javascripts.clickConfirmationOkBtn();
            Assert.NotNull(_driver.FindElement(By.XPath("//div[@class='jsConfirmtMsg']")));

        }
           
        [Test]
        public void VerifyIfYouPressedOkMessageDisplayed()
        {
            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            javascripts.clickConfirmationOkBtn();
            Assert.AreEqual(javascripts.DisplayedMessage.Text, "You pressed OK!");

           
        }

        [Test]
        public void VerifyIfCancelBtnInConfirmPopupIsWorking()
        {
            loginPage.EnterUsername("admin")
               .EnterPassword("admin")
               .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            javascripts.clickCancelBtn();
            Assert.AreEqual(javascripts.DisplayedMessage.Text, "You pressed Cancel!");

        }

        [Test]
        public void VerifyIfYouPressedCancelMessageIsDisplayed()
        {
            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickConfirmationBtn();
            javascripts.clickCancelBtn();
            Assert.NotNull(javascripts.DisplayedMessage);

        }

        #endregion

        #region Prompt
        [Test]
        public void VerifyIfPromptBtnIsWorking()
        {
            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickPromptBtn();
            Assert.NotNull(javascripts.clickConfirmationOkBtn());

        }

        [Test]
        public void VerifyDisplayedMessageWhenNameEnteredInPromptPopup()
        {

            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickPromptBtn();
            javascripts.enterNameInPromptPopup();
            javascripts.clickPromptOkBtn();
            Assert.NotNull(javascripts.PromptMessage);

        }

        [Test]
        public void VerifyYouHaveEnteredNameMessageDisplayed()
        {

            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickPromptBtn();
            javascripts.enterNameInPromptPopup();
            javascripts.clickPromptOkBtn();
            Assert.AreEqual(javascripts.PromptMessage.Text, "Pareng GIAN! Kamusta?");
        }

        [Test]
        public void VerifyIfCancelBtnInPromptPopupIsWorking()
        {

            loginPage.EnterUsername("admin")
              .EnterPassword("admin")
              .ClickOnSubmitBtn();
            javascripts.clickPromptBtn();
            javascripts.enterNameInPromptPopup();
            javascripts.clickPromptCancelBtn();
            Assert.AreEqual(javascripts.PromptMessage.Text, "User cancelled the prompt.");
        }

        #endregion

        //  Assert.That(1 == 1, Is.EqualTo(true));
        // Assert.Equals(loginPage.validUsername.Text, "User cancelled the prompt");
        // Assert.NotNull(_driver.FindElement(By.XPath("//div[@class='jsPromptMsg']")));

        [TearDown]
          public void CleanUp()
          {
              Thread.Sleep(2000);
              _driver.Quit();
          }
    }
}
