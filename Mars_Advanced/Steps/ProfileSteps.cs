using Mars_Advanced.Pages;
using Mars_Advanced.Pages.HomePage;
using Mars_Advanced.TestData;
using Mars_Advanced.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Steps
{
    [Binding]
     public class ProfileSteps
     {
        private readonly LoginPage _loginPage;
        private readonly NavigationHelper _navigationHelper;
        private readonly Profile _profile;
        private readonly JsonHelpers _jsonhelpers;
        private ProfileData _profiledata;
        public ProfileSteps(LoginPage loginPage, NavigationHelper navigationHelper, Profile profile, JsonHelpers jsonhelpers)
        {
            _loginPage = loginPage;
            _navigationHelper = navigationHelper;
            _profile = profile;
            _jsonhelpers = jsonhelpers;
        }
        
        [When("I choose the availabity")]
        public void WhenIChooseTheAvailabity()
        {
           
            string json = _jsonhelpers.ReadJson("ProfileTestData.json");
            _profiledata = JsonConvert.DeserializeObject<ProfileData>(json);

            string availability = _profiledata.ProfileTests.Availability;

            _profile.SelectAvailability(availability);
            
        }
        [Then("I should see the availability listed")]
        public void ThenIShouldSeeTheAvailabilityListed()
        {
            string availability = _profile.CheckAvailability();
            Assert.That(availability, Is.EqualTo(_profiledata.ProfileTests.Availability));
        }
        [When("I choose the hours")]
        public void WhenIChooseTheHours()
        {
            string json = _jsonhelpers.ReadJson("ProfileTestData.json");
            _profiledata = JsonConvert.DeserializeObject<ProfileData>(json);

            string hours = _profiledata.ProfileTests.Hours;

            _profile.SelectHours(hours);
        }
        [Then("I should see the hours listed")]
        public void ThenIShouldSeeTheHoursListed()
        {
            string hours = _profile.CheckHour();
            Assert.That(hours, Is.EqualTo(_profiledata.ProfileTests.Hours));
        }
        [When("I choose the earn target")]
        public void WhenIChooseTheEarnTarget()
        {
            string json = _jsonhelpers.ReadJson("ProfileTestData.json");
            _profiledata = JsonConvert.DeserializeObject<ProfileData>(json);

            string target = _profiledata.ProfileTests.EarnTarget;

            _profile.SelectTarget(target);

        }
        [Then("I should see earn targets listed")]
        public void ThenIShouldSeeEarnTargetsListed()
        {
            string target = _profile.CheckTarget();
            Assert.That(target, Is.EqualTo(_profiledata.ProfileTests.EarnTarget));
        }


    }

}

