using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using AngleSharp.Dom;
using AngleSharp.Text;
using MaybeThisTime.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MaybeThisTime.PageObjects
{
    public class CreateAccountPage
    {
        private IWebDriver driver;
        //private CommonFunctions CommonFunctions;


        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------
        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/child::h1")]
        private IWebElement createAnAccountText;
        private By createAnAccountTextBy = By.XPath("//div[@id='center_column']/child::h1");


        // personal information
        [FindsBy(How = How.Id, Using = "id_gender1")]
        private IWebElement checkGenderMan;
        private By checkGenderManBy = By.Id("id_gender1");

        [FindsBy(How = How.Id, Using = "id_gender2")]
        private IWebElement checkGenderFemale;
        private By checkGenderFemaleBy = By.Id("id_gender2");

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement customerFirstName;
        private By customerFirstNameBy = By.Id("customer_firstname");

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement customerLastName;
        private By customerLastNameBy = By.Id("customer_lastname");

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement customerEmail;
        private By customerEmailBy = By.Id("email");

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement accountPassword;
        private By accountPasswordBy = By.Id("passwd");

        // date of birth
        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement birthDay;
        private By birthDayBy = By.Id("days");

        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement birthMonth;
        private By birthMonthsBy = By.Id("months");

        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement birthYear;
        private By birthYearBy = By.Id("years");

        // ---
        [FindsBy(How = How.Id, Using = "uniform-newsletter")]
        private IWebElement checkNewsletter;
        private By checkNewsletterBy = By.Id("uniform-newsletter");

        [FindsBy(How = How.Id, Using = "uniform-optin")]
        private IWebElement checkSpecialOffers;
        private By checkSpecialOffersBy = By.Id("uniform-optin");

        //-------------------------------------------------------------------------
        // address
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement addressFirstName;
        private By addressFirstNameBy = By.Id("firstname");

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement addressLastName;
        private By addressLastNameBy = By.Id("lastname");

        [FindsBy(How = How.Id, Using = "company")]
        private IWebElement addressCompanyName;
        private By addressCompanyNameBy = By.Id("company");

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement addressStreetAndNumber;
        private By addressStreetAndNumberBy = By.Id("address1");

        [FindsBy(How = How.Id, Using = "address2")]
        private IWebElement addressApartmentNumber;
        private By addressApartmentNumberBy = By.Id("address2");

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement addressCity;
        private By addressCityBy = By.Id("city");

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement addressState;
        private By addressStateById = By.Id("id_state");
        private By addressStatesByXPath = By.XPath("//select[@id='id_state']//option");

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement addressPostCode;
        private By addressPostCodeBy = By.Id("postcode");

        [FindsBy(How = How.Id, Using = "id_country")]
        private IWebElement addressCountry;
        private By addressCountryBy = By.Id("id_country");

        // ---
        [FindsBy(How = How.Id, Using = "other")]
        private IWebElement additionalInfromation;
        private By additionalInfromationBy = By.Id("other");

        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement phoneHome;
        private By phoneHomeBy = By.Id("phone");

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement phoneMobile;
        private By phoneMobileBy = By.Id("phone_mobile");

        [FindsBy(How = How.Id, Using = "alias")]
        private IWebElement emailAddresAlias;
        private By emailAddresAliasBy = By.Id("alias");

        // ---

        [FindsBy(How = How.Id, Using = "submitAccount")]
        private IWebElement submitAccountButton;
        private By submitAccountButtonBy = By.Id("submitAccount");


        // list data

        private By typeRadioButtonBy = By.Name("id_gender");
        private By typeCheckboxBy = By.XPath("//input[@type='checkbox']");
        //--------------------------------------------------------------------------------------------------------------------------------------
        // IWebElement

        public IWebElement CreateAnAccountText()
        {
            return createAnAccountText;
        }
        // personal information
        public IWebElement CheckGenderMan()
        {
            return checkGenderMan;
        }

        public IWebElement CheckGenderFemale()
        {
            return checkGenderFemale;
        }

        public IWebElement CustomerFirstName()
        {
            return customerFirstName;
        }

        public IWebElement CustomerLastName()
        {
            return customerLastName;
        }

        public IWebElement CustomerEmail()
        {
            return customerEmail;
        }

        public IWebElement AccountPassword()
        {
            return accountPassword;
        }

        // date of birth
        public IWebElement BirthDay()
        {
            return birthDay;
        }

        public IWebElement BirthMonth()
        {
            return birthMonth;
        }

        public IWebElement BirthYear()
        {
            return birthYear;
        }

        // ---
        public IWebElement CheckNewsletter()
        {
            return checkNewsletter;
        }

        public IWebElement CheckSpecialOffers()
        {
            return checkSpecialOffers;
        }

        //-------------------------------------------------------------------------
        // address
        public IWebElement AddressFirstName()
        {
            return addressFirstName;
        }

        public IWebElement AddressLastName()
        {
            return addressLastName;
        }
        public IWebElement AddressCompanyName()
        {
            return addressCompanyName;
        }

        public IWebElement AddressStreetAndNumber()
        {
            return addressStreetAndNumber;
        }

        public IWebElement AddressApartmentNumber()
        {
            return addressApartmentNumber;
        }

        public IWebElement AddressCity()
        {
            return addressCity;
        }

        public IWebElement AddressState()
        {
            return addressState;
        }

        public IWebElement AddressPostCode()
        {
            return addressPostCode;
        }

        public IWebElement AddressCountry()
        {
            return addressCountry;
        }

        // ---

        public IWebElement AdditionalInfromation()
        {
            return additionalInfromation;
        }

        public IWebElement PhoneHome()
        {
            return phoneHome;
        }

        public IWebElement PhoneMobile()
        {
            return phoneMobile;
        }

        public IWebElement EmailAddresAlias()
        {
            return emailAddresAlias; 
        }

        // ---
        public IWebElement SubmitAccountButton()
        {
            return submitAccountButton;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // By
        public By CreateAnAccountTextBy()
        {
            return createAnAccountTextBy;
        }
        // personal information

        public By CheckGenderManBy()
        {
            return checkGenderManBy;
        }

        public By CheckGenderFemaleBy()
        {
            return checkGenderFemaleBy;
        }

        public By CustomerFirstNameBy()
        {
            return customerFirstNameBy;
        }

        public By CustomerLastNameBy()
        {
            return customerLastNameBy;
        }

        public By CustomerEmailBy()
        {
            return customerEmailBy;
        }

        public By AccountPasswordBy()
        {
            return accountPasswordBy;
        }

        // date of birth

        public By BirthDayBy()
        {
            return birthDayBy;
        }

        public By BirthMonthsBy()
        {
            return birthMonthsBy;
        }

        public By BirthYearBy()
        {
            return birthYearBy;
        }

        // ---

        public By CheckNewsletterBy()
        {
            return checkNewsletterBy;
        }

        public By CheckSpecialOffersBy()
        {
            return checkSpecialOffersBy;
        }

        //-------------------------------------------------------------------------
        // address
        public By AddressFirstNameBy()
        {
            return addressFirstNameBy;
        }

        public By AddressLastNameBy()
        {
            return addressLastNameBy;
        }

        public By AddressCompanyNameBy()
        {
            return addressCompanyNameBy;
        }
        public By AddressStreetAndNumberBy()
        {
            return addressStreetAndNumberBy;
        }

        public By AddressApartmentNumberBy()
        {
            return addressApartmentNumberBy;
        }

        public By AddressCityBy()
        {
            return addressCityBy;
        }

        public By AddressStateById()
        {
            return addressStateById;
        }

        public By AddressStatesByXPath()
        {
            return addressStatesByXPath;
        }

        public By AddressPostCodeBy()
        {
            return addressPostCodeBy;
        }

        public By AddressCountryBy()
        {
            return addressCountryBy;
        }

        // ---
        public By AdditionalInfromationBy()
        {
            return additionalInfromationBy;
        }

        public By PhoneHomeBy()
        {
            return phoneHomeBy;
        }

        public By PhoneMobileBy()
        {
            return phoneMobileBy;
        }

        public By EmailAddresAliasBy()
        {
            return emailAddresAliasBy;
        }

        // ---
        public By SubmitAccountButtonBy()
        {
            return submitAccountButtonBy;
        }

        // list data

        public By TypeRadioButtonBy()
        {
            return typeRadioButtonBy;
        }

        public By TypeCheckboxBy()
        {
            return typeCheckboxBy;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------
        // input click
        // personal information
        public void CustomerFirstNameClick()
        {
           CommonFunctions.ElementClick(CustomerFirstName());
        }

        public void CustomerLastNameClick()
        {
            CommonFunctions.ElementClick(CustomerLastName());
        }

        public void CustomerEmailClick()
        {
            CommonFunctions.ElementClick(CustomerEmail());
        }

        public void AccountPasswordClick()
        {
            CommonFunctions.ElementClick(AccountPassword());
        }

        // address
        public void AddressFirstNameClick()
        {
            CommonFunctions.ElementClick(AddressFirstName());
        }

        public void AddressLastNameClick()
        {
            CommonFunctions.ElementClick(AddressLastName());
        }

        public void AddressCompanyNameClick()
        {
            CommonFunctions.ElementClick(AddressCompanyName());
        }

        public void AddressStreetAndNumberClick()
        {
            CommonFunctions.ElementClick(AddressStreetAndNumber());
        }

        public void AddressApartmentNumberClick()
        {
            CommonFunctions.ElementClick(AddressApartmentNumber());
        }

        public void AddressCityClick()
        {
            CommonFunctions.ElementClick(AddressCity());
        }

        public void AddressPostCodeClick()
        {
            CommonFunctions.ElementClick(AddressPostCode());
        }

        // ---

        public void AdditionalInfromationClick()
        {
            CommonFunctions.ElementClick(AdditionalInfromation());
        }

        public void PhoneHomeClick()
        {
            CommonFunctions.ElementClick(PhoneHome());
        }

        public void PhoneMobileClick()
        {
            CommonFunctions.ElementClick(PhoneMobile());
        }

        public void EmailAddresAliasClick()
        {
            CommonFunctions.ElementClick(EmailAddresAlias());
        }

        // ---
        public void SubmitAccountButtonClick()
        {
            CommonFunctions.ElementClick(SubmitAccountButton());
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // radio button click

        public void CheckGenderMrs()
        {
            string attributeName = "value";
            string attributeValue = ChooseGender(2);
            CommonFunctions.ChooseElementFromList(TypeRadioButtonBy(), attributeName, attributeValue);
        }

        public void CheckGenderMr()
        {
            string attributeName = "value";
            string attributeValue = ChooseGender(1);
            CommonFunctions.ChooseElementFromList(TypeRadioButtonBy(), attributeName, attributeValue);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        // check click

        public void CheckNewsletterClick()
        {
            CommonFunctions.ElementClick(TypeCheckboxBy(), 0);

        }

        public void CheckSpecialOffersClick()
        {
            CommonFunctions.ElementClick(TypeCheckboxBy(), 1);

        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // choose an option from drop down list
        // date of birth
        
        public void ChooseBirthDayFromDropDownList(string birthDay)
        {
            CommonFunctions.ChooseElementFromList(BirthDay(), 1, birthDay);
        }

        public void ChooseBirthMonthsFromDropDownList(string birthMonth)
        {
            CommonFunctions.ChooseElementFromList(BirthMonth(), 1, birthMonth);
        }

        public void ChooseBirthYearFromDropDownList(string birthYear)
        {
            CommonFunctions.ChooseElementFromList(BirthYear(), 1, birthYear);
        }

        public void ChooseBirthDate(string birthDay, string birthMonth, string birthYear)
        {
            ChooseBirthDayFromDropDownList(birthDay);
            ChooseBirthMonthsFromDropDownList(birthMonth);
            ChooseBirthYearFromDropDownList(birthYear);
        }

        // state

        public void ChooseStateFromDropDownList()
        {
            string stateName = "Alaska";
            CommonFunctions.ChooseElementFromList(AddressState(), 2, stateName);
        }

        public void ChooseStateFromDropDownList(string stateName)
        {
            IWebElement parentElement = AddressState();
            By childElements = AddressStatesByXPath();
            CommonFunctions.ChooseElementFromList(parentElement, childElements, stateName);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // switch
        /// <summary>
        /// <para> int genderNumber = 1 => "Mr."</para>
        /// <para> int genderNumber = 2 => "Mrs."</para>
        /// </summary>
        /// <param name="genderNumber"></param>
        /// <returns></returns>
        public string ChooseGender(int genderNumber)
        {
            return genderNumber switch
            {
                1 => "1",
                2 => "2",
                _ => "2"
            };
        }


        public void DeleteCustomerEmail()
        {    
            IWebElement email = CustomerEmail();
            string symbol = "a";
            int howManyTimePressBackspace = 1;
            CustomerEmailClick();
            CommonFunctions.PressKeyControlPlusSymbol(email, symbol);
            CommonFunctions.PressKeyBackspace(email, howManyTimePressBackspace);
        }

        public string GetCreateAnAccountText()
        {
            By createAnAccountTextBy = CreateAnAccountTextBy();
            double time = 10;
            CommonFunctions.WaitUtilElementDisplayBy(createAnAccountTextBy, time);
            IWebElement createAnAccountText = CreateAnAccountText();
            string text = CommonFunctions.GetText(createAnAccountText);
            return text;
        }

        /*
        public void DeleteTextForAddressAlias()
        {
            IWebElement addressAlias = EmailAddresAlias();
            string attributeName = "Value";
            CommonFunctions.ScrollToElement(addressAlias);
            EmailAddresAliasClick();
            int howManyTimePressBackspace = CommonFunctions.GetValueLenght(addressAlias, attributeName);
            CommonFunctions.PressKeyBackspace(addressAlias, howManyTimePressBackspace);
        }
        */




        //--------------------------------------------------------------------------------------------------------------------------------------

        public void TestDictionary(int dictionaryId, string textForField)
        {
            
            IWebElement firstName = CustomerFirstName();
            IWebElement lastName = CustomerLastName();

            Dictionary<int, IWebElement> testDictionary = new Dictionary<int, IWebElement>()
            {
                { 1, firstName},
                { 2, lastName}
            };
            
            KeyValuePair<int, IWebElement> keyValuePair = testDictionary.ElementAt(dictionaryId);
            IWebElement elementFromDictionary = keyValuePair.Value;
            CommonFunctions.SendText(elementFromDictionary, textForField);


        }
        
    }
}
