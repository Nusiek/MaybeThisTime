using Amazon.DynamoDBv2.Model;
using AngleSharp.Dom;
using Fare;
using MaybeThisTime.PageObjects;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

namespace MaybeThisTime.Common
{
    public class CommonFunctions : Base
    {
        //private IWebDriver driver;


        public static void ElementClick(IWebElement element)
        {
            element.Click();
        }

        public static void ElementClick(By element)
        {
            IWebElement iWebElement = driver.FindElement(element);
            iWebElement.Click();
        }

        public  static void ElementClick(By element, int elementIndex)
        {
            IList<IWebElement> elementsList = driver.FindElements(element);
            IWebElement WebElement = elementsList[elementIndex];
            WebElement.Click();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        // get text/ value
        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static string GetElmentAttributeValueByCss(IWebElement element, string attributeName)
        {
            string value = element.GetAttribute($"{attributeName}");
            return value;
        }

        //-------------------------------------------------------------------------
        // get text/ value lenght
        public static int GetTextLenght(string text)
        {
            return text.Length;
        }

        public static int GetValueLenght(IWebElement element, string attributeName)
        {
            int lenght = GetElmentAttributeValueByCss(element, attributeName).Length;
            return lenght;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // send text

        public static void SendText(IWebElement element, string textForInput)
        {
            element.SendKeys(textForInput);
        }

        public static void PressKeyControlPlusSymbol(IWebElement element, string symbol)
        {
            element.SendKeys(Keys.Control + $"{symbol}");
        }

        public static void ElementMarkText(IWebElement element)
        {
            string symbol = "a";
            PressKeyControlPlusSymbol(element, symbol);
        }

        public static void ElementCopyText(IWebElement element)
        {
            string symbol = "c";
            PressKeyControlPlusSymbol(element, symbol);
        }
        public static void ElementPasteText(IWebElement element)
        {
            string symbol = "v";
            PressKeyControlPlusSymbol(element, symbol);
        }

        public static void ElementCutText(IWebElement element)
        {
            string symbol = "x";
            PressKeyControlPlusSymbol(element, symbol);
        }

        public static void PressKeyBackspace(IWebElement element, int howManyTime)
        {
            element.SendKeys(Keys.End);

            for (int i = 0; i <= howManyTime; i++)
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public static void DeleteTextByClickingBackspace(IWebElement element, string attributeName)
        {
            
            int howManyTimePressBackspace = GetValueLenght(element, attributeName);
            ElementClick(element);
            PressKeyBackspace(element, howManyTimePressBackspace);
        }

        public static void DeleteTextByCuttingIt(IWebElement element)
        {
            ElementClick(element);
            ElementMarkText(element);
            ElementCutText(element);
        }



        //--------------------------------------------------------------------------------------------------------------------------------------
        // convert to string

        public static string ToString(int element)
        {
            string text = element.ToString();
            return text;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public static bool IsElementDisplayed(IWebElement element)
        {
            bool emementDisplay;
            emementDisplay = element.Displayed;
            return emementDisplay;
        }

        public static void WaitUtilElementDisplayBy(By elementId, double timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementId));
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public static string GetCurrentWindow()
        {
            return driver.CurrentWindowHandle;
        }

        public static IWebDriver StartBrowserNewTab()
        {
            IWebDriver newTabDriver = driver.SwitchTo().NewWindow(WindowType.Tab);
            return newTabDriver;
        }

        public static void StartBrowserNewTabByGivenUrl(string url)
        {
            IWebDriver newTab = StartBrowserNewTab();
            newTab.Url = $"{url}";
        }

        public static void CloseTab()
        {
            driver.Close();
        }

        public static void SwitchToOriginalWindow(string originalWindow)
        {
            driver.SwitchTo().Window(originalWindow);
        }

        public void GoBackToLastTab(string originalWindow)
        {
            CloseTab();
            SwitchToOriginalWindow(originalWindow);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        public static string GetErrorMessage(By elementBy, IWebElement element)
        {
            WaitUtilElementDisplayBy(elementBy, 5);
            string elementText = GetText(element);
            return elementText;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
   
        public static void ChooseElementFromList(By findElementBy, string attributeName, string attributeValue)
        {

            IList<IWebElement> elementsList = driver.FindElements(findElementBy);

            for (int element = 0; element < elementsList.Count; element++)
            {
                if (elementsList[element].GetAttribute($"{attributeName}").Equals($"{attributeValue}"))
                {
                    ElementClick(elementsList[element]);
                }
            }
        }

        /// <summary>
        /// <para> int selectedBy = 1 -> element.SelectByValue() </para> 
        /// <para> int selectedBy = 2 -> element.SelectByText() </para> 
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="selectedBy"></param>
        /// <param name="attributeValue"></param>
        public static void ChooseElementFromList(IWebElement webElement, int selectedBy, string attributeValue)
        {
            ElementClick(webElement);
            SelectElement element = new SelectElement(webElement);

            if (selectedBy == 1)
            {
                element.SelectByValue($"{attributeValue}");
            }
           
            if(selectedBy == 2)
            {
                element.SelectByText($"{attributeValue}");
            }
                

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentElement"></param>
        /// <param name="childlEmentsBy"></param>
        /// <param name="textUI"></param>

        public static void ChooseElementFromList(IWebElement parentElement, By childlEmentBy, string textUI)
        {
            IWebElement elementParent = parentElement;
            //TouchActions action = new TouchActions(driver);
            //action.ScrollToElement(elementParent).Perform();
            ElementClick(elementParent);

            IList<IWebElement> elementsList = driver.FindElements(childlEmentBy);
            int numbersOfElementInArray = elementsList.Count;

            string[] elementsArray = new string[numbersOfElementInArray];
            string elementText;

            for (int i = 0; i < numbersOfElementInArray; i++)
            {
                elementText = elementsList[i].Text;
                elementsArray[i] = elementText;
            }

            string elementName = textUI;
            int elementIndex = Array.IndexOf(elementsArray, elementName);

            for (int i = 0; i < elementIndex; i++)
            {
                elementParent.SendKeys(Keys.ArrowDown);
            }

            elementParent.Click();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // scroll

        public static void ScrollToElement(IWebElement element)
        {
            TouchActions action = new TouchActions(driver);
            action.ScrollToElement(element).Perform();

        }


        //--------------------------------------------------------------------------------------------------------------------------------------

        public static string GenerateRandomStirng(string regexExpression, int minNumber, int maxNumber)
        {
            Random number = new Random();
            int randomNumber = number.Next(minNumber, maxNumber);
            string regularExpression = regexExpression + "{" + randomNumber + "}";

            Xeger xeger = new Xeger(regularExpression, new Random());
            string generatedString = xeger.Generate();
            return generatedString;
        }

        public static string GenerateEmailAddress()
        {
            int minNumber = 3;
            int maxNumber = 15;
            string regex1 = "[a-zA-Z0-9]";
            string regex2 = "[a-zA-Z]";
            string stringBefore = GenerateRandomStirng(regex1, minNumber, maxNumber);
            string stringAfter = GenerateRandomStirng(regex2, minNumber, maxNumber);

            string email = $"{stringBefore}@{stringAfter}.com";
            return email;
        }

        public static string GenerateRandomNumber(int numberLenght)
        {
            int minNumber = numberLenght;
            string regex = "[0-9]";
            string stringNumber = GenerateRandomStirng(regex, minNumber, minNumber);
            return stringNumber;
        }

        // zip / postal code

        /// <summary>
        /// <para> action = 0 -> it generate the correct zip/ postal code (lenght = 5), zipCodeLenght any number does not matter </para>
        /// <para> action = 1 -> it generate the wrong zip/ postal code - only digits </para>
        /// <para> action = 2 -> it generate the wrong zip/ postal code - only letters </para>
        /// <para> action = 3 -> it generate the wrong zip/ postal code - digits and letters </para>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="zipCodeLenght"></param>
        /// <returns></returns>
        public static string GenerateZipCode (int action, int zipCodeLenght)
        {
            string zipCode;
            if (action == 0)
            {
                int correctZipCode = 5;
                zipCode = GenerateRandomNumber(correctZipCode);
                return zipCode;
            }
            else if (action == 1)
            {
                zipCode = GenerateRandomNumber(zipCodeLenght);
                return zipCode;
            }
            else if (action == 2)
            {
                string regex = "[a-zA-Z]";
                zipCode = GenerateRandomStirng(regex, zipCodeLenght, zipCodeLenght);
                return zipCode;
            }
            else if (action == 3)
            {
                string regex = "[a-zA-Z0-9]";
                zipCode = GenerateRandomStirng(regex, zipCodeLenght, zipCodeLenght);
                return zipCode;
            }
            else
            {
                zipCode = "Well, you choose the number out of the range of action xD";
                return zipCode;
            }


        }

        // home / mobile phone number
        public static string GeneratePhoneNumber(int numberLenght)
        {
            string phoneNumber = GenerateRandomNumber(numberLenght);
            return phoneNumber;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------

        public static string[] ArrayString(By element)
        {
            IList<IWebElement> elementList = driver.FindElements(element);

            int elementListLenght = elementList.Count;
            //TestContext.Progress.WriteLine("elementListLenght: " + elementListLenght);

            string[] arraySting = new string[elementListLenght];

            for (int elementId = 0; elementId < elementListLenght; elementId++)
            {
                arraySting[elementId] = elementList[elementId].Text;
                //TestContext.Progress.WriteLine($"arraySting[{elementId}]" + arraySting[elementId]);
            }
            return arraySting;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
    }
}
