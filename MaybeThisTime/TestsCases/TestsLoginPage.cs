using MaybeThisTime.Common;
using MaybeThisTime.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using MaybeThisTime.VariousNeeded.CreateAnAccount;
using SoftAssertions;

namespace MaybeThisTime.TestsCases
{
    public class TestsLoginPage : Base
    {

        private SoftAssertion _softAssertion;

        [SetUp]
        public void SetUp()
        {
            _softAssertion = new SoftAssertion();
        }


        [Test, TestCaseSource(nameof(TestDataConfigForLoginValidationToAccountWrongData))]

        public void Test1(string registeredEmail, string registeredPassword, string expectedRegisteredError)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.LogInAccount(registeredEmail, registeredPassword, false);
            string webErrorMessage = lp.GetErrorMessageForAlresdyRegisteredAccount();

            string message = "Wrong error message when data for login are not correct. ";
            _softAssertion.Add(message, expectedRegisteredError, webErrorMessage);
        }



        [Test, TestCaseSource(nameof(TestDataConfigForLoginValidationToAccountCorrectData))]
        public void Test2(string registeredEmail, string registeredPassword)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.LogInAccount(registeredEmail, registeredPassword, true);
            UserAccountAfterLoggingInPage uaalip = lp.GoToUserAccountAfterLoggingInPage();
            string expectedText = "Sign out";
            string webText = uaalip.GetLogoutButtonText();

            string message = "Logging into the account failed. ";
            _softAssertion.Add(message, expectedText, webText);
        }

        [Test, TestCaseSource(nameof(TestDataConfigForCreateAccount))]
        public void Test3(string email, string expectedSignInErrorEmail)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            lp.CreateAccountFieldClick();
            lp.AddNewEmailIntoCreateAccountFiledByGivenText(email);
            lp.SubmitCreateAccountButtonClick();
            string webErrorMessage = lp.GetErrorMessageForCreateAccount();

            string message = "Test field. ";
            _softAssertion.Add(message, expectedSignInErrorEmail, webErrorMessage);
        }


        [Test]
        public void Test4()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            LoginPage lp = mp.GoToLoginPage();
            string originalWindow = CommonFunctions.GetCurrentWindow();
            NewAccountGetEmailForRegistrationPage nagefrp = lp.GoToNewAccountGetEmailForRegistrationPage();
            nagefrp.GetEmailForNewAccount();
            LoginPage lp2 = nagefrp.GoBackToLoginPage(originalWindow);
            lp2.PasteCopiedEmailAddress();
            CreateAccountPage cap = lp.GoToCreateAccountPage();
            string expectedText = "Create an account";
            string webText = cap.GetCreateAnAccountText();

            string message = "Test field. ";
            _softAssertion.Add(message, expectedText, webText);
        }






        //--------------------------------------------------------------------------------------------------------------------------------------
        private static IEnumerable<TestCaseData> TestDataConfigForLoginValidationToAccountWrongData()
        {
            // right data for email and password
            string correctEmail = "MTTAutomationPractice@test.com";
            string correctPassword = "12345*";

            // wrong data for email and password
            string wrongEmail = "testTest@gmail.com";
            string wrongEmailv2 = "testTest";
            string wrongPassword = "36256988";
            string wrongPasswordv2 = "qq";

            // empty emial and password
            string emptyEmail = "";
            string emptyPassword = "";

            // notification when login failed:
            //string SignInErrorLineOne = "There is 1 error";

            // ----------------------------------------------------------
            // expected error message

            // notification when only email is wrong
            string expectedSignInErrorEmail = "Invalid email address.";

            // notification when only passowrd is wrong
            string expectedSignInErrorPassword = "Invalid password.";

            // notification when the email or password is wrong,
            string expectedSingInErrorAuthentication = "Authentication failed.";

            // notification, when the email field is empty
            string expectedSingInErrorEmailEmpty = "An email address required.";

            // notification, when the email field is filled with correct address mail and the password is empty
            string expectedSingInErrorPasswordEmpty = "Password is required.";

            // ----------------------------------------------------------
            // test

            // v1 - wrong email and correct password
            yield return new TestCaseData(wrongEmail, correctPassword, expectedSingInErrorAuthentication);

            // v1 - correct email and wrong password
            yield return new TestCaseData(correctEmail, wrongPassword, expectedSingInErrorAuthentication);

            //----------------------------------------------------------
            // v2 - wrong email and correct password
            yield return new TestCaseData(wrongEmailv2, correctPassword, expectedSignInErrorEmail);

            // v2 - wrong email and wrong password
            yield return new TestCaseData(wrongEmailv2, wrongPasswordv2, expectedSignInErrorEmail);

            // v2 - correct email and wrong password
            yield return new TestCaseData(correctEmail, wrongPasswordv2, expectedSignInErrorPassword);

            //----------------------------------------------------------
            // v3 - empty email address
            yield return new TestCaseData(emptyEmail, correctPassword, expectedSingInErrorEmailEmpty);

            // v3 - empty password address
            yield return new TestCaseData(correctEmail, emptyPassword, expectedSingInErrorPasswordEmpty);

            // v3 - empty email and empty password 
            yield return new TestCaseData(correctEmail, emptyPassword, expectedSingInErrorEmailEmpty);
        }

        private static IEnumerable<TestCaseData> TestDataConfigForLoginValidationToAccountCorrectData()
        {
            string correctEmail1 = "MTTAutomationPractice@MTTAutomationPractice.com";
            string correctPassword1 = "MTT1234*";
            yield return new TestCaseData(correctEmail1, correctPassword1);
        }

        private static IEnumerable<TestCaseData> TestDataConfigForCreateAccount()
        {
            // empty emial
            string emptyEmail = "";

            // emial - an account with this email has already been registered
            string accountRegistered = "";

            // wrong emial
            string wrongEmailv1 = "aaaa";
            string wrongEmailv2 = "aaaa@";
            string wrongEmailv3 = "aaaa@pl";
            string wrongEmailv4 = "aaaa@.pl";
            string wrongEmailv5 = "aaaa@com.pl";
            string wrongEmailv6 = "@com.pl";

            // ----------------------------------------------------------
            // expected error message

            // notification when filed for email is wrong  or empty
            string expectedSignInErrorMessage = "Invalid email address.";

            // notification when an account with this email has already benn registered
            string expectedSignInErrorMessageForAccountRegistered = "An account using this email address has already been registered. Please enter a valid password or request a new one. ";

            // ----------------------------------------------------------
            // test
            yield return new TestCaseData(emptyEmail, expectedSignInErrorMessage);
            yield return new TestCaseData(accountRegistered, expectedSignInErrorMessageForAccountRegistered);
            yield return new TestCaseData(wrongEmailv1, expectedSignInErrorMessage);
            yield return new TestCaseData(wrongEmailv2, expectedSignInErrorMessage);
            yield return new TestCaseData(wrongEmailv3, expectedSignInErrorMessage);
            yield return new TestCaseData(wrongEmailv4, expectedSignInErrorMessage);
            yield return new TestCaseData(wrongEmailv5, expectedSignInErrorMessage);
            yield return new TestCaseData(wrongEmailv6, expectedSignInErrorMessage);

        }





        /*
    [TearDown]
    public void CloseBrowser()
    {
        TestContext.Progress.WriteLine("Close Browser 2");
    }
    */
    }
}
