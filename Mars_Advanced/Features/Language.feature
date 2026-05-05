Feature: Language

To verify the list language feature
Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Successfully add a language
	Given I load all language details from "LanguageTestData.json" for "ValidLanguage"
	When I add all language entries
	Then I should see the languages added

Scenario: Fail adding language with empty fields
	Given I load all language details from "LanguageTestData.json" for "InvalidLanguage"
	When I add all language entries
	Then I should see an error message

Scenario: Fail adding language with duplicate data
	Given I load all language details from "LanguageTestData.json" for "DuplicateData"
	When I add all language entries
	Then I should see duplicate data message

Scenario: Edit an existing language
	Given I load all language details from "LanguageTestData.json" for "EditData"
	When I add the original language entry
	And I edit with updated language entry
	Then I should see the updated language

Scenario: Delete an existing language
	Given I load all language details from "LanguageTestData.json" for "DeleteData"
	When I add all language entries
	And I delete added language 
	Then I should see the language field removed

