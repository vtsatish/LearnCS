Feature: RestTest
	In order to use API
	As a Engineer
	I want to call REST

@mytag
Scenario: Call REST API to get the list of employees
	Given I have client ready
	When I execute the client
	Then the response should be successful

@mytag
Scenario: Call REST API to validate the employee
	Given I have client ready
	When I execute the client
	Then the response should contain employee id 1