using MaybeThisTime.Common;
using MaybeThisTime.PageObjects;
using MaybeThisTime.VariousNeeded.CreateAnAccount;
using NUnit.Framework;
using SoftAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using SharpCompress.Readers.Tar;

namespace MaybeThisTime.TestsCases
{
    public class TestsCreateAccount : Base
    {

        private SoftAssertion _softAssertion;

        [SetUp]
        public void SetUp()
        {
            _softAssertion = new SoftAssertion();
        }
        
        [Test, Order(1), Category("CreateAccount")]
        [TestCase(TestName = "1. Creating a new account without errors.", 
            Description = "Creating a new account - checking if after giving all the necessary data" +
            " is possible to register an account without any errors")]
        public void Test1()
        {
            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";          
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();
            string expectedSignOutButtonText = "Sign out";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);      
 
            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            UserAccountPage uap = cap.GoToUserAccountPage();
            string webSignOutButtonText = uap.GetLogoutButtonText();

            _softAssertion.Add("test", expectedSignOutButtonText, webSignOutButtonText);
        }

        [Test, Order(2), Category("CreateAccount")]
        [TestCase(TestName = "2. Creating a new account - checking first name and last name in the address section.", 
            Description = "Creating a new account - checking if given first name and last name in personal information" +
            " are automatically added/displayed for first name and last name in the address section.")]
        public void Test2()
        {
            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();

            string originalWindow = CommonFunctions.GetCurrentWindow();
            NewAccountGetEmailForRegistrationPage nagefrp = lp.GoToNewAccountGetEmailForRegistrationPage();
            nagefrp.GetEmailForNewAccount();
            LoginPage lp2 = nagefrp.GoBackToLoginPage(originalWindow);
            lp2.PasteCopiedEmailAddress();

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);

            string webAddressFirstName = cap.ActionElementGetAttributeValue(13);
            string webAddressLastName = cap.ActionElementGetAttributeValue(14);

