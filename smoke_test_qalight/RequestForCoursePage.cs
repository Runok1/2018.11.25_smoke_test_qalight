using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace smoke_test_qalight
{
    public class RequestForCoursePage : BasePage
    {
        public RequestForCoursePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div/div[1]/div/a/img")]
        public IWebElement elementHeaderLogo;

        [FindsBy(How = How.XPath, Using = "//*[@id='footer_logo']/a/img")]
        public IWebElement elementFooterLogo;

        [FindsBy(How = How.XPath, Using = "//*[@id='navbar-collapse-1']/ul/li")]
        public IList<IWebElement> elementsListNavigationBar;
        
        [FindsBy(How = How.CssSelector, Using = "#z_sender0")]
        public IWebElement surname;

        [FindsBy(How = How.CssSelector, Using = "select[name = '_7c8289bf6b8e80c1749ef54ab01b92b8']")]
        public IWebElement courseDropdown;

        //[FindsBy(How = How.XPath, Using = "//*[@id='fox_form_m135']/div[1]/div/select']")]
        //public IWebElement courseDropdown;

        [FindsBy(How = How.XPath, Using = "//*[@id='z_text1']")]
        public IWebElement name;

        [FindsBy(How = How.XPath, Using = "//*[@id='z_text0']")]
        public IWebElement phone;

        [FindsBy(How = How.XPath, Using = "//*[@id='z_sender1']")]
        public IWebElement email;

        [FindsBy(How = How.XPath, Using = "//*[@id='z_text2']")]
        public IWebElement skype;

        [FindsBy(How = How.XPath, Using = "//*[@id='fox_form_m135']/div[7]/div/select")]
        public IWebElement whereFromDropdown;

        [FindsBy(How = How.XPath, Using = "//*[@id='fox_form_m135']/div[8]/div/textarea")]
        public IWebElement queryOrComment;

        [FindsBy(How = How.XPath, Using = "//*[@id='fox_form_m135']/div[9]/div/button[1]/span")]
        public IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='foxcontainer_m135']/div/ul/li")]
        public IWebElement finalMessage;
    }
}
