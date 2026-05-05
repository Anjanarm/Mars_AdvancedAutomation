Feature: ShareSkill

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Successfully share a skill
	When I add all the details for the skill listing
	Then Service listing should be added