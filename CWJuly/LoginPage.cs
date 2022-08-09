using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using CWJuly;
using CWJuly.test;
using OpenQA.Selenium.Interactions;

namespace CWJuly
{
     class LoginPage
     {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;

        }

        public IWebElement UsernameInput => _driver.FindElement(By.XPath("//input[@id='username']")); // usernameInput ,field box

        public IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@id='password']"));

        public IWebElement SubmitBtn => _driver.FindElement(By.XPath("//div[@id='login']"));

          
        public IWebElement ErrorMessage => _driver.FindElement(By.Id("general-error"));


        // public IWebElement errorMessages => _driver.FindElement(By.XPath("//div[contains(@id,'general')]"));



        public string GetGeneralErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var ErrorMessage = wait.Until(driver => _driver.FindElement(By.Id("general-error")));
            return ErrorMessage.Text;
        }

        public bool VerifyErrorMessage(string message)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var ErrorMessage = wait.Until(driver => _driver.FindElement(By.Id("general-error")));
            return ErrorMessage.Text == message;
        }

        public LoginPage EnterUsername(string name) //caps
        {
            UsernameInput.SendKeys(name);
            return new LoginPage(_driver);
        }

        public LoginPage EnterPassword(string pass)
        {
            PasswordInput.SendKeys(pass);
            return new LoginPage(_driver);
        }

        public LoginPage ClickOnSubmitBtn()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var SubmitBtn = wait.Until(driver=> _driver.FindElement(By.XPath("//div[@id='login']")));
                SubmitBtn.Click();
           // Thread.Sleep(3000);
            return new LoginPage(_driver);
        }

        public LoginPage EnterDetailsAgain()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var errorMessages = _driver.FindElements(By.XPath("//div[contains(@id,'general')]"));
            var randonUsername = $"{Guid.NewGuid()}";
            var randomPassword = $"{Guid.NewGuid()}";
            int numOfTry = 2;

           // Thread.Sleep(3000);
            foreach (var errorMessage in errorMessages)
            {
                if (errorMessage.Displayed)
                {
                     UsernameInput.Clear();
                     UsernameInput.SendKeys(randonUsername);
                     PasswordInput.Clear();
                     PasswordInput.SendKeys(randomPassword);
                    var SubmitBtn = wait.Until(driver => _driver.FindElement(By.XPath("//div[@id='login']")));
                    SubmitBtn.Click();

                }
                if (numOfTry == 2)
                {
                    UsernameInput.Clear();
                    UsernameInput.SendKeys("admin");
                    PasswordInput.Clear();
                    PasswordInput.SendKeys("admin");
                    var SubmitBtn = wait.Until(driver => _driver.FindElement(By.XPath("//div[@id='login']")));
                    SubmitBtn.Click();

                }
            }
            

            return new LoginPage(_driver);
        }




     }
}
