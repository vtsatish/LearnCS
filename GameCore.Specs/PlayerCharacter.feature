Feature: PlayerCharacter
	In order to play game
	As a player
	I want to be live till hit completely
	Background: 
	Given I am a new player 'NEW'


	Scenario: Taking too much damage could result in player death
	When I get 20 damage
	And I get 90 damage
	Then my health should be 0
	And player is dead

	@p0
	Scenario: Taking damage with weapon
	When I get hit with the following weapons:
	| weapon	|
	| gun	|
	| knife     |
	Then my health should not be 0
	Then my safestring is Before

	Scenario: Healers restore all Health
	Given My Character is set as Healer
	When I get 20 damage
	And I get the HealingSpell
	Then my health should be 100
	Then my safestring is Healer

	@elftests @p0
	Scenario: Elf race characters get additional damage resistance using data table
	And I have the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |
	When I get 40 damage
	Then my health should be 90

	Scenario: Total magical power
	Given I have the following magical items
	| name   | value | power |
	| Ring   | 200   | 100   |
	| Amulet | 400   | 200   |
	| Gloves | 100   | 400   |
	Then My total magical power should be 700





	Scenario: Reading a restore health scroll when less tired has health back
	Given I last slept 1 days ago
	When I get 40 damage
	And I read a restore health scroll
	Then my health should be 100

	@p0
	Scenario: Weapons are worth money
	Given I have the following weapons
	| name  | value |
	| Sword | 50    |
	| Pick  | 40    |
	| Knife | 10    |
	And I get the below weapon
	| name  | value |
	| rifle | 100   |
	Then My weapons should be worth 200

	@elftests
	Scenario: Elf race characters don't lose magical item power
	Given I belong to Elf Race
	And I have an Amulet with a power of 200
	And I have an Pendant with a power of 500
	When I use a magical Amulet
	And I use a magical Pendant
	Then The magical power is reduced FALSE

	@elftests @ignore
	Scenario: nonElf race characters lose magical item power
	Given I belong to nonElf Race
	And I have an Amulet with a power of 200
	And I have an Pendant with a power of 500
	When I use a magical Amulet
	And I use a magical Pendant
	Then The magical power is reduced TRUE