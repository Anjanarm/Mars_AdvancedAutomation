using Mars_Advanced.Pages;
using Mars_Advanced.Utils;
using NUnit.Framework;
using Reqnroll;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        //private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;

        public LoginSteps(LoginPage loginPage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            //  _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _navigationHelper.NavigateTo("");
            Assert.That(_loginPage.IsAtLoginPage(), Is.True, "Should be on the login page");
        }

        [Given("I enter {string} and {string}")]
        public void GivenIEnterAnd(string email, string password)
        {
            _loginPage.Login(email, password);
        }

        }
    }