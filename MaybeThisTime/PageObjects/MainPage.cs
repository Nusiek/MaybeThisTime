using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaybeThisTime.Common;
using System.Threading;

namespace MaybeThisTime.PageObjects
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PageObject factory

        [FindsBy(How = How.XPath, Using = "//div[@class='header_user_info']/a")]
        [CacheLookup]
        private IWebElement singInButton;


        private  IWebElement SingInButton()
        {
            return singInButton;
        }

        public void SingInButtonClick()
        {
            CommonFunctions.ElementClick(SingInButton());
        }

        public LoginPage GoToLoginPage()
        {
            CommonFunctions.ElementClick(SingInButton());
            return new LoginPage(driver);
        }


    }

}
