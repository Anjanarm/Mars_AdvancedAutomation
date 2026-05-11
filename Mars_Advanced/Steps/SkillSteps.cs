using Mars_Advanced.Pages;
using Mars_Advanced.Pages.HomePage;
using Mars_Advanced.TestData;
using Mars_Advanced.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RazorEngine;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Steps
{
    [Binding]
    public class SkillSteps
    {
        private readonly LoginPage _loginPage;
        private readonly Skill _skill;
        private readonly NavigationHelper _navigationHelper;
        private readonly BasePage _basePage;
        //private readonly IWebDriver _driver;
        private List<SkillData> _skillList;
        private List<SkillEditData> _editSkillList;
        private SkillData _updateData;
        public SkillSteps(LoginPage loginPage, Skill skill, NavigationHelper navigationHelper, BasePage basePage)
        {
            _loginPage = loginPage;
            _skill = skill;
            _navigationHelper = navigationHelper;
            _basePage = basePage;
        }
        [Given("I load all skill details from {string} for {string}")]
        public void GivenILoadAllSkillDetailsFromFor(string filename, string data)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string skillPath = Path.Combine(currentDir, "TestData", "SkillTestData.json");

            string json = File.ReadAllText(skillPath);
            //_testdata = JsonSerializer.Deserialize<TestSettings>(json);
            var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data == "EditData")
            {
                _editSkillList = JsonConvert.DeserializeObject<List<SkillEditData>>(allData[data].ToString());
            }
            else
            {
                _skillList = JsonConvert.DeserializeObject<List<SkillData>>(allData[data].ToString());
            }

        }
        [When("I add all skill entries")]
        public void WhenIAddAllSkillEntries()
        {
            foreach (var skill in _skillList)
            {
                _skill.AddSkill(skill);
            }
        }
        [Then("I should see the skill added")]
        public void ThenIShouldSeeTheSkillAdded()
        {
            foreach (var skill in _skillList)
            {
                bool skillExists = _skill.SkillExists(skill);
                if (!skillExists)
                    throw new Exception(skill.Skill + " not found");
            }

        }
        [Then("I should see a skill error message")]
        public void ThenIShouldSeeASkillErrorMessage()
        {
            string errorMessage = _basePage.PopUpMessage();
            Assert.That(errorMessage, Is.EqualTo("Please enter skill and experience level"));
        }

        [Then("I should see duplicate skill message")]
        public void ThenIShouldSeeDuplicateSkillMessage()
        {
            string duplicateMessage = _basePage.PopUpMessage();
            Assert.That(duplicateMessage, Is.EqualTo("This skill is already exist in your skill list."));

        }
        [When("I delete added skill")]
        public void WhenIDeleteAddedSkill()
        {
            _skill.DeleteSkill();
        }
        [Then("I should see the skill field removed")]
        public void ThenIShouldSeeTheSkillFieldRemoved()
        {
            string deleteMessage = _basePage.PopUpMessage();
            Assert.That(deleteMessage.ToLower(), Does.Contain("deleted"));
        }
        [When("I add the original skill entry")]
        public void WhenIAddTheOriginalSkillEntry()
        {
            foreach (var editSkill in _editSkillList)
            {
                _skill.AddSkill(editSkill.Original);
            }
        }
        [When("I edit with updated skill entry")]
        public void WhenIEditWithUpdatedSkillEntry()
        {
            foreach (var editSkill in _editSkillList)
            {
                _skill.EditSkill(editSkill.Updated);
                _updateData = editSkill.Updated;
            }
        }
        [Then("I should see the updated skill")]
        public void ThenIShouldSeeTheUpdatedSkill()
        {
            string updatedMessage = _basePage.PopUpMessage();
            Assert.That(updatedMessage, Is.EqualTo(_updateData.Skill + " has been updated to your skills"));
        }

    }
}
