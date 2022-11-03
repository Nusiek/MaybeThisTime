using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaybeThisTime.Common;
using System.Threading;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Net.Mail;

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


        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------

        [FindsBy(How = How.XPath, Using = "//div[@class='header_user_info']/a")]
        private IWebElement singInButton;

        [FindsBy(How = How.Id, Using = "contact-link")]
        private IWebElement contactUs;



        //--------------------------------------------------------------------------------------------------------------------------------------
        // IWebElement

        public IWebElement IWebElement(IWebElement element)
        {
            IWebElement webElement = element;
            return webElement;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // By

        public By ElementBy(By element)
        {
            By webElement = element;
            return webElement;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page dictionary
        //--------------------------------------------------------------------------------------------------------------------------------------

        public IWebElement IWebElementDictionary(int dictionaryId)
        {
            IWebElement singInButton0 = IWebElement(singInButton);
            IWebElement contactUs0 = IWebElement(contactUs);

            Dictionary<int, IWebElement> IWebElementDictionary = new Dictionary<int, IWebElement>()
            {
                {1, singInButton0},
                {2, contactUs0}
            };

            IWebElement elementFromDictionary = IWebElementDictionary[dictionaryId];
            return elementFromDictionary;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------



        public LoginPage GoToLoginPage()
        {
            IWebElement elementFromDictionary = IWebElementDictionary(1);
            CommonFunctions.ElementClick(elementFromDictionary);
            return new LoginPage(driver);
        }

        public ContactUsPage GoToContactUsPage()
        {
            IWebElement elementFromDictionary = IWebElementDictionary(2);
            CommonFunctions.ElementClick(elementFromDictionary);
            return new ContactUsPage(driver);
        }

    }

}
