Feature: Skill

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Successfully add a skill
	Given I load all skill details from "SkillTestData.json" for "ValidSkill"
	When I add all skill entries
	Then I should see the skill added

Scenario: Fail adding skill with empty fields
	Given I load all skill details from "SkillTestData.json" for "InvalidSkill"
	When I add all skill entries
	Then I should see a skill error message

Scenario: Fail adding skill with duplicate data
	Given I load all skill details from "SkillTestData.json" for "DuplicateData"
	When I add all skill entries
	Then I should see duplicate skill message

Scenario: Edit an existing skill
	Given I load all skill details from "SkillTestData.json" for "EditData"
	When I add the original skill entry
	And I edit with updated skill entry
	Then I should see the updated skill

Scenario: Delete an existing skill
	Given I load all skill details from "SkillTestData.json" for "DeleteData"
	When I add all skill entries
	And I delete added skill 
	Then I should see the skill field removed
