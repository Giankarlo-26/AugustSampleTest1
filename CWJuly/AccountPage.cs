using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using CWJuly;

namespace CWJuly
{
    public class AccountPage
    {
        private IWebDriver _driver;

        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement HomeGreeting => _driver.FindElement(By.XPath("//div[@class='ui huge header center aligned']"));

        public IWebElement radio1 => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 1')]/parent::div/descendant::input"));
        public IWebElement radio2 => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 2')]/parent::div/descendant::input"));
        public IWebElement radio3 => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 3')]/parent::div/descendant::input"));
        public IWebElement radio4 => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 4')]/parent::div/descendant::input"));
        public IWebElement radio5 => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 5')]/parent::div/descendant::input"));

        public IWebElement checkbox4 => _driver.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div[2]/div/div[4]/div/input"));

        public IWebElement slider2 => _driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]/div[2]/div/div/div/div[2]/div/input"));

        public IWebElement radioChecked => _driver.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[contains(@checked,'checked')]"));



        // public IWebElement checkbox => 
        public AccountPage clickOnRadio1()
        {
            radio1.Click();
            Thread.Sleep(1000);
            return new AccountPage(_driver);
        }
        public AccountPage clickOnRadio2()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var radio2 = wait.Until(driver => _driver.FindElement(By.XPath("//div/label[contains(text(),'Radio 2')]/parent::div/descendant::input")));
            radio2.Click();
           // Thread.Sleep(2000);
            return new AccountPage(_driver);
        }
        public AccountPage clickOnRadio3()
        {
            radio3.Click();
            Thread.Sleep(1000);
            return new AccountPage(_driver);
        }
        public AccountPage clickOnRadio4()
        {
            radio4.Click();
            Thread.Sleep(1000);
            return new AccountPage(_driver);
        }
        public AccountPage clickOnRadio5()
        {
            radio5.Click();
            Thread.Sleep(1000);
            return new AccountPage(_driver);
        }

        public AccountPage clickEachRadioBtns()
        {
            var radioBtns = _driver.FindElements(By.XPath("//div[@class='ui radio checkbox']"));
            foreach (var radioBtn in radioBtns)
            {
                radioBtn.Click();
                break;
              
            }
            return new AccountPage(_driver);
        }

        public AccountPage checkAllBoxes()
        {
            var checkboxes = _driver.FindElements(By.XPath("//input[@type='checkbox']"));
            foreach (var checkbox in checkboxes)
            {
                    checkbox.Click();
                    Thread.Sleep(1000);
                
            }

            return new AccountPage(_driver);
        }

        public AccountPage clickOn4thCheckbox()
        {

            checkbox4.Click();
            return new AccountPage(_driver);
        }

        public AccountPage usingAllSlides()
        {
           
            var slides = _driver.FindElements(By.XPath("//input[@name='throughput']"));
            foreach (var slide in slides)
            {
                slide.Click();
                
            }
            return new AccountPage(_driver);
        }

        public AccountPage clickSecondSlider()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var slider2 = wait.Until(driver => _driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]/div[2]/div/div/div/div[2]/div/input")));
            slider2.Click(); Thread.Sleep(3000);
            return new AccountPage(_driver);
        }

        public AccountPage ClickSlider3()
        {
           var  slider3 = _driver.FindElement(By.XPath("/html/body/div/div[2]/div[4]/div[2]/div/div/div/div[3]/div/input"));
            return new AccountPage(_driver);
        }

    }
}
