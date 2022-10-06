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
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            string originalWindow = CommonFunctions.GetCurrentWindow();
            NewAccountGetEmailForRegistrationPage nagefrp = lp.GoToNewAccountGetEmailForRegistrationPage();
            nagefrp.GetEmailForNewAccount();
            LoginPage lp2 = nagefrp.GoBackToLoginPage(originalWindow);
            lp2.PasteCopiedEmailAddress();
            CreateAccountPage cap = lp.GoToCreateAccountPage();
            // cap.CheckGenderMrs();
            string birthDay = "29";
            string birthMonth = "5";
            string birthYear = "1939";
            //cap.ChooseBirthDate(birthDay, birthMonth, birthYear);
            Thread.Sleep(10000);
            //cap.CheckNewsletterClick();
            //cap.CheckSpecialOffersClick();
            //cap.ChooseElementFromList2();
            string stateName = "Utah";
            string expectedStateName = "";
           // cap.ChooseStateFromDropDownList(stateName);
            // cap.DeleteCustomerEmail();
            //cap.DeleteTextForAddressAlias();

            _softAssertion.Add("test", "Utah1", stateName);
        }

        [Test]
        public void Test2()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.AddNewEmailIntoCreateAccountFieldFromEmailGenerator();
            CreateAccountPage cap = lp.GoToCreateAccountPage();
            cap.CheckGenderMrs();
            cap.TestDictionary(0, "imie");
            //cap.TestDictionary(1, "nazwisko");


        }
    }
}
