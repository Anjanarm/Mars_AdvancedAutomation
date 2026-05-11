Feature: SearchSkill

Search Skill by AllCategories, by SubCategories, by filters

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Search a skill using AllCategories
	Given I add a skill
	When I search a skill by category
	Then I should see the intended skill listed

Scenario: Search a skill using SubCategories
	Given I add a skill
	When I search a skill by subcategory
	Then I should see the intended skill listed

Scenario: Search a skill using Filters
	Given I add a skill
	When I search a skill by filter
	Then I should see the intended skill listed


