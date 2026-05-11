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
    public class SearchSkillSteps
    {
        private readonly ShareSkill _shareskill;
        private readonly SearchSkill _searchskill;
        private readonly JsonHelpers _jsonhelpers;
        private ShareSkillData _shareskilldata;
        public SearchSkillSteps(ShareSkill shareskill, JsonHelpers jsonhelpers,SearchSkill searchskill)
        {
            _shareskill = shareskill;
            _jsonhelpers = jsonhelpers;
            _searchskill = searchskill;
        }
        [Given("I add a skill")]
        public void GivenIAddASkill()
        {
            string json = _jsonhelpers.ReadJson("ShareSkillData.json");
            _shareskilldata = JsonConvert.DeserializeObject<ShareSkillData>(json);
            _shareskill.ListingDetails(_shareskilldata);
        }

        [When("I search a skill by category")]
        public void WhenISearchASkillBycategory()
        {
            _searchskill.SearchSkillByCategory();
        }

        [Then("I should see the intended skill listed")]
        public void ThenIShouldSeeTheIntendedSkillListed()
        {
            Assert.That(_searchskill.CheckSkillExists(_shareskilldata.ShareSkillTests.Title), Is.True,
            "The skill cant be found");
        }
        [When("I search a skill by subcategory")]
        public void WhenISearchASkillBySubcategory()
        {
            _searchskill.SearchSkillBySubCategory();
        }
        [When("I search a skill by filter")]
        public void WhenISearchASkillByFilter()
        {
            _searchskill.SearchSkillByFilter(_shareskilldata.ShareSkillTests.Filter);
        }
    }
}
