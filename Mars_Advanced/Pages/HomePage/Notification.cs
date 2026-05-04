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
    public class Notification
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
        //private readonly By search = By.XPath("//div[@class='ui secondary menu']//input[@placeholder='Search skills']");
        private readonly By searchIcon = By.XPath("//i[@class='search link icon']");
        private readonly By listing = By.XPath("//div[@class='ui card']");
        private readonly By request = By.XPath("//i[contains(@class,'send outline icon')]");
        private readonly By confirmRequest = By.XPath("//button[normalize-space()='Yes']");
        private readonly By profileOption = By.XPath("//a[normalize-space()='Profile']");
        private readonly By notificationIcon = By.XPath("//div[@class='ui top left pointing dropdown item']");
        private readonly By seeAll = By.XPath("//a[normalize-space()='See All...']");
        private readonly By notificationTitle = By.XPath("//h1[normalize-space()='Notifications']");
        private readonly By loadMoreOption = By.XPath("//a[normalize-space()='Load More...']");
        private readonly By items = By.XPath("//div[@class='fourteen wide column']");
        private readonly By seeLessOption = By.XPath("//a[normalize-space()='...Show Less']");
        private readonly By selectOption = By.XPath("//input[@value='0']");
        private readonly By deleteOption = By.XPath("//i[@class='trash icon']");
        private readonly By selectAllOption = By.XPath("//i[@class='mouse pointer icon']");
        private readonly By unselectAllOption = By.XPath("//i[@class='ban icon']");
        private readonly By markAsRead = By.XPath("//a[normalize-space()='Mark all as read']");
        private readonly By notificationCount = By.XPath("//div[@class='floating ui blue label']");
        int itemsBefore;
        int itemsAfter;
        private Notification(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void ShareSkill(NotificationData skill)

        {
            var shareSkillOption = _wait.Until(d => d.FindElement(shareSkillButton));
            shareSkillOption.Click();
            var titleOption = _wait.Until(d => d.FindElement(title));
            titleOption.Click();
            titleOption.SendKeys(skill.Title);
            var descriptionOption = _wait.Until(d => d.FindElement(description));
            descriptionOption.Click();
            descriptionOption.SendKeys(skill.Description);
            var categoryOption = _wait.Until(ExpectedConditions.ElementToBeClickable(category));
            categoryOption.Click();
            categoryOption.SendKeys(skill.Category);
            categoryOption.SendKeys(Keys.Enter);
            var subcategoryOption = _wait.Until(ExpectedConditions.ElementIsVisible(subcategory));
            subcategoryOption.Click();
            subcategoryOption.SendKeys(skill.Subcategory);
            subcategoryOption.SendKeys(Keys.Enter);
            var tagOption = _wait.Until(d => d.FindElement(tags));
            tagOption.Click();
            tagOption.SendKeys(skill.Tags);
            tagOption.SendKeys(Keys.Enter);
            var serviceTypeOption = _wait.Until(d => d.FindElement(hourlyservice));
            serviceTypeOption.Click();
            var locationTypeOption = _wait.Until(d => d.FindElement(onlinelocation));
            locationTypeOption.Click();
            var skillTradeOption = _wait.Until(d => d.FindElement(credit));
            skillTradeOption.Click();
            var creditPointsOption = _wait.Until(ExpectedConditions.ElementIsVisible(creditpoints));
            creditPointsOption.Click();
            creditPointsOption.SendKeys(skill.Credit);
            var activeOption = _wait.Until(d => d.FindElement(activestatus));
            activeOption.Click();
            var saveOption = _wait.Until(d => d.FindElement(save));
            saveOption.Click();
        }
        public void SkillRequest(string category)
        {
            var searchButton = _wait.Until(d => d.FindElement(searchIcon));
            searchButton.Click();
            var selectCategory = _wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()= 'category']")));
            selectCategory.Click();
            var listingcard = _wait.Until(d => d.FindElement(listing));
            listingcard.Click();
            var requestOption = _wait.Until(ExpectedConditions.ElementIsVisible(request));
            requestOption.Click();
            var requestConfirmation = _wait.Until(ExpectedConditions.ElementIsVisible(confirmRequest));
            requestConfirmation.Click();
            var profileButton = _wait.Until(d => d.FindElement(profileOption));
            profileButton.Click();
        }
        public void SeeAll()
        {
            var notification = _wait.Until(d => d.FindElement(notificationIcon));
            notification.Click();
            var seeAllOption = _wait.Until(d => d.FindElement(seeAll));
            seeAllOption.Click();

        }
        public bool NotificationTitleExists()
        {
            var notificationIcon = _wait.Until(ExpectedConditions.ElementIsVisible(notificationTitle));
            if (notificationIcon != null)
                return true;
            else return false;

        }
        public void LoadMore()
        {
            var item = _wait.Until(d => d.FindElements(items));
            itemsBefore = item.Count;  
            var loadMore = _wait.Until(ExpectedConditions.ElementIsVisible(loadMoreOption));
            loadMore.Click();
            itemsAfter = item.Count;
        }
        public bool LoadMoreSuccess()
        {
            if (itemsAfter > itemsBefore)
                return true;
            else
                return false;
        }
        public void SeeLess()
        {
            var item = _wait.Until(d => d.FindElements(items));
           
            var loadMore = _wait.Until(ExpectedConditions.ElementIsVisible(loadMoreOption));
            loadMore.Click();
            itemsBefore = item.Count;
            var showLess = _wait.Until(ExpectedConditions.ElementIsVisible(loadMoreOption));
            showLess.Click();
            itemsAfter = item.Count;
        }
        public bool SeeLessSuccess()
        {
            if (itemsAfter < itemsBefore)
                return true;
            else
                return false;
        }
        public void Delete()
        {
            var selectIcon = _wait.Until(d => d.FindElement(selectOption));
            selectIcon.Click();
            var deleteIcon = _wait.Until(d => d.FindElement(deleteOption));
            deleteIcon.Click();
        }
        public void SelectAll()
        {
            var selectAll = _wait.Until(d => d.FindElement(selectAllOption));
            selectAll.Click();
        }
        public bool IsSelected()
        {
            var checkbox = _wait.Until(d => d.FindElement(selectOption));
            bool checkSelected = checkbox.Selected;
            return checkSelected;
        }
        public void UnSelectAll()
        {
            var unselectAll = _wait.Until(d => d.FindElement(unselectAllOption));
            unselectAll.Click();
        }
        public void MarkAsRead()
        {
            var notification = _wait.Until(d => d.FindElement(notificationIcon));
            notification.Click();
            var markRead = _wait.Until(d => d.FindElement(markAsRead));
            markRead.Click();
        }
        public bool NotificationCount()
        {
            bool isHidden = _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(notificationCount));

            return isHidden;
        }
    }
}

