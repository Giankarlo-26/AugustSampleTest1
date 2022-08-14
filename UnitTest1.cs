using System;
using System.Threading;
using NUnit.Framework;
using NUnitTestProject1;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Tests
{
    [TestFixture]
    public class SampleFixture
    {
        private IWebDriver _driver;
        private HomePage homePage;

        [SetUp]
        public void Init()
        {
            Console.WriteLine("Initializing....");
            _driver = new ChromeDriver(@"C:\Users\User\source\repos\NUnitTestProject1\driver");
            _driver.Url = "http://automationpractice.com/index.php";
            _driver.Manage().Window.Maximize();
            homePage = new HomePage(_driver);


        }
        [Test]
        public void ValidItemSearch()
        {
            _driver.Manage().Window.Maximize();
            //enter valid object in search box
            var searchBox = _driver.FindElement(By.Id("search_query_top"));
            searchBox.SendKeys("dress");
            //click search btn
            var searchBtn = _driver.FindElement(By.Name("submit_search"));
            searchBtn.Click();
            Actions pdown = new Actions(_driver);
            pdown.SendKeys(Keys.ArrowDown).Build().Perform();
            pdown.SendKeys(Keys.ArrowDown).Build().Perform();
             // Thread.Sleep(3000);
           // WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // _driver.Quit();
        }

        [Test]
        public void InValidItemSearch()
        {
           
            _driver.Manage().Window.Maximize(); 
            //enter valid object in search box
            var searchBox = _driver.FindElement(By.Id("search_query_top"));
            searchBox.SendKeys("elephant and airplane");
            //click search btn
            var searchBtn = _driver.FindElement(By.Name("submit_search"));
            searchBtn.Click();
            Assert.NotNull(_driver.FindElement(By.XPath("//*[@id='center_column']/p")));
            //Thread.Sleep(3000);
           // _driver.Quit();
        }

        [Test]
        public void ForgotPw2()
        {
            _driver.Manage().Window.Maximize();
            // Verify if a user cannot log in with a invalid email
            //click sign in
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            Thread.Sleep(3000);

            Actions down = new Actions(_driver);
            down.SendKeys(Keys.PageDown).Build().Perform();
            //click forgot password
            _driver.Url = "http://automationpractice.com/index.php?controller=password";
            //enter invalid email
            var enterEmail = _driver.FindElement(By.Id("email"));
            enterEmail.SendKeys("ngik22@ya");

         
            //clcik retrieve btn
            var clickRetrieveBtn = _driver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button"));
            clickRetrieveBtn.Click();
            //Assert invalid email address message
            Assert.NotNull(_driver.FindElement(By.XPath("//*[@id='center_column']/div/div")));
            

        }
        [Test]
        public void ForgotPw()
        {
            _driver.Manage().Window.Maximize();
            // Verify if a user can log in with a valid username 
            //click sign in
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            //Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            Actions down = new Actions(_driver);
            down.SendKeys(Keys.PageDown).Build().Perform();
            //click forgot password
            var fg = wait.Until(driver => _driver.Url = "http://automationpractice.com/index.php?controller=password");

            //enter valid email
            // var enterEmail = _driver.FindElement(By.Id("email"));
            var enterEmail = wait.Until(driver => _driver.FindElement(By.Id("email")));
            enterEmail.SendKeys("ngik22@yahoo.com.sg");

            //click retrieve pw btn
            var clickRetrieveBtn = _driver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button"));
            clickRetrieveBtn.Click();
            Assert.NotNull(_driver.FindElement(By.XPath("//*[@id='center_column']/div/p")));
           // Assert.NotNull(_driver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button")));

        }
        [Test]
        public void noLogInDetails()
        {
            _driver.Manage().Window.Maximize();
            // Verify if a user cannot log in without any log in details.
            //click sign in
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";

            Thread.Sleep(3000);
            

            Actions down = new Actions(_driver);
            down.SendKeys(Keys.PageDown).Build().Perform();
            //click sign btn
            var clickSignIn = _driver.FindElement(By.Id("SubmitLogin"));
            clickSignIn.Click();

            //Thread.Sleep(2000);
            //_driver.Quit();
        }

        [Test]
        public void InvalidUsername()
        {
            var emailAdd1 = $"{Guid.NewGuid()}@yahoo.com";
            _driver.Manage().Window.Maximize();
            // Verify if a user cannot log in with a valid username and invalid password
            //click sign in
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";
            //login valid email
            var validEmail = _driver.FindElement(By.Id("email"));
            validEmail.SendKeys(emailAdd1);

            

            Actions a = new Actions(_driver);
            a.SendKeys(Keys.PageDown).Build().Perform();

            //Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            //log in invalid password
            var invalidPw = _driver.FindElement(By.Id("passwd"));
            invalidPw.SendKeys("1234567");

            //sclick ign btn

            var clickSign = wait.Until(driver => _driver.FindElement(By.Id("SubmitLogin")));
            clickSign.Click();

            Assert.NotNull(_driver.FindElement(By.XPath("//*[@id='center_column']/div[1]")));

           /* Thread.Sleep(2000);
            _driver.Quit();*/
        }

        [Test]
        public void InvalidPassword()
        {
            _driver.Manage().Window.Maximize();
            // Verify if a user cannot log in with a valid username and invalid password
            _driver.Url = "http://automationpractice.com/index.php?controller=my-account";
            var validEmail = _driver.FindElement(By.Id("email"));
            validEmail.SendKeys("ngik22@yahoo.com.sg");

            Actions a = new Actions(_driver);
            a.SendKeys(Keys.PageDown).Build().Perform();

            //Thread.Sleep(3000);
            WebDriverWait wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
           

            //type invalid password
            var invalidPw = _driver.FindElement(By.Id("passwd"));
            invalidPw.SendKeys("123");
            //click sign btn
            var clickSign = wait1.Until(driver => driver.FindElement(By.Id("SubmitLogin")));
            clickSign.Click();
           
            Assert.NotNull(_driver.FindElement(By.XPath("//div[@class='alert alert-danger']")));

          
            /* Thread.Sleep(2000);
             _driver.Quit();*/

        }

        [Test]
        public void ContactUs()
        {
            //Maximize window
            _driver.Manage().Window.Maximize();
            //  _driver.Manage().Window
            //click contact us
            _driver.Url = "http://automationpractice.com/index.php?controller=contact";
            //Select subject heading
            var subject = _driver.FindElement(By.Id("id_contact"));
            subject.SendKeys("Customer service");
            //type email
            var myEmail = _driver.FindElement(By.Id("email"));
            myEmail.SendKeys("ngik@yahoo.com");
            //Type Order ref
            var reference = _driver.FindElement(By.Id("id_order"));
            reference.SendKeys("123123");
            //write message
            var message = _driver.FindElement(By.Id("message"));
            message.SendKeys("I am still waiting for my item that I have ordered last week.");

          
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            //click submit

            /* var submitBtn = _driver.FindElement(By.Id("submitMessage"));
             submitBtn.Click();*/
            var submitBtn = wait.Until(_driver => _driver.FindElement(By.Id("submitMessage")));
            submitBtn.Click();

            //click Home btn
            // _driver.Url = "http://automationpractice.com/";

            //Assert home btn

           // Assert.NotNull(_driver.Url = "http://automationpractice.com/");

           
        }

        [Test]
        public void Purchasing()
        {
            //click sign up btn
            var signInButton = _driver.FindElement(By.ClassName("login"));
            //Click on submit button
            signInButton.Click();
            _driver.Manage().Window.Maximize();

            //verify email
            var logIn = _driver.FindElement(By.Id("email"));
            logIn.SendKeys("ngik22@yahoo.com.sg");
            // verify password
            var myPassword = _driver.FindElement(By.Id("passwd"));
            myPassword.SendKeys("1234567");
            //click log in button
            var logInBtn = _driver.FindElement(By.Id("SubmitLogin"));
            logInBtn.Click();
            Thread.Sleep(3000);

            //Proceed to checkout
            _driver.Url = "http://automationpractice.com/index.php?id_category=5&controller=category";
            _driver.Url = "http://automationpractice.com/index.php?controller=cart&add=1&id_product=1&token=e656323a38db67417110dc55423bf153";
            _driver.Url = "http://automationpractice.com/index.php?controller=order&step=1";
            var processAdd = _driver.FindElement(By.Name("processAddress"));
            processAdd.Click();
            //Click terms
            var terms = _driver.FindElement(By.Id("cgv"));
            terms.Click();

            Actions pdown = new Actions(_driver);
            pdown.SendKeys(Keys.ArrowDown).Build().Perform();
            pdown.SendKeys(Keys.ArrowDown).Build().Perform();

            //Proceed checkout
            var checkoutBtn = _driver.FindElement(By.Name("processCarrier"));
            checkoutBtn.Click();
            _driver.Url = "http://automationpractice.com/index.php?fc=module&module=bankwire&controller=payment";
            //Confirm order
            var confirmOrder = _driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            confirmOrder.Click();

            Actions pgdown = new Actions(_driver);
            pgdown.SendKeys(Keys.ArrowDown).Build().Perform();
            pgdown.SendKeys(Keys.ArrowDown).Build().Perform();

            Assert.NotNull( _driver.Url = "http://automationpractice.com/index.php?mylogout=");
           // Thread.Sleep(3000);
            // Sign out
           // _driver.Url = "http://automationpractice.com/index.php?mylogout=";


        }


        [Test]
        public void Registration()
        {
            var emailAdd = $"{Guid.NewGuid()}@yahoo.com";
            //click sign up btn
            var signInButton = _driver.FindElement(By.ClassName("login"));
            //Click on submit button
            signInButton.Click();

            var searchEmail = _driver.FindElement(By.Id("email_create"));
            //Enter valid email to search bar
            searchEmail.SendKeys(emailAdd);

            // click create account button
            var clickCreateAcctBtn = _driver.FindElement(By.Name("SubmitCreate"));
            clickCreateAcctBtn.Click();


            //Thread.Sleep(15000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            //Title:
            var nameTitle = wait.Until(driver => driver.FindElement(By.Id("id_gender1")));
            nameTitle.Click();
            //Firstname
            IWebElement firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("Giankarlo");
            //LastName
            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Espinosa");
            //Password
            var enterPw = _driver.FindElement(By.Id("passwd"));
            enterPw.SendKeys("ngik22");
            //date of birth
            var selectDay = _driver.FindElement(By.Id("days"));
            selectDay.SendKeys("26");

            var selectMonth = _driver.FindElement(By.Id("months"));
            selectMonth.SendKeys("December");

            var selectYear = _driver.FindElement(By.Id("years"));
            selectYear.SendKeys("1981");
            //Company
            var selectCom = _driver.FindElement(By.Id("company"));
            selectCom.SendKeys("NUFF");
            //Address1
            var selectAdd1 = _driver.FindElement(By.Id("address1"));
            selectAdd1.SendKeys("Stirling road");
            //City
            var dCity = _driver.FindElement(By.Id("city"));
            dCity.SendKeys("Guildford");

            //State
            var State = _driver.FindElement(By.Id("id_state"));
            State.SendKeys("Alabama");

            
           // Thread.Sleep(4000);
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));  // wait(_driver, TimeSpan.FromSeconds(20));
            //Postcode
            var dpostcode = _driver.FindElement(By.Id("postcode"));
            dpostcode.SendKeys("90000");
            //Mobile#
            var mobPhone = _driver.FindElement(By.Id("phone_mobile"));
            mobPhone.SendKeys("2217066");
            //Alias
            var myEmail = _driver.FindElement(By.Name("alias"));
            myEmail.Clear();
            myEmail.SendKeys(" kkk@yahoo.com.sg");

            Thread.Sleep(3000);
            WebDriverWait wait3 = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            //Submit account
            var subAcct = _driver.FindElement(By.Id("submitAccount"));
            subAcct.Click();
            
            Assert.NotNull(_driver.FindElement(By.ClassName("logout")));
            Assert.AreEqual(_driver.FindElement(By.XPath("//a[@title='View my customer account']/span")).Text,"Giankarlo Espinosa");
            

            //Close window

            //oop elements polymorphism , inheritence-----------------
            //remove sleeps -. wait until -----------------done
            //assertions every test---------------------done
            //xpath  $x("//a[@title") ------------------done
            //xpath travel in and out -------------done
            //constructor ------------------- done
            // selenium c# page object model-------------------


        }

       /*[TearDown]
        public void CleanUp()
        {
            Console.WriteLine("Cleaning up...");
         
            _driver.Quit();
        }*/
    }
}


 