            _softAssertion.Add("test", expectedFirstName, webAddressFirstName);
            _softAssertion.Add("test", expectedLastName, webAddressLastName);

        }


        [Test, Order(3), Category("CreateAccount")]
        [TestCase(TestName = "3. Creating a new account - checking email address in section personal information.",
            Description = "Creating a new account - checking if the given email address in section personal information" +
            " is the same as we typed in the login page.")]
        public void Test3()
        {
            string expectedEmailAddress = CommonFunctions.GenerateEmailAddress();
            TestContext.Progress.WriteLine("expectedEmailAddress: " + expectedEmailAddress);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.RandomEmailAddress(expectedEmailAddress);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            string webEmailAddress = cap.ActionElementGetAttributeValue(6);

            _softAssertion.Add("test", expectedEmailAddress, webEmailAddress);

        }
 
        [Test, Order(4), Category("CreateAccount")]
        [TestCase(TestName = "4. Creating a new account - checking error messages when all field are empty.",
            Description = "Creating a new account - checking error message when all field are empty.")]
        public void Test4()
        {
            int errorNumber = 10;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedCustomerEmail = CommonFunctions.GenerateEmailAddress();
            string expectedErrorMessagePhone = CreateAccountPage.ErrorDictionary(1);
            string expectedErrorMessageLastname = CreateAccountPage.ErrorDictionary(2);
            string expectedErrorMessageFirstname = CreateAccountPage.ErrorDictionary(3);
            string expectedErrorMessageCustomerEmail = CreateAccountPage.ErrorDictionary(4);
            string expectedErrorMessagePassword = CreateAccountPage.ErrorDictionary(5);
            //string expectedErrorMessageIdCountry = CreateAccountPage.ErrorDictionary(6);
            string expectedErrorMessageAdress1 = CreateAccountPage.ErrorDictionary(7);
            string expectedErrorMessageCity = CreateAccountPage.ErrorDictionary(8);
           // string expectedErrorMessageCountry = CreateAccountPage.ErrorDictionary(9);
           // string expectedErrorMessageCountryInvalid = CreateAccountPage.ErrorDictionary(10);
            string expectedErrorMessageAliasEmail = CreateAccountPage.ErrorDictionary(11);
            string expectedErrorMessageStateRequired = CreateAccountPage.ErrorDictionary(12);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedCustomerEmail);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.ActionElementDeletedTextAndSendText(25, expectedCustomerEmail, 0);
            cap.DeleteText(6, 0);
            cap.DeleteText(25, 1);
            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();

            string webErrorMessagePhone = webErrorsList[0];
            string webErrorMessageLastname = webErrorsList[1];
            string webErrorMessageFirstname = webErrorsList[2];
            string webErrorMessageCustomerEmail = webErrorsList[3];
            string webErrorMessagePassword = webErrorsList[4];
            string webErrorMessageAliasEmail = webErrorsList[5];
            string webErrorMessageAdress1 = webErrorsList[6];
            string webErrorMessageCity = webErrorsList[7];
            string webErrorMessageZipCode = webErrorsList[8];
            string webErrorMessageStateRequired = webErrorsList[9];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessagePhone, webErrorMessagePhone);
            _softAssertion.Add("test", expectedErrorMessageLastname, webErrorMessageLastname);
            _softAssertion.Add("test", expectedErrorMessageFirstname, webErrorMessageFirstname);
            _softAssertion.Add("test", expectedErrorMessageCustomerEmail, webErrorMessageCustomerEmail);
            _softAssertion.Add("test", expectedErrorMessagePassword, webErrorMessagePassword);
            _softAssertion.Add("test", expectedErrorMessageAliasEmail, webErrorMessageAliasEmail);
            _softAssertion.Add("test", expectedErrorMessageAdress1, webErrorMessageAdress1);
            _softAssertion.Add("test", expectedErrorMessageCity, webErrorMessageCity);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
            _softAssertion.Add("test", expectedErrorMessageStateRequired, webErrorMessageStateRequired);
        }

        [Test, Order(5), Category("CreateAccount")]
        [TestCase(TestName = "5. Creating a new account - checking error messages when the day of birth is not chosen.",
            Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
            "Month and year are chosen.")]
        public void Test5()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthMonthsFromDropDownList(expectedBirthMonth);
            cap.ChooseBirthYearFromDropDownList(expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(6), Category("CreateAccount")]
        [TestCase(TestName = "6. Creating a new account - checking error message when the month of birth is not chosen.",
            Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
            "Day and year are chosen.")]
        public void Test6()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDayFromDropDownList(expectedBirthDay);
            cap.ChooseBirthYearFromDropDownList(expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(7), Category("CreateAccount")]
        [TestCase(TestName = "7. Creating a new account - checking error message when the year of birth is not chosen.",
            Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
            "Day and month are chosen.")]
        public void Test7()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDayFromDropDownList(expectedBirthDay);
            cap.ChooseBirthMonthsFromDropDownList(expectedBirthMonth);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(8), Category("CreateAccount")]
        [TestCase(TestName = "8. Creating a new account - checking error message when the day of birth is chosen.",
            Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
            "Month and year are not chosen.")]
        public void Test8()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDayFromDropDownList(expectedBirthDay);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(9), Category("CreateAccount")]
        [TestCase(TestName = "9. Creating a new account - checking error message when the month of birth is chosen.",
            Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
            "Day and year are not chosen.")]
        public void Test9()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthMonth = "5";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthMonthsFromDropDownList(expectedBirthMonth);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(10), Category("CreateAccount")]
        [TestCase(TestName = "10. Creating a new account - checking error message when the year of birth is chosen.",
           Description = "Creating a new account - checking error message when the day of birth is not chosen. " +
           "Day and month are not chosen.")]
        public void Test10()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageBirthDay = CreateAccountPage.ErrorDictionary(14);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(0, 0);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthYearFromDropDownList(expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageBirthDay = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageBirthDay, webErrorMessageBirthDay);
        }

        [Test, Order(11), Category("CreateAccount")]
        [TestCase(TestName = "11. Creating a new account - checking error message when filed for zip/ postal code is empty.",
            Description = "Creating a new account - checking error message when filed for zip/ postal code is empty")]
        public void Test11()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode= CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }
 
        [Test, Order(12), Category("CreateAccount")]
        [TestCase(TestName = "12. Creating a new account - checking error message when zip/ postal code is too short.",
            Description = "Creating a new account - checking error message when zip/ postal code is too short. " +
            "Text contains only numbers.")]
        public void Test12()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(1, 4);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }

        [Test, Order(13), Category("CreateAccount")]
        [TestCase(TestName = "13. Creating a new account - checking error message when zip/ postal code is too long.",
            Description = "Creating a new account - checking error message when zip/ postal code is too long. " +
            "Text contains only numbers.")]
        public void Test13()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(1, 10);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }

        [Test, Order(14), Category("CreateAccount")]
        [TestCase(TestName = "14. Creating a new account - checking error message when zip/ postal code is too short.",
            Description = "Creating a new account - checking error message when zip/ postal code is too short. " +
            "Text contains only letters.")]
        public void Test14()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(2, 3);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }

        [Test, Order(15), Category("CreateAccount")]
        [TestCase(TestName = "15. Creating a new account - checking error message when zip/ postal code is too long.",
           Description = "Creating a new account - checking error message when zip/ postal code is too long. " +
           "Text contains only letters.")]
        public void Test15()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(2, 7);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }


        [Test, Order(16), Category("CreateAccount")]
        [TestCase(TestName = "16. Creating a new account - checking error message when zip/ postal code is too short.",
            Description = "Creating a new account - checking error message when zip/ postal code is too short. " +
            "Text contains digits and letters.")]
        public void Test16()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(2, 4);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }

        [Test, Order(17), Category("CreateAccount")]
        [TestCase(TestName = "17. Creating a new account - checking error message when zip/ postal code is too long.",
             Description = "Creating a new account - checking error message when zip/ postal code is too long. " +
             "Text contains digits and letters.")]
        public void Test17()
        {
            int errorNumber = 1;
            string expectedErrorsNumber = CreateAccountPage.ErrorNumberSentence(errorNumber);
            string expectedErrorMessageZipCode = CreateAccountPage.ErrorDictionary(13);

            string expectedFirstName = "Lilli";
            string expectedLastName = "Flower";
            string expectedPassword = "test!qwer!";
            string expectedBirthDay = "29";
            string expectedBirthMonth = "5";
            string expectedBirthYear = "1939";
            string expectedAddressCompanyName = "Muminki";
            string expectedAddressStreetAndNumber = "Tove Jansson 1939";
            string expectedAddressApartmentNumber = "1945";
            string expectedAddressCity = "Valley somewhere in Finland";
            string expectedAddressStateName = "Utah";
            string expectedAddressPostCode = CommonFunctions.GenerateZipCode(3, 7);
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(expectedEmailAddressAlias);

            CreateAccountPage cap = lp.GoToCreateAccountPage();

            cap.CheckGender(2);
            cap.ActionElementSendText(4, expectedFirstName);
            cap.ActionElementSendText(5, expectedLastName);
            cap.ActionElementSendText(7, expectedPassword);

            cap.ChooseBirthDate(expectedBirthDay, expectedBirthMonth, expectedBirthYear);

            cap.ActionElementClick(11);
            cap.ActionElementClick(12);

            cap.ActionElementSendText(15, expectedAddressCompanyName);
            cap.ActionElementSendText(16, expectedAddressStreetAndNumber);
            cap.ActionElementSendText(17, expectedAddressApartmentNumber);
            cap.ActionElementSendText(18, expectedAddressCity);
            cap.ChooseState(expectedAddressStateName);
            cap.ActionElementSendText(20, expectedAddressPostCode);
            cap.ActionElementSendText(22, expectedAdditionalInfromation);
            cap.ActionElementSendText(23, expectedPhoneHome);
            cap.ActionElementSendText(24, expectedPhoneMobile);
            cap.ActionElementDeletedTextAndSendText(25, expectedEmailAddressAlias, 0);

            cap.ActionElementClick(26);

            string webErrorsNumber = cap.ActionElementGetText(27);
            string[] webErrorsList = cap.ErrorWebList();
            string webErrorMessageZipCode = webErrorsList[0];

            _softAssertion.Add("test", expectedErrorsNumber, webErrorsNumber);
            _softAssertion.Add("test", expectedErrorMessageZipCode, webErrorMessageZipCode);
        }
    }
}
