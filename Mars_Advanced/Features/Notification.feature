Feature: Notofication

To verify show less,load more, delete, mark as read, select and unselect features of Notification tab
User1: Jeen(ajvmvp@gmail.com or "I" in background)
User2: Bob(bobtom@gmail.com)

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"
	And Jeen shares skills from "NotificationTestData.json"
	And Bob is logged in using "bobtom@gmail.com" and "43211234" and sends request to Jeen
	And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Verify see all option
	When Jeen click see all option
	Then All notifications listed

Scenario: Verify load more option
	When Jeen clicks load more option
	Then More notification should be loaded

Scenario: Verify see less option
	When Jeen clicks see less option
	Then Notification should be collapsed

Scenario: Verify delete option
	When Jeen deletes the notification
	Then Notification updation message displayed

Scenario: Verify mark as read option
	When Jeen marks the notification as read
	Then Notification icon removed

Scenario: Verify select option
	When Jeen clicks select all option
	Then select option turns blue

Scenario: Verify unselect option
	When Jeen clicks select all option
	And Clicks unselect option
	Then options should not be selected