using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Amazon.Runtime.Internal.Transform;
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace MaybeThisTime.PageObjects
{
    public class CreateAccountPage
    {
        private IWebDriver driver;

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

        // error list
        [FindsBy(How = How.XPath, Using = "//div[@id=\"center_column\"]/div/p")]
        private IWebElement mainErrorTextMessagesNumber;
        private By errorMessagesListByXPath = By.XPath("//div[@class='alert alert-danger']/ol/li");

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

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = mainErrorTextMessagesNumber </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public IWebElement IWebElementDictionary(int dictionaryId)
        {
            IWebElement createAnAccountText0 = IWebElement(createAnAccountText);
            IWebElement checkGenderMan0 = IWebElement(checkGenderMan);
            IWebElement checkGenderFemale0 = IWebElement(checkGenderFemale);
            IWebElement customerFirstName0 = IWebElement(customerFirstName);
            IWebElement customerLastName0 = IWebElement(customerLastName);
            IWebElement customerEmail0 = IWebElement(customerEmail);
            IWebElement accountPassword0 = IWebElement(accountPassword);
            IWebElement birthDay0 = IWebElement(birthDay);
            IWebElement birthMonth0 = IWebElement(birthMonth);
            IWebElement birthYear0 = IWebElement(birthYear);
            IWebElement checkNewsletter0 = IWebElement(checkNewsletter);
            IWebElement checkSpecialOffers0 = IWebElement(checkSpecialOffers);
            IWebElement addressFirstName0 = IWebElement(addressFirstName);
            IWebElement addressLastName0 = IWebElement(addressLastName);
            IWebElement addressCompanyName0 = IWebElement(addressCompanyName);
            IWebElement addressStreetAndNumber0 = IWebElement(addressStreetAndNumber);
            IWebElement addressApartmentNumber0 = IWebElement(addressApartmentNumber);
            IWebElement addressCity0 = IWebElement(addressCity);
            IWebElement addressState0 = IWebElement(addressState);
            IWebElement addressPostCode0 = IWebElement(addressPostCode);
            IWebElement addressCountry0 = IWebElement(addressCountry);
            IWebElement additionalInfromation0 = IWebElement(additionalInfromation);
            IWebElement phoneHome0 = IWebElement(phoneHome);
            IWebElement phoneMobile0 = IWebElement(phoneMobile);
            IWebElement emailAddresAlias0 = IWebElement(emailAddresAlias);
            IWebElement submitAccountButton0 = IWebElement(submitAccountButton);
            IWebElement mainErrorTextMessagesNumber0 = IWebElement(mainErrorTextMessagesNumber);

            Dictionary<int, IWebElement> IWebElementDictionary = new()
            {
                { 1, createAnAccountText0},
                { 2, checkGenderMan0},
                { 3, checkGenderFemale0},
                { 4, customerFirstName0},
                { 5, customerLastName0},
                { 6, customerEmail0},
                { 7, accountPassword0},
                { 8, birthDay0},
                { 9, birthMonth0},
                { 10, birthYear0},
                { 11, checkNewsletter0},
                { 12, checkSpecialOffers0},
                { 13, addressFirstName0},
                { 14, addressLastName0},
                { 15, addressCompanyName0},
                { 16, addressStreetAndNumber0},
                { 17, addressApartmentNumber0},
                { 18, addressCity0},
                { 19, addressState0},
                { 20, addressPostCode0},
                { 21, addressCountry0},
                { 22, additionalInfromation0},
                { 23, phoneHome0},
                { 24, phoneMobile0},
                { 25, emailAddresAlias0},
                { 26, submitAccountButton0},
                { 27, mainErrorTextMessagesNumber0}
            };
            /*
            KeyValuePair<int, IWebElement> keyValuePair = IWebElementDictionary.ElementAt(dictionaryId);
            IWebElement elementFromDictionary = keyValuePair.Value;
            */
            IWebElement elementFromDictionary = IWebElementDictionary[dictionaryId];
            return elementFromDictionary;
        }

        /// <summary>
        /// <para> By element dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressStateById </para>
        /// <para> 21 = addressPostCode </para>
        /// <para> 22 = addressCountry </para>
        /// <para> 23 = additionalInfromation </para>
        /// <para> 24 = phoneHome </para>
        /// <para> 25 = phoneMobile </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = typeRadioButton </para>
        /// <para> 28 = typeCheckboxBy </para>
        /// <para> 29 = addressStateByXpath </para>
        /// <para> 30 = errorMessagesListByXPath </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public By ElementByDictionary(int dictionaryId)
        {
            By createAnAccountTextBy0 = ElementBy(createAnAccountTextBy);
            By checkGenderManBy0 = ElementBy(checkGenderManBy);
            By checkGenderFemaleBy0 = ElementBy(checkGenderFemaleBy);
            By customerFirstNameBy0 = ElementBy(customerFirstNameBy);
            By customerLastNameBy0 = ElementBy(customerLastNameBy);
            By customerEmailBy0 = ElementBy(customerEmailBy);
            By accountPasswordBy0 = ElementBy(accountPasswordBy);
            By birthDayBy0 = ElementBy(birthDayBy);
            By birthMonthsBy0 = ElementBy(birthMonthsBy);
            By birthYearBy0 = ElementBy(birthYearBy);
            By checkNewsletterBy0 = ElementBy(checkNewsletterBy);
            By checkSpecialOffersBy0 = ElementBy(checkSpecialOffersBy);
            By addressFirstNameBy0 = ElementBy(addressFirstNameBy);
            By addressLastNameBy0 = ElementBy(addressLastNameBy);
            By addressCompanyNameBy0 = ElementBy(addressCompanyNameBy);
            By addressStreetAndNumberBy0 = ElementBy(addressStreetAndNumberBy);
            By addressApartmentNumberBy0 = ElementBy(addressApartmentNumberBy);
            By addressCityBy0 = ElementBy(addressCityBy);
            By addressStateById0 = ElementBy(addressStateById);
            By addressStatesBy0 = ElementBy(addressStatesByXPath);
            By addressPostCodeBy0 = ElementBy(addressPostCodeBy);
            By addressCountryBy0 = ElementBy(addressCountryBy);
            By additionalInfromationBy0 = ElementBy(additionalInfromationBy);
            By phoneHomeBy0 = ElementBy(phoneHomeBy);
            By phoneMobileBy0 = ElementBy(phoneMobileBy);
            By submitAccountButtonBy0 = ElementBy(submitAccountButtonBy);
            By typeRadioButtonBy0 = ElementBy(typeRadioButtonBy);
            By typeCheckboxBy0 = ElementBy(typeCheckboxBy);
            By addressStateByXPath0 = ElementBy(addressStatesByXPath);
            By errorList = ElementBy(errorMessagesListByXPath);

            Dictionary<int, By> elementByDictionary = new ()
            {
                { 1, createAnAccountTextBy0},
                { 2, checkGenderManBy0},
                { 3, checkGenderFemaleBy0},
                { 4, customerFirstNameBy0},
                { 5, customerLastNameBy0},
                { 6, customerEmailBy0},
                { 7, accountPasswordBy0},
                { 8, birthDayBy0},
                { 9, birthMonthsBy0},
                { 10, birthYearBy0},
                { 11, checkNewsletterBy0},
                { 12, checkSpecialOffersBy0},
                { 13, addressFirstNameBy0},
                { 14, addressLastNameBy0},
                { 15, addressCompanyNameBy0},
                { 16, addressStreetAndNumberBy0},
                { 17, addressApartmentNumberBy0},
                { 18, addressCityBy0},
                { 19, addressStateById0},
                { 20, addressStatesBy0},
                { 21, addressPostCodeBy0},
                { 22, addressCountryBy0},
                { 23, additionalInfromationBy0},
                { 24, phoneHomeBy0},
                { 25, phoneMobileBy0},
                { 26, submitAccountButtonBy0},
                { 27, typeRadioButtonBy0},
                { 28, typeCheckboxBy0},
                { 29, addressStateByXPath0},
                { 30, errorList}
               
            };

            By elementBy;
            elementBy = elementByDictionary[dictionaryId];
            return elementBy;
 
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = main error message: "There is/are number error/s" </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        public void ActionElementClick(int dictionaryId)
        {
            IWebElement elementFromDictionary = IWebElementDictionary(dictionaryId);
            CommonFunctions.ElementClick(elementFromDictionary);
        }

        public UserAccountPage GoToUserAccountPage()
        {
            IWebElement elementFromDictionary = IWebElementDictionary(26);
            CommonFunctions.ElementClick(elementFromDictionary);
            return new UserAccountPage(driver);
        }

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = main error message: "There is/are number error/s" </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <param name="textForField"></param>
        public void ActionElementSendText(int dictionaryId, string textForField)
        {
            IWebElement elementFromDictionary = IWebElementDictionary(dictionaryId);
            ActionElementClick(dictionaryId);
            CommonFunctions.SendText(elementFromDictionary, textForField);
        }

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = main error message: "There is/are number error/s" </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        public string ActionElementGetText(int dictionaryId)
        {
            IWebElement elementFromDictionary = IWebElementDictionary(dictionaryId);
            string text = CommonFunctions.GetText(elementFromDictionary);
            return text;
        }

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = main error message: "There is/are number error/s" </para>
        /// <para> ----------------------------------- </para>
        /// <para> deleteAction :</para>
        /// <para> 0 = delete text by clicking backspace </para>
        /// <para> 1 = delete text by cutting it </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <param name="textForField"></param>
        /// <param name="deleteAction"></param>
        public void ActionElementDeletedTextAndSendText(int dictionaryId, string textForField, int deleteAction)
        {
            IWebElement elementFromDictionary = IWebElementDictionary(dictionaryId);

            DeleteText(dictionaryId, deleteAction);
            /*
            if (deleteAction == 0)
            {
                DeleteTextByClickingBackspace(dictionaryId);
            }
                
            if (deleteAction == 1)
            {
                DeleteTextByCuttingIt(dictionaryId);
            }
               */ 

            CommonFunctions.SendText(elementFromDictionary, textForField);
        }

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> 27 = main error message: "There is/are number error/s" </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public string ActionElementGetAttributeValue(int dictionaryId)
        {
            IWebElement element = IWebElementDictionary(dictionaryId);
            By elementBy = ElementByDictionary(dictionaryId);
            string attributeName = "value";
            Thread.Sleep(10000);
            CommonFunctions.WaitUtilElementDisplayBy(elementBy, 10);
            string elementValue = CommonFunctions.GetElmentAttributeValueByCss(element, attributeName);
            TestContext.Progress.WriteLine("elementValue: " + elementValue);
            return elementValue;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// <para> gender = 1 -> dictionaryId -> "Mr." </para>
        /// <para> gender = 2 -> dictionaryId -> "Mr."</para>
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int ChoseGender(int gender)
        {
            return gender switch
            {
                1 => 2,
                2 => 3,
                _ => 3
            };
        }
        /// <summary>
        /// <para> genderNumber = 1 -> "Mr."</para>
        /// <para> genderNumber = 2 -> "Mrs."</para>
        /// </summary>
        /// <param name="gender"></param>
        public void CheckGender(int gender)
        {
            string attributeName = "value";
            string attributeValue = CommonFunctions.ToString(gender);
            By elementBy = ElementByDictionary(27);  
            Thread.Sleep(5000);
            CommonFunctions.ChooseElementFromList(elementBy, attributeName, attributeValue);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        // check click
        /*
        public void CheckNewsletterClick()
        {
            CommonFunctions.ElementClick(TypeCheckboxBy(), 0);

        }

        public void CheckSpecialOffersClick()
        {
            CommonFunctions.ElementClick(TypeCheckboxBy(), 1);

        }
        */
        //--------------------------------------------------------------------------------------------------------------------------------------
        // choose an option from drop down list
        // date of birth

        public void ChooseBirthDayFromDropDownList(string birthDay)
        {
            IWebElement element = IWebElementDictionary(8);
            CommonFunctions.ChooseElementFromList(element, 1, birthDay);
        }

        public void ChooseBirthMonthsFromDropDownList(string birthMonth)
        {
            IWebElement element = IWebElementDictionary(9);
            CommonFunctions.ChooseElementFromList(element, 1, birthMonth);
        }

        public void ChooseBirthYearFromDropDownList(string birthYear)
        {
            IWebElement element = IWebElementDictionary(10);
            CommonFunctions.ChooseElementFromList(element, 1, birthYear);
        }

        public void ChooseBirthDate(string birthDay, string birthMonth, string birthYear)
        {
            ChooseBirthDayFromDropDownList(birthDay);
            ChooseBirthMonthsFromDropDownList(birthMonth);
            ChooseBirthYearFromDropDownList(birthYear);
        }

        public void ChooseState(string stateName)
        {
            IWebElement parentElement = IWebElementDictionary(19);
            By childElement = ElementByDictionary(29);
            CommonFunctions.ChooseElementFromList(parentElement, childElement, stateName);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        public string GetCreateAnAccountText()
        {
            By elementBy = ElementByDictionary(1);
            double time = 10;
            CommonFunctions.WaitUtilElementDisplayBy(elementBy, time);
            IWebElement element = IWebElementDictionary(1);
            string text = CommonFunctions.GetText(element);
            return text;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        public void DeleteTextByClickingBackspace(IWebElement element)
        {
            //IWebElement element = IWebElementDictionary(dictionaryId);
            string attributeName = "value";
            CommonFunctions.DeleteTextByClickingBackspace(element, attributeName);
        }

        /// <summary>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        public void DeleteTextByCuttingIt(IWebElement element)
        {
            //IWebElement element = IWebElementDictionary(dictionaryId);
            CommonFunctions.DeleteTextByCuttingIt(element);
        }

        /// <summary>
        /// <para> 1 = createAnAccountText </para>
        /// <para> 2 = checkGenderMan </para>
        /// <para> 3 = checkGenderFemale </para>
        /// <para> 4 = customerFirstName </para>
        /// <para> 5 = customerLastName </para>
        /// <para> 6 = customerEmail </para>
        /// <para> 7 = accountPassword </para>
        /// <para> 8 = birthDay </para>
        /// <para> 9 = birthMonth </para>
        /// <para> 10 = birthYear </para>
        /// <para> 11 = checkNewsletter </para>
        /// <para> 12 = checkSpecialOffers </para>
        /// <para> 13 = addressFirstName </para>
        /// <para> 14 = addressLastName </para>
        /// <para> 15 = addressCompanyName </para>
        /// <para> 16 = addressStreetAndNumber </para>
        /// <para> 17 = addressApartmentNumber </para>
        /// <para> 18 = addressCity </para>
        /// <para> 19 = addressState </para>
        /// <para> 20 = addressPostCode </para>
        /// <para> 21 = addressCountry </para>
        /// <para> 22 = additionalInfromation </para>
        /// <para> 23 = phoneHome </para>
        /// <para> 24 = phoneMobile </para>
        /// <para> 25 = emailAddresAlias </para>
        /// <para> 26 = submitAccountButton </para>
        /// <para> ----------------------------------- </para>
        /// <para> deleteAction :</para>
        /// <para> 0 = delete text by clicking backspace </para>
        /// <para> 1 = delete text by cutting it </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        public void DeleteText(int dictionaryId, int deleteAction)
        {
            IWebElement element = IWebElementDictionary(dictionaryId);
 
            if (deleteAction == 0)
            {
                DeleteTextByClickingBackspace(element);
            }

            if (deleteAction == 1)
            {
                DeleteTextByCuttingIt(element);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // error list

        /// <summary>
        /// <para> dictionaryId: </para>
        /// <para> 1 = You must register at least one phone number </para>
        /// <para> 2 = lastname is required </para>
        /// <para> 3 = firstname is required </para>
        /// <para> 4 = email is required</para>
        /// <para> 5 = passwd is required </para>
        /// <para> 6 = id_country is required </para>
        /// <para> 7 = address1 is required </para>
        /// <para> 8 = city is required </para>
        /// <para> 9 = Country cannot be loaded with address->id_country </para>
        /// <para> 10 = Country is invalid </para>
        /// <para> 11 = alias is required. </para>
        /// <para> 12 = This country requires you to choose a State. </para>
        /// <para> 13 = The Zip/Postal code you've entered is invalid. It must follow this format: 00000 </para>
        /// <para> 14 = Invalid date of birth </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public static string ErrorDictionary(int dictionaryId)
        {
            //Dictionary<int, string> errorDictionary = new Dictionary<int, string>()
             Dictionary<int, string> errorDictionary = new()
            {
                {1, "You must register at least one phone number."},
                {2, "lastname is required."},
                {3, "firstname is required."},
                {4, "email is required."},
                {5, "passwd is required."},
                {6, "id_country is required."},
                {7, "address1 is required."},
                {8, "city is required."},
                {9, "Country cannot be loaded with address->id_country"},
                {10, "Country is invalid"},
                {11, "alias is required."},
                {12, "This country requires you to choose a State."},
                {13, "The Zip/Postal code you've entered is invalid. It must follow this format: 00000"},
                {14, "Invalid date of birth"}
            };

            string error = errorDictionary[dictionaryId];    

            return error;
        }

        public static string ErrorNumberSentence(int number)
        {
            //string errorNumberText;
            if (number == 1)
            {
                return _ = $"There is {number} error";
            }
            else 
            {
                return _ = $"There are {number} errors";
            }

        }

        public string[] ErrorWebList()
        {
            By errorList = ElementByDictionary(30);
            string[] errorsList = CommonFunctions.ArrayString(errorList);
            return errorsList;
        }




    }
}
