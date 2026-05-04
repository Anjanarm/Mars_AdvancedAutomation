using Mars_Advanced.Pages;
using Mars_Advanced.Pages.HomePage;
using Mars_Advanced.TestData;
using Mars_Advanced.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Steps
{
    [Binding]
    public class LanguageSteps
    {
       private readonly LoginPage _loginPage;
        private readonly Language _language;
        private readonly NavigationHelper _navigationHelper;
        private readonly BasePage _basePage;
        //private readonly IWebDriver _driver;
        private List<LanguageData> _langList;
        private List<LanguageEditData> _editLangList;
        private LanguageData _updateData;

        public LanguageSteps(LoginPage loginPage, Language language, NavigationHelper navigationHelper, BasePage basePage)
        {
            _loginPage = loginPage;
            _language = language;
            _navigationHelper = navigationHelper;
            _basePage = basePage;
        }
        [Given("I load all language details from {string} for {string}")]
        public void GivenILoadAllLanguageDetailsFromFor(string filename, string data)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string certificationPath = Path.Combine(currentDir, "TestData", "LanguageTestData.json");
         
            string json = File.ReadAllText(certificationPath);
            //_testdata = JsonSerializer.Deserialize<TestSettings>(json);
            var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data == "EditData")
            {
                _editLangList = JsonConvert.DeserializeObject<List<LanguageEditData>>(allData[data].ToString());
            }
            else
            {
                _langList = JsonConvert.DeserializeObject<List<LanguageData>>(allData[data].ToString());
            }
        }
        [When("I add all language entries")]
        public void WhenIAddAllLanguageEntries()
        {
            foreach (var lang in _langList)
            {
                _language.AddLanguage(lang);
            }
        }
        [Then("I should see the languages added")]
        public void ThenIShouldSeeTheLanguagesAdded()
        {
            foreach (var lang in _langList)
            {
                bool languageExists = _language.LanguageExists(lang);
                if (!languageExists)
                    throw new Exception(lang.Language + " not found");
            }
        }
        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            string errorMessage = _basePage.PopUpMessage();
            Assert.That(errorMessage, Is.EqualTo("Please enter language and level"));
        }
        [Then("I should see duplicate data message")]
        public void ThenIShouldSeeDuplicateDataMessage()
        {
            string duplicateMessage = _basePage.PopUpMessage();
            Assert.That(duplicateMessage, Is.EqualTo("This language is already exist in your language list."));
        }
        [When("I add the original language entry")]
        public void WhenIAddTheOriginalLanguageEntry()
        {
            foreach (var editLang in _editLangList)
            {
                _language.AddLanguage(editLang.Original);
            }
        }
        [When("I edit with updated language entry")]
        public void WhenIEditWithUpdatedLanguageEntry()
        {
            foreach (var editLang in _editLangList)
            {
                _language.EditLanguage(editLang.Updated);
                _updateData = editLang.Updated;
            }
        }
        [Then("I should see the updated language")]
        public void ThenIShouldSeeTheUpdatedLanguage()
        {
            string updatedMessage = _basePage.PopUpMessage();
            Assert.That(updatedMessage, Is.EqualTo(_updateData.Language + " has been updated to your languages"));
        }

        [When("I delete added language")]
        public void WhenIDeleteAddedLanguage()
        {
            _language.DeleteLanguage();
        }

        [Then("I should see the language field removed")]
        public void ThenIShouldSeeTheLanguageFieldRemoved()
        {
            string deleteMessage = _basePage.PopUpMessage();
            Assert.That(deleteMessage.ToLower(), Does.Contain("deleted"));
        }


    }
}
