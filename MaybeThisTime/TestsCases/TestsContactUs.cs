using MaybeThisTime.Common;
using MaybeThisTime.PageObjects;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using SoftAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeThisTime.TestsCases
{
    public class TestsContactUs : Base
    {

        private SoftAssertion _softAssertion;

        [SetUp]
        public void SetUp()
        {
            _softAssertion = new SoftAssertion();
        }

        [Test, Order(1), Category("ContactUs")]
        [TestCase(TestName = "1. Sending a message without error.",
            Description = "Sending a message without error. Checking information about a successfully sent message.")]
        public void Test1()
        {
            string expectedEmail = CommonFunctions.GenerateEmailAddress();
            string expectedFileName = "Screenshot.jpg";
            string expectedOrderReference = "OR/2022/11/06/0001";
            string expectedMessageSentSuccessfully = ContactUsPage.DictionaryActionCompletedSuccessfully(1);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.ChooseSubjectHeadingFromDropDownList(2);
            cup.AddEmail(expectedEmail);          
            cup.AddOrderReference(expectedOrderReference);
            cup.AddFile(expectedFileName);
            cup.AddMessage();
            cup.SendClick();
            string webMessageSentSuccessfully = cup.GetText(9);

            _softAssertion.Add("test", expectedMessageSentSuccessfully, webMessageSentSuccessfully);
        }

        [Test, Order(2), Category("ContactUs")]
        [TestCase(TestName = "2. Checking information after choosing 'customer service' for the subject heading.",
            Description = "Correct information: 'For any question about a product, an order'.")]
        public void Test2()
        {
            string expectedInfoCustomerService = ContactUsPage.DictionarySubjectHeadingInformation(1);
            bool expectedIsCustomerServiceInfoVisible = true;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.ChooseSubjectHeadingFromDropDownList(2);
            bool webIsCustomerServiceInfoVisible =  cup.IsCorrectInformationVisible(2);
            string webInfoCustomerService = cup.GetText(10);

            _softAssertion.Add("test", expectedIsCustomerServiceInfoVisible, webIsCustomerServiceInfoVisible);
            _softAssertion.Add("test", expectedInfoCustomerService, webInfoCustomerService);
        }

        [Test, Order(3), Category("ContactUs")]
        [TestCase(TestName = "3. Checking information after choosing 'webmaster' for the subject heading.",
            Description = "Correct information: 'If a technical problem occurs on this website'.")]
        public void Test3()
        {
            string expectedInfoWebmaster = ContactUsPage.DictionarySubjectHeadingInformation(2);
            bool expectedIsWebmasterInfoVisible = true;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.ChooseSubjectHeadingFromDropDownList(1);
            bool webIsWebmasterInfoVisible = cup.IsCorrectInformationVisible(1);
            string webInfoWebmaster = cup.GetText(11);

            _softAssertion.Add("test", expectedIsWebmasterInfoVisible, webIsWebmasterInfoVisible);
            _softAssertion.Add("test", expectedInfoWebmaster, webInfoWebmaster);
        }

        [Test, Order(4), Category("ContactUs")]
        [TestCase(TestName = "4. Checking information after choosing 'webmaster' -> choosing 'choose' for the subject heading.",
             Description = "Correct information: nothing is display.")]
        public void Test4()
        {
            string expecteInfoChoose  = ContactUsPage.DictionarySubjectHeadingInformation(3);
            bool expectedIsWebmasterInfoVisible = false;
            bool expectedIsCustomerServiceInfoVisible = false;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.ChooseSubjectHeadingFromDropDownList(1);
            cup.ChooseSubjectHeadingFromDropDownList(0);
            bool webIsCustomerServiceInfoVisible = cup.IsCorrectInformationVisible(2);
            bool webIsWebmasterInfoVisible = cup.IsCorrectInformationVisible(1);
            string webInfoChoose = cup.GetText(12);

            _softAssertion.Add("test", expectedIsCustomerServiceInfoVisible, webIsCustomerServiceInfoVisible);
            _softAssertion.Add("test", expectedIsWebmasterInfoVisible, webIsWebmasterInfoVisible);
            _softAssertion.Add("test", expecteInfoChoose, webInfoChoose);
        }

        [Test, Order(5), Category("ContactUs")]
        [TestCase(TestName = "5. Checking the name of the file which was added.",
            Description = "")]
        public void Test5()
        {
            string expectedFileName = "Screenshot.jpg";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.AddFile(expectedFileName);
            string webFileName = cup.GetText(6);

            _softAssertion.Add("test", expectedFileName, webFileName);

        }

        [Test, Order(6), Category("ContactUs")]
        [TestCase(TestName = "6. Checking ",
            Description = "")]
        public void Test6()
        {
            string expectedFileName = "Screenshot.jpg";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            MainPage mp = new MainPage(driver);
            ContactUsPage cup = mp.GoToContactUsPage();

            cup.AddFile(expectedFileName);
            string webFileName = cup.GetText(6);

            _softAssertion.Add("test", expectedFileName, webFileName);

        }










    }
}
