using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace smoke_test_qalight
{
    
    public class UnitTest
    {
        IWebDriver driver;

        public object SelectElement { get; private set; }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void TestHeaderLogoIsDisplayed()
        {
            RequestForCoursePage requestForCourcePage = new RequestForCoursePage(driver);

            Assert.True(requestForCourcePage.elementHeaderLogo != null, "Header Logo Element is NOT displayed.");
            Console.WriteLine("Header Logo Element is displayed.");
        }


        [Test]
        public void TestFooterLogoIsDisplayed()
        {
            RequestForCoursePage requestForCourcePage = new RequestForCoursePage(driver);

            Assert.True(requestForCourcePage.elementFooterLogo != null, "Footer Logo Element is NOT displayed.");
            Console.WriteLine("Footer Logo Element is displayed.");
        }

        [Test]
        public void TestNavigationBarCount1()
        {
            RequestForCoursePage requestForCourcePage = new RequestForCoursePage(driver);

            int count = requestForCourcePage.elementsListNavigationBar.Count;

            Assert.True(count == 8, $"Count of elements in Navigation Bar is wrong. Is displayed {count}.");
            Console.WriteLine($"Are displayed {count} elements in Navigation Bar.");
        }

        [Test]
        public void TestNavigationBarCount()
        {
            ReadOnlyCollection<IWebElement> elementsNavigationBar = driver.FindElements(By.XPath("//*[@id='navbar-collapse-1']/ul/li"));
            int countElementsNavigationBar = elementsNavigationBar.Count;

            Assert.True(countElementsNavigationBar == 8, $"Count of elements in Navigation Bar is wrong. Is displayed {countElementsNavigationBar}.");
            Console.WriteLine($"Are displayed {countElementsNavigationBar} elements in Navigation Bar.");
        }

        [Test]
         public void TestSmokeRegistration()
        {
            RequestForCoursePage requestForCoursePage = new RequestForCoursePage(driver);

            SelectElement dropdown1 = new SelectElement(requestForCoursePage.courseDropdown);
            dropdown1.SelectByIndex(3);
            Thread.Sleep(3000);
            requestForCoursePage.surname.SendKeys("TestSurname");

            requestForCoursePage.name.SendKeys("TestName");

            requestForCoursePage.phone.SendKeys("0951234567");

            requestForCoursePage.email.SendKeys("test@test.com");

            requestForCoursePage.skype.SendKeys("testSkype");

            SelectElement dropdown2 = new SelectElement(requestForCoursePage.whereFromDropdown);
            dropdown2.SelectByIndex(9);

            requestForCoursePage.queryOrComment.SendKeys("TestText. TestText.");

            requestForCoursePage.sendButton.Click();

            string actualFinalMessage = requestForCoursePage.finalMessage.Text;
            string expectedFinalMessage = "Доброго времени суток!\r\nСпасибо что обратились в нашу компанию.\r\nВаша заявка принята.\r\nАдминистратор QALight свяжется с Вами в ближайшее время, для уточнения деталей и ответа на все интересующие Вас вопросы.";

            //Assert.True(actualFinalMessage.Equals(expectedFinalMessage), "Final Message is incorrect.");
            //Console.WriteLine("Registration was done successfully.");

            Assert.Less(8, 5, "Ping");
        }





        //[Test]
        //public void SelectTest()
        //{
        //    //Arrange
        //    IWebElement elementLogo;
        //    String logoXPath = "/html/body/div[2]/header/div/div[1]/div/a/img";

        //    //Act
        //    elementLogo = driver.FindElement(By.XPath(logoXPath));

        //    ReadOnlyCollection<IWebElement> elementsNavigationBar = driver.FindElements(By.XPath("//*[@id='navbar-collapse-1']/ul/li"));
        //    IWebElement elementLogo1 = driver.FindElement(By.CssSelector("[alt = logo]"));
        //    ReadOnlyCollection<IWebElement> elementsNavigationBarID = driver.FindElements(By.Id("navbar-collapse-1"));

        //    IWebElement elementSelect = driver.FindElement(By.XPath("//*[@id='fox_form_m135']/div[1]/div/select"));
        //    elementSelect.Click();
        //    Thread.Sleep(3000);
        //    SelectElement selectElements = new SelectElement(elementSelect);
        //    selectElements.SelectByText("Java");
        //    Thread.Sleep(2000);
        //    selectElements.SelectByIndex(3);
        //    Thread.Sleep(2000);

        //    //Assert
        //    Assert.True(elementLogo != null, "The first Logo is NOT displayed on the page.");
        //    Console.WriteLine($"The first Logo is SUCCESSFULLY displayed on page: {elementLogo}");

        //}



        

    }
}
