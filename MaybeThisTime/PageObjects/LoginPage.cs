using MaybeThisTime.Common;
using MaybeThisTime.VariousNeeded.CreateAnAccount;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Security.Principal;
using System.Threading;

namespace MaybeThisTime.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        //IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page objects
        //--------------------------------------------------------------------------------------------------------------------------------------

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement registeredEmail;
        private By registeredEmailBy = By.Id("email");

        [FindsBy(How =  How.Id, Using = "passwd")]
        private IWebElement registeredPassword;
        private By registeredPasswordBy = By.Id("password");

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement registeredSingInButton;
        private By registeredSingInButtonBy = By.Id("SubmitLogin");

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger']/child::ol/li")]
        private  IWebElement errorMessage;
        private By errorMessageBy = By.XPath("//div[@class='alert alert-danger']/child::ol/li");

        //--------------------------------------------------------------

        [FindsBy(How = How.Id, Using = "email_create")]                                
        private IWebElement createEmail;
        private By createEmailBy = By.Id("email_create");

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement submitCreateButton;
        private By submitCreateButtonBy = By.Id("SubmitCreate");

        [FindsBy(How = How.XPath, Using = "//div[@id='create_account_error']/child::ol/li")]
        private IWebElement errorMessageCreateAccount;
        private By errorMessageCreateAccountBy = By.XPath("//div[@id='create_account_error']/child::ol/li");

        //--------------------------------------------------------------------------------------------------------------------------------------
        public IWebElement RegisteredEmail()
        {
            return registeredEmail;
        }

        public IWebElement RegisteredPassword()
        {
            return registeredPassword;
        }

        public IWebElement RegisteredSingInButton()
        {
            return registeredSingInButton;
        }

        public  IWebElement ErrorMessage()
        {
            return errorMessage;
        }

        //--------------------------------------------------------------

        public IWebElement EmailForNewAccount()
        {
            return createEmail;
        }

        public  IWebElement SubmitCreateButton()
        {
            return submitCreateButton;
        }

        public IWebElement ErrorMessageCreateAccount()
        {
            return errorMessageCreateAccount;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        public By RegisteredEmailBy()
        {
            return registeredEmailBy;
        }

        public By RegisteredPasswordBy()
        {
            return registeredPasswordBy;
        }

        public By RegisteredSingInButtonBy()
        {
            return registeredSingInButtonBy;
        }

        public By ErrorMessageBy()
        {
            return errorMessageBy;
        }

        //--------------------------------------------------------------

        public By CreateEmailBy()
        {
            return createEmailBy;
        }

        public By SubmitCreateButtonBy()
        {
            return submitCreateButtonBy;
        }

        public By ErrorMessageCreateAccountBy()
        {
            return errorMessageCreateAccountBy;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // page action
        //--------------------------------------------------------------------------------------------------------------------------------------

        // click
        public void RegisteredEmailClick()
        {
            CommonFunctions.ElementClick(RegisteredEmail());
        }

        public void RegisteredPasswordClick()
        {
            CommonFunctions.ElementClick(RegisteredPassword());
        }

        public void RegisteredSingInButtoClick()
        {
            CommonFunctions.ElementClick(RegisteredSingInButton());
        }

        public void EmailForNewAccountClick()
        {
            CommonFunctions.ElementClick(EmailForNewAccount());
        }

        //--------------------------------------------------------------

        public void CreateAccountFieldClick()
        {
            CommonFunctions.ElementClick(EmailForNewAccount());
        }

        public void SubmitCreateAccountButtonClick()
        {
            CommonFunctions.ElementClick(SubmitCreateButton());
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // type
        public void TypeRegisteredEmail(string registeredEmail)
        {
            CommonFunctions.SendText(RegisteredEmail(), registeredEmail);
        }

        public void TypeRegisteredPassword(string registeredPassword)
        {
            CommonFunctions.SendText(RegisteredPassword(), registeredPassword);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // go to another page
        public UserAccountPage GoToUserAccountAfterLoggingInPage()
        {
            CommonFunctions.ElementClick(SubmitCreateButton());
            return new UserAccountPage(driver);
        }

        public CreateAccountPage GoToCreateAccountPage()
        {
            CommonFunctions.ElementClick(SubmitCreateButton());
            return new CreateAccountPage(driver);
        }

        public NewAccountGetEmailForRegistrationPage GoToNewAccountGetEmailForRegistrationPage()
        {
            string webAdrress = "https://10minutemail.net";
            CommonFunctions.StartBrowserNewTabByGivenUrl(webAdrress);
            return new NewAccountGetEmailForRegistrationPage(driver);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        // log in to account
        public void TypeDataForLoginAccount(string registeredEmail, string registeredPassword)
        {
            CommonFunctions.WaitUtilElementDisplayBy(RegisteredEmailBy(), 8);
            RegisteredEmailClick();
            TypeRegisteredEmail(registeredEmail);
            RegisteredPasswordClick();
            TypeRegisteredPassword(registeredPassword);
        }

        public  void IsLoginSuccessful(bool isLoginSuccessful)
        {
            if (isLoginSuccessful == false)
            {
                RegisteredSingInButtoClick();
                ErrorMessage();
            }
            else
            {
                GoToUserAccountAfterLoggingInPage();
            }
        }

        public void LogInAccount(string registeredEmail, string registeredPassword, bool isLoginSuccessful)
        {
            TypeDataForLoginAccount(registeredEmail, registeredPassword);
            IsLoginSuccessful(isLoginSuccessful);
        }

        //--------------------------------------------------------------
        // error message
        public string GetErrorMessageForAlresdyRegisteredAccount()
        {
            IWebElement errorMessage = ErrorMessage();
            By errorMessageBy = ErrorMessageBy();
            string elementText = CommonFunctions.GetErrorMessage(errorMessageBy, errorMessage);
            return elementText;
        }

        public string GetErrorMessageForCreateAccount()
        {
            IWebElement errorMessage = ErrorMessageCreateAccount();
            By errorMessageBy = ErrorMessageCreateAccountBy();
            string elementText = CommonFunctions.GetErrorMessage(errorMessageBy, errorMessage);
            return elementText;
        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------
        // new accont registration
        public void PasteNewEmailIntoCreateAccountFieldFromWebpage()
        {
            IWebElement newEmail = EmailForNewAccount();
            string symbol = "v";
            CommonFunctions.PressKeyControlPlusSymbol(newEmail, symbol);
        }

        public void PasteCopiedEmailAddress()
        {
            CommonFunctions.WaitUtilElementDisplayBy(CreateEmailBy(), 5);
            CreateAccountFieldClick();
            PasteNewEmailIntoCreateAccountFieldFromWebpage();
        }

        public void RandomEmailAddress(string email)
        {
            IWebElement element = EmailForNewAccount();
            CommonFunctions.WaitUtilElementDisplayBy(CreateEmailBy(), 5);
            EmailForNewAccountClick();
            CommonFunctions.SendText(element, email);           
        }
     

        public void AddNewEmailIntoCreateAccountFiledByGivenText(string email)
        {
            IWebElement element = EmailForNewAccount();
            CommonFunctions.WaitUtilElementDisplayBy(CreateEmailBy(), 5);
            EmailForNewAccountClick();
            CommonFunctions.SendText(element, email);

        }




        //--------------------------------------------------------------------------------------------------------------------------------------
    }
}
