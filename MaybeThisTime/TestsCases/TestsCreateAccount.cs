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
        
        [Test]
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
            string expectedAddressPostCode = "02019";
            string expectedAdditionalInfromation = "Today is 24.";
            string expectedPhoneHome = "33 12 012 012";
            string expectedPhoneMobile = "123 456 789";
            string expectedEmailAddressAlias = CommonFunctions.GenerateEmailAddress();
            string expectedSignOutButtonText = "Sign out";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.TypeRegisteredEmail(expectedEmailAddressAlias);      
 
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

        [Test]
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


        [Test]
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
;
            TestContext.Progress.WriteLine("webEmailAddress: " + webEmailAddress);

            _softAssertion.Add("test", expectedEmailAddress, webEmailAddress);

        }
    }
}
