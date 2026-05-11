//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using Reqnroll.BoDi;
using SeleniumExtras.WaitHelpers;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mars_Advanced.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        // Locators
        private readonly By EmailField = By.CssSelector("input[placeholder = 'Email address']");
        private readonly By PasswordField = By.CssSelector("input[placeholder = 'Password']");
        private readonly By LoginButton = By.XPath("//button[normalize-space()='Login']");
        private readonly By SignInElement = By.XPath("//a[normalize-space()='Sign In']");
        private readonly By PageHeading = By.TagName("h1");
        private readonly By ErrorElement = By.XPath("//div[@class='ns-box-inner']");

        public LoginPage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public void Login(string email, string password)
        {
            var signinElement = _wait.Until(ExpectedConditions.ElementIsVisible(SignInElement));
            signinElement.Click();

            var emailElement = _wait.Until(ExpectedConditions.ElementIsVisible(EmailField));
            emailElement.SendKeys(email);

            var passwordElement = _wait.Until(d => d.FindElement(PasswordField));
            passwordElement.SendKeys(password);

            var loginButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            loginButtonElement.Click();
        }
        public bool IsAtLoginPage()
        {
            var pageHeadingElement = _wait.Until(ExpectedConditions.ElementIsVisible(PageHeading));
            return pageHeadingElement.Text.Equals("Trade your skills for a new skill?", StringComparison.OrdinalIgnoreCase);

        }
        public string ErrorMessage()
        {

            Thread.Sleep(3000);
            var errorElement = _wait.Until(ExpectedConditions.ElementIsVisible(ErrorElement));

            return errorElement.Text;
        }
    }
}
