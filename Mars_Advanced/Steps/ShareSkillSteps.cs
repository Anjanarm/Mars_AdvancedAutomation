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
    public class ShareSkillSteps
    {
        private readonly ShareSkill _shareskill;
        private readonly JsonHelpers _jsonhelpers;
        private ShareSkillData _shareskilldata;
        public ShareSkillSteps(ShareSkill shareskill, JsonHelpers jsonhelpers)
        {
            _shareskill = shareskill;
            _jsonhelpers = jsonhelpers;
        }
        [When("I add all the details for the skill listing")]
        public void WhenIAddAllTheDetailsForTheSkillListing()
        {
           
            string json = _jsonhelpers.ReadJson("ShareSkillData.json");
            _shareskilldata = JsonConvert.DeserializeObject<ShareSkillData>(json);
            _shareskill.ListingDetails(_shareskilldata);

        }
        [Then("Service listing should be added")]
        public void ThenServiceListingShouldBeAdded()
        {
            Assert.That(_shareskill.ListingCheck(_shareskilldata.ShareSkillTests.Title),Is.True,
            "The newly added service listing was not found in the table");
            
        }
        


    }
}