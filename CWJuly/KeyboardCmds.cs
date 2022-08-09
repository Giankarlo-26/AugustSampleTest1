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
    class KeyboardCmds
    {
        private IWebDriver _driver;

        public KeyboardCmds(IWebDriver driver)
        {
            _driver = driver;
        }


        #region Action  
        public KeyboardCmds usingEnterKeyInKeyboard()
        {
            Actions enterKey = new Actions(_driver);
            enterKey.SendKeys(Keys.Enter).Build().Perform();

            return new KeyboardCmds(_driver);
        }

        public KeyboardCmds usingEscKeyInKeyboard()
        {
            Actions escKey = new Actions(_driver);
            escKey.SendKeys(Keys.Escape).Build().Perform();
            return new KeyboardCmds(_driver);
        }

        public KeyboardCmds usingArrowRightKeyInTheKeyboard()
        {
            Actions arrowRightKey = new Actions(_driver);
            arrowRightKey.SendKeys(Keys.ArrowRight).Build().Perform();
            return new KeyboardCmds(_driver);
        }


        #endregion
    }
}
