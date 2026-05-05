Feature: Profile

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Successfully add availability
	When I choose the availabity
	Then I should see the availability listed

Scenario: Successfully add hours
	When I choose the hours 
	Then I should see the hours listed

Scenario: Successfully add earn target
	When I choose the earn target
	Then I should see earn targets listed



