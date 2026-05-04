using Mars_Advanced.Pages.HomePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        //private readonly Language _language;
        //private readonly Skill _skill;

        private readonly By Rows = By.XPath("//tbody/tr");
        private readonly By EntireFirstRow = By.XPath("//table[@class='ui fixed table']//tbody/tr[1]");
        private readonly By DeleteRow = By.XPath("//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By PopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By SkillsTab = By.XPath("//a[normalize-space()='Skills']");
        private readonly By LanguageTab = By.XPath("//a[normalize-space()='Languages']");
        private readonly By SignOutButton = By.XPath("//button[normalize-space()='Sign Out']");



        public BasePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
                                                                         
        }

        public void DeleteGeneratedRows()
        {
            try
            {

                var rows = _wait.Until(d => d.FindElements(Rows));
                if (rows.Count == 0)
                    return;
                while (rows.Count > 0)
                {
                    var firstRow = _wait.Until(ExpectedConditions.ElementIsVisible(EntireFirstRow));
                    var deleteIcon = firstRow.FindElement(DeleteRow);
                    deleteIcon.Click();

                    Thread.Sleep(1000);
                    rows = _wait.Until(d => d.FindElements(Rows));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Cleanup] Failed to delete rows: {ex.Message}");
            }
        }

        public string PopUpMessage()
        {
            Thread.Sleep(3000);
            var FlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(PopUp));
            return FlashMessage.Text;
        }

        public void ClearAllProfileData()
        {
            //_language.DeleteAllLanguages();
            //_skill.DeleteAllSkills();

            var languageSelect = _wait.Until(d => d.FindElement(LanguageTab));
            languageSelect.Click();
            DeleteGeneratedRows();

            var skillSelect = _wait.Until(d => d.FindElement(SkillsTab));
            skillSelect.Click();
            DeleteGeneratedRows();
        }
        public void SignOut()
        {
            var signOut = _wait.Until(d => d.FindElement(SignOutButton));
            signOut.Click();
        }
    }   
}
