Feature: OpenAvito
	I need start work with Avito services in browser

@test
Scenario: OpenAvito
	When I start browser
	And I open login page
	And I enter with "wrong" login and password
	Then I see "wrong credentials" message


