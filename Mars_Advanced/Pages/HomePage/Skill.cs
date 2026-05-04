using Mars_Advanced.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mars_Advanced.Pages.HomePage
{
    public class Skill
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        //private readonly BasePage _basePage;
        private readonly By SkillsTab = By.XPath("//a[normalize-space()='Skills']");
        private readonly By AddSkillElement = By.XPath("//input[@placeholder='Add Skill']");
        private readonly By AddNewSkill = By.XPath("//div[@data-tab='second']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By ChooseLevel = By.XPath("//select[@name='level']");
        private readonly By EditSkillElement = By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateSkillField = By.XPath("//div[@data-tab='second']//input[@value='Update']");
        private readonly By DeleteSkillElement = By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By AddOption = By.XPath("//input[@value='Add']");
        //private readonly By SkillTable = By.XPath("//table[@class='ui fixed table']//tbody/tr");
        private readonly By SkillTable = By.XPath("//div[@data-tab='second' and contains(@class,'active')]//table//tbody/tr");
        public Skill(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
           // _basePage = new BasePage(_driver);
        }
        public void AddSkill(SkillData Skill)
        {
            var skillSelect = _wait.Until(d => d.FindElement(SkillsTab));
            skillSelect.Click();
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewSkill));
            addNewElement.Click();
            var addSkillField = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillElement));
            addSkillField.SendKeys(Skill.Skill);
            var skillLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            skillLevel.Click();
            skillLevel.SendKeys(Skill.Level);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }
        public void EditSkill(SkillData skill)
        {
            var editSkillField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditSkillElement));
            editSkillField.Click();
            var editSkillData = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillElement));
            editSkillData.Clear();
            editSkillData.SendKeys(skill.Skill);
            var skillLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            skillLevel.Click();
            skillLevel.SendKeys(skill.Level);
            var updateSkillField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateSkillField));
            updateSkillField.Click();
            Thread.Sleep(3000);
        }
        public bool SkillExists(SkillData skill)
        {
            var rows = _wait.Until(d => d.FindElements(SkillTable));
            foreach (var row in rows)
            {
                if (row.Text.Contains(skill.Skill))
                {
                    return true;
                }
            }
            return false;
        }
        public void DeleteSkill()
        {
            var deleteSkillField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkillElement));
            deleteSkillField.Click();
        }

        /*
        public void DeleteAllSkills()
        {
            var skillSelect = _wait.Until(d => d.FindElement(SkillsTab));
            skillSelect.Click();
            _basePage.DeleteGeneratedRows();
        }*/
    }
}
