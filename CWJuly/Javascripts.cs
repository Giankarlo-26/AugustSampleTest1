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

namespace CWJuly
{
    class Javascripts : KeyboardCmds
    {
        private IWebDriver _driver;

        public Javascripts(IWebDriver driver) :base(driver)
        {
            _driver = driver;
        }

        public IWebElement alertBtn => _driver.FindElement(By.XPath("//button[@class='ui button'][1]"));

        public IWebElement confirmationBtn => _driver.FindElement(By.XPath("//button[@tabindex='1']"));

        public IWebElement promptBtn => _driver.FindElement(By.XPath("//button[@tabindex='2']"));

        public IWebElement DismissedMessage => _driver.FindElement(By.XPath("//div[@class='jsAlertMsg']"));

        public IWebElement DisplayedMessage => _driver.FindElement(By.XPath("//div[@class='jsConfirmtMsg']"));

        public IWebElement PromptMessage => _driver.FindElement(By.XPath("//div[@class='jsPromptMsg']"));

       


        public Javascripts clickAlertBtn()
        {
          
            alertBtn.Click();
             //wait
           

            return new Javascripts(_driver);
        }

        public Javascripts clickOnAlertOkBtn()
        {
            IAlert simpleAlert = _driver.SwitchTo().Alert();
            simpleAlert.Accept();

            return new Javascripts(_driver);
        }

      
        public Javascripts clickConfirmationBtn()
        {

            confirmationBtn.Click();
            Thread.Sleep(2000);
          

            return new Javascripts(_driver);
        }

        public Javascripts clickConfirmationOkBtn()
        {
            IAlert confirmationAlert = _driver.SwitchTo().Alert();
            confirmationAlert.Accept();
            return new Javascripts(_driver);
        }

        public Javascripts clickCancelBtn()
        {
            IAlert cancelBtn = _driver.SwitchTo().Alert();
            cancelBtn.Dismiss();
            return new Javascripts(_driver);
        }

        public Javascripts  clickPromptBtn()
        {
            promptBtn.Click();
            Thread.Sleep(2000);
            return new Javascripts(_driver);
        }

        public Javascripts clickPromptOkBtn()
        {
            IAlert promptAlert = _driver.SwitchTo().Alert();
            promptAlert.Accept();
            return new Javascripts(_driver);
        }

        public Javascripts enterNameInPromptPopup()
        {
           
            IAlert promptAlert = _driver.SwitchTo().Alert();
            promptAlert.SendKeys("Gian");
            return new Javascripts(_driver);
        }

        public Javascripts clickPromptCancelBtn()
        {
            IAlert cancelBtn = _driver.SwitchTo().Alert();
            cancelBtn.Dismiss();
            return new Javascripts(_driver);
        }

       
    }
}
