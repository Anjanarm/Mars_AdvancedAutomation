using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Pages.HomePage
{
    public class SearchSkill
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By searchIcon = By.XPath("//i[@class='search link icon']");
        private readonly By categoryName = By.XPath("//a[normalize-space()='Recruitment']");
        private readonly By subCategoryName = By.XPath("//a[normalize-space()='Employability']");
        public SearchSkill(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void SearchSkillByCategory()
        {
            _wait.Until(d => d.Url.Contains("ListingManagement"));
            var searchButton = _wait.Until(d => d.FindElement(searchIcon));
            searchButton.Click();
            var selectCategory = _wait.Until(d => d.FindElement(categoryName));
            selectCategory.Click();
        }
        public bool CheckSkillExists(string listingTitle)
        {
           
            return _wait.Until(d =>
            d.FindElements(By.XPath($"//p[normalize-space()='{listingTitle}']")).Count > 0);
        }
        public void SearchSkillBySubCategory()
        {
            SearchSkillByCategory();
            var selectSubCategory = _wait.Until(d => d.FindElement(subCategoryName));
            selectSubCategory.Click();

        }
        public void SearchSkillByFilter(string filterOption)
        {
            _wait.Until(d => d.Url.Contains("ListingManagement"));
            var searchButton = _wait.Until(d => d.FindElement(searchIcon));
            searchButton.Click();
            var filter = _wait.Until(d => d.FindElement(By.XPath($"//button[normalize-space()='{filterOption}']")));
            filter.Click();
        }
    }
}
