using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V100.Page;
using NUnit.Framework.Internal;
using System.Drawing;
using System.Drawing.Imaging;

namespace MaybeThisTime
{
    public class Base
    {
        String browserName;
        //ExtentReports extent;
        //ExtentTest test;

        public static IWebDriver driver;

       // [OneTimeSetUp]
        /*
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            TestContext.Progress.WriteLine("reportPath: " + reportPath);

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            ExtentReports extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "me");
        }
        */
        [SetUp]

        public void StartBrowser()
        {
            //extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = System.Configuration.ConfigurationManager.AppSettings["browser"];
            //string browserName = "Chrome";
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php";
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

            }
        }
        /*
        public IWebDriver GetDriver()
        {
            return driver;
        }
        */
        
        [TearDown]
       
        public void AfterTest()
        {

            //extent.Flush();
           //driver.Quit();
            
        }
        
        

        
    }
}
