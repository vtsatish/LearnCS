Feature: SpecialPlayerCharacter
	In order to play game
	As a Specialplayer
	I want to be live till hit completely
	Background: 
	Given I am a new player SpecialNew

	@p0
	Scenario Outline: Taking damage when hit affect health
	When I get <damage> damage
	Then my health should be <remhealth>
	Examples: 
	| PlayerName | damage | remhealth |
	| Dhoni      | 40     | 60        |
	| Sachin     | 20     | 80        |

	@p0 @datetimetest
	Scenario: Reading a restore health scroll when over tired has no effect
	Given I last slept 30 days ago
	When I get 40 damage
	And I read a restore health scroll
	Then my health should be 60