using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using AngleSharp.Dom;
using AventStack.ExtentReports.Gherkin.Model;
using Castle.Core.Resource;
using MaybeThisTime.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MaybeThisTime.PageObjects
{
    public class ContactUsPage
    {
        private IWebDriver driver;

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------

        [FindsBy(How = How.Id, Using = "id_contact")]
        private IWebElement subjectHeading;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailAddress;

        [FindsBy(How = How.Id, Using = "id_order")]
        private IWebElement orderReferance;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement message;

        // ---
        [FindsBy(How = How.Id, Using = "fileUpload")]
        private IWebElement attachFilePlusButtonChooseFile;

        [FindsBy(How = How.XPath, Using = "//input[@id='fileUpload']/following-sibling::span[@class='filename']")]
        private IWebElement attachFileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='fileUpload']/following-sibling::span[@class='action']")]
        private IWebElement buttonChooseFile;

        [FindsBy(How = How.Id, Using = "submitMessage")]
        private IWebElement buttonSend;

        //-------------------------------------------------------------------------
        // message successfully sent

        [FindsBy(How = How.XPath, Using = "//p[@class='alert alert-success']")]
        private IWebElement messageSentSuccessfully;


        //-------------------------------------------------------------------------
        // info for subject heading
        [FindsBy(How = How.Id, Using = "desc_contact0")]
        private IWebElement infoChoose;

        [FindsBy(How = How.Id, Using = "desc_contact2")]
        private IWebElement infoCustomerService;

        [FindsBy(How = How.Id, Using = "desc_contact1")]
        private IWebElement infoWebmaster;


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
        /// <para> 1 = subjectHeading </para>
        /// <para> 2 = emailAddress </para>
        /// <para> 3 = orderReferance </para>
        /// <para> 4 = message </para>
        /// <para> 5 = attachFilePlusButtonChooseFile </para>
        /// <para> 6 = attachFileField </para>
        /// <para> 7 = buttonChooseFile </para>
        /// <para> 8 = buttonSend </para>
        /// <para> 9 = messageSentSuccessfully </para>
        /// <para> 10 = infoCustomerService </para>
        /// <para> 11 = infoWebmaster </para>
        /// <para> 12 = infoChoose </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public IWebElement DictionaryIWebElement(int dictionaryId)
        {
            IWebElement subjectHeading0 = IWebElement(subjectHeading);
            IWebElement emailAddress0 = IWebElement(emailAddress);
            IWebElement orderReferance0 = IWebElement(orderReferance);
            IWebElement message0 = IWebElement(message);
            IWebElement attachFilePlusButtonChooseFile0 = IWebElement(attachFilePlusButtonChooseFile);
            IWebElement attachFileField0 = IWebElement(attachFileField);
            IWebElement buttonChooseFile0 = IWebElement(buttonChooseFile);
            IWebElement buttonSend0 = IWebElement(buttonSend);
            IWebElement messageSentSuccessfully0 = IWebElement(messageSentSuccessfully);
            IWebElement infoCustomerService0 = IWebElement(infoCustomerService);
            IWebElement infoWebmaster0 = IWebElement(infoWebmaster);
            IWebElement infoChoose0 = IWebElement(infoChoose);

            Dictionary<int, IWebElement> DictionaryIWebElement = new Dictionary<int, IWebElement>()
            {
                {1, subjectHeading0},
                {2, emailAddress0},
                {3, orderReferance0},
                {4, message0},
                {5, attachFilePlusButtonChooseFile0},
                {6, attachFileField0},
                {7, buttonChooseFile0},
                {8, buttonSend0},
                {9, messageSentSuccessfully0},
                {10, infoCustomerService0},
                {11, infoWebmaster0},
                {12, infoChoose0},
            };

            IWebElement elementFromDictionary = DictionaryIWebElement[dictionaryId];
            return elementFromDictionary;
        }

        /// <summary>
        /// <para> dictionaryId: </para>
        /// <para> 1 = customerServiceInfo </para>
        /// <para> 2 = webmasterInfo </para>
        /// <para> 3 = infoChoose </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public static string DictionarySubjectHeadingInformation(int dictionaryId)
        {
            string customerServiceInfo = "For any question about a product, an order";
            string webmasterInfo = "If a technical problem occurs on this website";
            //string infoChoose = "&nbsp;";
            string infoChoose = "";

            Dictionary<int, string> DictionarySubjectHeadingInformation = new Dictionary<int, string>()
            {
                { 1, customerServiceInfo },
                { 2, webmasterInfo },
                { 3, infoChoose}
            };

            string text = DictionarySubjectHeadingInformation[dictionaryId];
            return text;
        }

        /// <summary>
        /// <para> dictionaryId: </para>
        /// <para> 1 = messageSendSuccessfully</para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public static string  DictionaryActionCompletedSuccessfully(int dictionaryId)
        {
            string messageSendSuccessfully = "Your message has been successfully sent to our team.";

            Dictionary<int, string> DictionaryActionCompletedSuccessfully = new Dictionary<int, string>()
            {
                {1, messageSendSuccessfully }
            };

            string text = DictionaryActionCompletedSuccessfully[dictionaryId];
            return text;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------
        // Subject Heading

        /// <summary>
        /// <para> optionFromList: </para>
        /// <para> 0 = -- Choose -- </para>
        /// <para> 1 = Webmaster </para>
        /// <para> 2 = Customer service </para>
        /// </summary>
        /// <param name="optionFromList"></param>
        public void ChooseSubjectHeadingFromDropDownList(int optionFromList)
        {
            string optionFromListString = CommonFunctions.ToString(optionFromList);
            IWebElement element = DictionaryIWebElement(1);
            CommonFunctions.ChooseElementFromList(element, 1, optionFromListString);
        }

        /// <summary>
        /// <para> optionFromList: </para>
        /// <para> 1 = Webmaster </para>
        /// <para> 2 = Customer service </para>
        /// </summary>
        /// <param name="optionFromList"></param>
        public IWebElement ChooseInformationForSubjectHeading(int optionFromList)
        {
            IWebElement element;
            if (optionFromList == 1)
            {
                return element = DictionaryIWebElement(11);
            }
            else
            {
                return element = DictionaryIWebElement(10);
            }
        }

        /// <summary>
        /// <para> optionFromList: </para>
        /// <para> 0 = -- Choose -- </para>
        /// <para> 1 = Webmaster </para>
        /// <para> 2 = Customer service </para>
        /// </summary>
        /// <param name="optionFromList"></param>
        public bool IsCorrectInformationVisible(int optionFromList)
        {
            IWebElement element = ChooseInformationForSubjectHeading(optionFromList);
            bool isCorrectInformationVisible = CommonFunctions.IsElementDisplayed(element);

            TestContext.Progress.WriteLine("isCorrectInformationVisible: " + isCorrectInformationVisible);

            return isCorrectInformationVisible;
        }

        /// <summary>
        /// <para> IWebElement dictionaryId: </para>
        /// <para> 1 = subjectHeading </para>
        /// <para> 2 = emailAddress </para>
        /// <para> 3 = orderReferance </para>
        /// <para> 4 = message </para>
        /// <para> 5 = attachFilePlusButtonChooseFile </para>
        /// <para> 6 = attachFileField </para>
        /// <para> 7 = buttonChooseFile </para>
        /// <para> 8 = buttonSend </para>
        /// <para> 9 = messageSentSuccessfully </para>
        /// <para> 10 = infoCustomerService </para>
        /// <para> 11 = infoWebmaster </para>
        /// <para> 12 = infoChoose </para>
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public string GetText(int dictionaryId)
        {
            IWebElement element = DictionaryIWebElement(dictionaryId);
            string text = CommonFunctions.GetText(element);
            return text;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------

        public void ElementClick(IWebElement element)
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public void AddEmail(string emailAddress)
        {
            IWebElement element = DictionaryIWebElement(2);
            CommonFunctions.ElementClick(element);
            CommonFunctions.SendText(element, emailAddress);
        }

        public void AddOrderReference(string orderReference)
        {
            IWebElement element = DictionaryIWebElement(3);
            CommonFunctions.ElementClick(element);
            CommonFunctions.SendText(element, orderReference);
        }

        public void AddFile(string fileName)
        {
            IWebElement element = DictionaryIWebElement(5);
            string path = $"G:/screenshotWeb/{fileName}";
            CommonFunctions.SendText(element, path);
            //element.SendKeys(@"G:\screenshotWeb\Screenshot.jpg");
        }

        public void AddMessage()
        {
            IWebElement element = DictionaryIWebElement(4);
            int minLenght = 1;
            int maxLenght = 40;
            int stringNumber = 77;
            string regex = "[a-zA-Z]";

            string[] message = new string[1];

            for (int i = 0; i < stringNumber; i++)
            {
              string randomString = CommonFunctions.GenerateRandomStirng(regex, minLenght, maxLenght);
              message[0] = message[0] + " " + randomString;
            }

            string text = message[0];

            CommonFunctions.SendText(element, text);
        }

        public void SendClick()
        {
            IWebElement element = DictionaryIWebElement(8);
            CommonFunctions.ElementClick(element);
        }


    }
}
