using MaybeThisTime.Common;
using MaybeThisTime.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaybeThisTime.VariousNeeded.CreateAnAccount
{
    public class NewAccountGetEmailForRegistrationPage
    {
        
        private IWebDriver driver;

        public NewAccountGetEmailForRegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------

        [FindsBy(How = How.Id, Using = "copy-button")]
        private  IWebElement copyNewEmail;
        private By copyNewEmailBy = By.Id("copy-button");

        //--------------------------------------------------------------
        public IWebElement CopyNewEmail()
        {
            return copyNewEmail;
        }

        //--------------------------------------------------------------
        public By CopyNewEmailBy()
        {
            return copyNewEmailBy;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------

        public void CopyNewEmailValue()
        {
            CommonFunctions.ElementClick(CopyNewEmail());
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        public void GetEmailForNewAccount()
        {
            CommonFunctions.WaitUtilElementDisplayBy(CopyNewEmailBy(), 8);
            CopyNewEmailValue();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // go to 
        public LoginPage GoBackToLoginPage(string originalWindow)
        {
            CommonFunctions.CloseTab();
            CommonFunctions.SwitchToOriginalWindow(originalWindow);
            return new LoginPage(driver);
        }

 


    }
}
