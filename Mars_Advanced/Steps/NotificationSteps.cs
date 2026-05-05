using Mars_Advanced.Pages;
using Mars_Advanced.Pages.HomePage;
using Mars_Advanced.TestData;
using Mars_Advanced.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Steps
{
    [Binding]
    public class NotificationSteps
    {
        private readonly LoginPage _loginPage;
        private readonly BasePage _basePage;
        private readonly NavigationHelper _navigationHelper;
        private readonly JsonHelpers _jsonhelpers;
        private List<NotificationData> _skillList;
        private readonly Notification _notification;
        private readonly ShareSkill _shareskill;
        public NotificationSteps(LoginPage loginPage, BasePage basePage, NavigationHelper navigationHelper, JsonHelpers jsonhelpers, Notification notification, ShareSkill shareskill)
        {
            _loginPage = loginPage;
            _basePage = basePage;
            _navigationHelper = navigationHelper;
            _jsonhelpers = jsonhelpers;
            _notification = notification;
            _shareskill = shareskill;
        }
        [Given("Jeen shares skills from {string}")]
        public void GivenJeenSharesSkillsFrom(string skilldata)
        {
            string json = _jsonhelpers.ReadJson(skilldata);
            Console.WriteLine(json);
            var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            _skillList = JsonConvert.DeserializeObject<List<NotificationData>>(allData["NotificationTestData"].ToString());
            foreach (var skill in _skillList)
            {
                _notification.ShareSkill(skill);
            }

        }
        [Given("Bob is logged in using {string} and {string} and sends request to Jeen")]
        public void GivenBobIsLoggedInUsingAndAndSendsRequestToJeen(string email, string password)
        {
            _basePage.SignOut();
            _loginPage.Login(email, password);
            foreach (var skill in _skillList)
            {
                _notification.SkillRequest(skill.Category);
            }
            _basePage.SignOut();
        }
        
        [When("Jeen click see all option")]
        public void WhenJeenClickSeeAllOption()
        {
            _notification.SeeAll();
        }
        [Then("All notifications listed")]
        public void ThenAllNotificationsListed()
        {
            bool titleExists = _notification.NotificationTitleExists();
            Assert.That(titleExists, Is.True);
        }
        [When("Jeen clicks load more option")]
        public void WhenJeenClicksLoadMoreOption()
        {
            _notification.SeeAll();
            _notification.LoadMore();
        }
        [Then("More notification should be loaded")]
        public void ThenMoreNotificationShouldBeLoaded()
        {
            Assert.That(_notification.LoadMoreSuccess(),Is.True);
        }
        [When("Jeen clicks see less option")]
        public void WhenJeenClicksSeeLessOption()
        {
            _notification.SeeAll();
            _notification.SeeLess();
        }
        [Then("Notification should be collapsed")]
        public void ThenNotificationShouldBeCollapsed()
        {
            Assert.That(_notification.SeeLessSuccess(), Is.True);
        }
        [When("Jeen deletes the notification")]
        public void WhenJeenDeletesTheNotification()
        {
            _notification.SeeAll();
            _notification.Delete();
        }
        [Then("Notification updation message displayed")]
        public void ThenNotificationUpdationMessageDisplayed()
        {
            string message = _basePage.PopUpMessage();
            Assert.That(message, Is.EqualTo("Notification updated"));
        }
        [When("Jeen marks the notification as read")]
        public void WhenJeenMarksTheNotificationAsRead()
        {
            _notification.MarkAsRead();
        }
        [Then("Notification icon removed")]
        public void ThenNotificationIconRemoved()
        {
            Assert.That(_notification.NotificationCount(), Is.True);
            
        }

        [When("Jeen clicks select all option")]
        public void WhenJeenClicksSelectAllOption()
        {
            _notification.SeeAll(); 
            _notification.SelectAll();
        }
        [Then("select option turns blue")]
        public void ThenSelectOptionTurnsBlue()
        {
            Assert.That(_notification.IsSelected(), Is.True);
        }
        [When("Clicks unselect option")]
        public void WhenClicksUnselectOption()
        {
            _notification.UnSelectAll();
        }
        [Then("options should not be selected")]
        public void ThenOptionsShouldNotBeSelected()
        {
            Assert.That(_notification.IsSelected(), Is.False);
        }



    }
}
