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
    public class ShareSkill
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By shareSkillButton = By.XPath("//a[normalize-space()='Share Skill']");
        private readonly By title = By.XPath("//input[@placeholder='Write a title to describe the service you provide.']");
        private readonly By description = By.XPath("//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']");
        private readonly By category = By.XPath("//select[@name='categoryId']");
        private readonly By subcategory = By.XPath("//select[@name='subcategoryId']");
        private readonly By tags = By.XPath("(//input[contains(@placeholder,'Add new tag')])[1]");
        private readonly By hourlyservice = By.XPath("(//input[@name='serviceType'])[1]");
        private readonly By oneoffservice = By.XPath("(//input[@name='serviceType'])[2]");
        private readonly By onsitelocation = By.XPath("(//input[@name='locationType'])[1]");
        private readonly By onlinelocation = By.XPath("(//input[@name='locationType'])[2]");
        private readonly By skillexchange = By.XPath("(//input[@name='skillTrades'])[1]");
        //private readonly By credit = By.XPath("//(input[@name='skillTrades'])[2]");
        private readonly By credit = By.CssSelector("input[value='false'][name='skillTrades']");
        private readonly By creditpoints = By.XPath("//input[@placeholder='Amount']");
        private readonly By activestatus = By.XPath("(//input[@name='isActive'])[1]");
        private readonly By hiddenstatus = By.XPath("(//input[@name='isActive'])[2]");
        private readonly By save = By.XPath("//input[@value='Save']");
        //private readonly By managelisting = By.CssSelector("//a[normalize-space()='Manage Listings']");
        private readonly By firstrow = By.XPath("//tbody/tr[1]");

        public ShareSkill(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void ListingDetails(ShareSkillData _shareskilldata)

        {
            var shareSkillOption = _wait.Until(d => d.FindElement(shareSkillButton));
            shareSkillOption.Click(); 
            var titleOption = _wait.Until(d => d.FindElement(title));
            titleOption.Click();
            titleOption.SendKeys(_shareskilldata.ShareSkillTests.Title);
            var descriptionOption = _wait.Until(d => d.FindElement(description));
            descriptionOption.Click();
            descriptionOption.SendKeys(_shareskilldata.ShareSkillTests.Description);
            var categoryOption  = _wait.Until(ExpectedConditions.ElementToBeClickable(category));
            categoryOption.Click();
            categoryOption.SendKeys(_shareskilldata.ShareSkillTests.Category);
            categoryOption.SendKeys(Keys.Enter);
            var subcategoryOption = _wait.Until(ExpectedConditions.ElementIsVisible(subcategory));
            subcategoryOption.Click();
            subcategoryOption.SendKeys(_shareskilldata.ShareSkillTests.Subcategory);
            subcategoryOption.SendKeys(Keys.Enter);
            var tagOption = _wait.Until(d => d.FindElement(tags));
            tagOption.Click();
            tagOption.SendKeys(_shareskilldata.ShareSkillTests.Tags);
            tagOption.SendKeys(Keys.Enter);
            var serviceTypeOption = _wait.Until(d => d.FindElement(hourlyservice));
            serviceTypeOption.Click();
            var locationTypeOption = _wait.Until(d => d.FindElement(onlinelocation));
            locationTypeOption.Click();
            var skillTradeOption = _wait.Until(d => d.FindElement(credit));
            skillTradeOption.Click();
            var creditPointsOption = _wait.Until(ExpectedConditions.ElementIsVisible(creditpoints));
            creditPointsOption.Click();
            creditPointsOption.SendKeys(_shareskilldata.ShareSkillTests.Credit);
            var activeOption = _wait.Until(d => d.FindElement(activestatus));
            activeOption.Click();
            var saveOption = _wait.Until(d => d.FindElement(save));
            saveOption.Click();
        }
        public bool ListingCheck(string expectedTitle)
        {
            //var manageListing = _wait.Until(ExpectedConditions.ElementIsVisible(managelisting));
            // manageListing.Click();
            _wait.Until(d => d.Url.Contains("ListingManagement"));
            return _wait.Until(d =>
            d.FindElements(By.XPath($"//td[normalize-space()='{expectedTitle}']")).Count > 0);
        }
    }
}
