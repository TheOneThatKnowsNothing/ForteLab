using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ForteLab
{
    
    [TestFixture]

    public class Class1
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var Site = driver.FindElement(By.ClassName("login"));
            Site.Click();
            var Email = driver.FindElement(By.Name("email"));
            Email.SendKeys("doctorhaus@i.ua");
            var Password = driver.FindElement(By.Name("passwd"));
            Password.SendKeys("oleg1");
            var LogButton = driver.FindElement(By.Name("SubmitLogin"));
            LogButton.Click();
        }
        [TearDown]
        public void TearDown()
        {
            var LogOut = driver.FindElement(By.ClassName("logout"));
            LogOut.Click();
            driver.Quit();
        }
        [Test]
        public void CheckContactUsTitle()
        {
         
            var CatalogLink = driver.FindElement(By.Id("contact-link"));
            CatalogLink.Click();

            Assert.AreEqual("Contact us - My Store", driver.Title);

        }
        [Test]
        public void ChangeNameAndFamily()
        {
            var Profile = driver.FindElement(By.ClassName("header_user_info"));
            Profile.Click();
            var EditProfile = driver.FindElement(By.ClassName("icon-user"));
            EditProfile.Click();
            var FirstName = driver.FindElement(By.Id("firstname"));
            FirstName.Clear();
            FirstName.SendKeys("Roman");
            var LastName = driver.FindElement(By.Id("lastname"));
            LastName.Clear();
            LastName.SendKeys("Baklan");
            var OldPassword = driver.FindElement(By.Id("old_passwd"));
            OldPassword.SendKeys("oleg1");
            var SaveButton = driver.FindElement(By.Name("submitIdentity"));
            SaveButton.Click();
            Profile = driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[1]/a/span"));
            Profile.Click();
            EditProfile = driver.FindElement(By.ClassName("icon-user"));
            EditProfile.Click();
            FirstName = driver.FindElement(By.Id("firstname"));
            Assert.AreEqual("Roman", FirstName.GetAttribute("value"));
            LastName = driver.FindElement(By.Id("lastname"));
            Assert.AreEqual("Baklan",LastName.GetAttribute("value"));
        }
    }
}
