using MaybeThisTime.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [FindsBy(How = How.Id, Using = "fileUpload")]
        private IWebElement attachFilePlusButtonChooseFile;

        [FindsBy(How = How.XPath, Using = "//input[@id='fileUpload']/following-sibling::span[@class='filename']")]
        private IWebElement attachFileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='fileUpload']/following-sibling::span[@class='action']")]
        private IWebElement buttonChooseFile;

        [FindsBy(How = How.Id, Using = "submitMessage")]
        private IWebElement buttonSend;

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
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        public IWebElement IWebElementDictionary(int dictionaryId)
        {
            IWebElement subjectHeading0 = IWebElement(subjectHeading);
            IWebElement emailAddress0 = IWebElement(emailAddress);
            IWebElement orderReferance0 = IWebElement(orderReferance);
            IWebElement message0 = IWebElement(message);
            IWebElement attachFilePlusButtonChooseFile0 = IWebElement(attachFilePlusButtonChooseFile);
            IWebElement attachFileField0 = IWebElement(attachFileField);
            IWebElement buttonChooseFile0 = IWebElement(buttonChooseFile);
            IWebElement buttonSend0 = IWebElement(buttonSend);

            Dictionary<int, IWebElement> IWebElementDictionary = new Dictionary<int, IWebElement>()
            {
                {1, subjectHeading0},
                {2, emailAddress0},
                {3, orderReferance0},
                {4, message0},
                {5, attachFilePlusButtonChooseFile0},
                {6, attachFileField0},
                {7, buttonChooseFile0},
                {8, buttonSend0}

            };

            IWebElement elementFromDictionary = IWebElementDictionary[dictionaryId];
            return elementFromDictionary;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------------------------------
        // Subject Heading

        /// <summary>
        /// <para> optionFromList: </para>
        /// <para> 0 = -- Choose -- </para>
        /// <para> 1 = Webmaster </para>
        /// <para> 2 = Customer service </para>
        /// </summary>
        /// <param name="optionFromList"></param>
        public void ChooseSubjectHeadingFromDropDownList(string optionFromList)
        {
            IWebElement element = IWebElementDictionary(1);
            CommonFunctions.ChooseElementFromList(element, 1, optionFromList);
        }
    }
}
