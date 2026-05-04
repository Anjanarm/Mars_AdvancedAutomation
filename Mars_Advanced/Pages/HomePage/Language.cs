using Mars_Advanced.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Pages.HomePage
{
    public class Language
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        //private readonly BasePage _basePage;
        private readonly By LanguageTab = By.XPath("//a[normalize-space()='Languages']");
        private readonly By AddNewLanguage = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By AddLanguageElement = By.XPath("//input[@placeholder='Add Language']");
        private readonly By ChooseLevel = By.XPath("//select[@name='level']");
        private readonly By AddOption = By.XPath("//input[@value='Add']");
        private readonly By EditLanguageElement = By.XPath("//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateField = By.XPath("//input[@value='Update']");
        private readonly By DeleteLanguageElement = By.XPath("//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By LanguageTable = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//table[@class='ui fixed table']");
        public Language(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
           // _basePage = new BasePage(_driver);
        }
        public void AddLanguage(LanguageData lang)
        {
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewLanguage));
            addNewElement.Click();
            var addLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            addLanguageField.SendKeys(lang.Language);
            var languageLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            languageLevel.Click();
            languageLevel.SendKeys(lang.Level);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            Thread.Sleep(3000);
        }
        public bool LanguageExists(LanguageData lang)
        {
            var rows = _wait.Until(d => d.FindElements(LanguageTable));
            foreach (var row in rows)
            {
                if (row.Text.Contains(lang.Language) &&
                    row.Text.Contains(lang.Level))
                {
                    return true;
                }
            }
            return false;
        }
        public void EditLanguage(LanguageData lang)
        {
            var editLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditLanguageElement));
            editLanguageField.Click();
            var editLanguageData = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            editLanguageData.Clear();
            //editLanguageData = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            editLanguageData.SendKeys(lang.Language);
            var languageLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            languageLevel.Click();
            languageLevel.SendKeys(lang.Level);
            var updateLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateField));
            updateLanguageField.Click();
            Thread.Sleep(3000);
        }
        public void DeleteLanguage()
        {
            var deleteLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguageElement));
            deleteLanguageField.Click();
        }
        /*
        public void DeleteAllLanguages()
        {
            var languageSelect = _wait.Until(d => d.FindElement(LanguageTab));
            languageSelect.Click();
            _basePage.DeleteGeneratedRows();
        }*/

    }

}
