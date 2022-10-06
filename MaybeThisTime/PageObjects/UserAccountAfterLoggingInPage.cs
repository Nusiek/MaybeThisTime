using MaybeThisTime.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeThisTime.PageObjects
{
    public class UserAccountAfterLoggingInPage
    {

        private IWebDriver driver;

        public UserAccountAfterLoggingInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------

        [FindsBy(How = How.ClassName, Using = "logout")]
        private IWebElement logoutButton;
        private By logoutButtonBy = By.ClassName("logout");

        //--------------------------------------------------------------------------------------------------------------------------------------

        public IWebElement LogoutButton()
        {
            return logoutButton;
        }

        //--------------------------------------------------------------

        public By LogoutButtonBy()
        {
            return logoutButtonBy;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------

        public string GetLogoutButtonText()
        {
            By logoutButtonBy = LogoutButtonBy();
            double time = 30;
            CommonFunctions.WaitUtilElementDisplayBy(logoutButtonBy, time);
            IWebElement logoutButton = LogoutButton();
            string text = CommonFunctions.GetText(logoutButton);
            return text;
        }
    }
}
