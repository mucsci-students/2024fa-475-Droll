# 2024fa-475-Droll

----------Controls----------

Red(left):
WS - control player verticlly
	selector verticlly based on player position
AD - control selector horizontally
1 - moves unit selector to the left
2 - places unit selected
3 - moves unit selector to the right
Z - Heal buff for current row friendly units
X - Atk against current row enemy units
C - speed buff for current row friendly offensive units

Blue(right):
up/down arrows - control player verticlly
	selector verticlly based on player position
numleft/right arrors - control selector horizontally
num1 - moves unit selector to the left
num2 - places unit selected
num3 - moves unit selector to the right
num4 - Heal buff for current row friendly units
num5 - Atk against current row enemy units
num6 - speed buff for current row friendly offensive units


----------How to play----------
Setup:
Get 2 people,
one player controls left half of keyboard
other controls right
Your goal is to reduce the other players health to 0

Units:
Each player has access to offensive and defensive units
Defesives units are the BARRIOR and SHOOTER, these units take up a grid slot and 2 cannot occupy the same spot
	*shooters fire bullets which can be thought of as offensive units
	*Barriors are immune to bullets
Offensive units are the WALKER and RUNNER, these units advance towards the enemy attacking enemy units and base if reached
	*offensive units of the same type will always kill eachother

Units, when destroyed, give half of their cost to the opposing side, even if destroy by netrual units
	barriors cost 40
	shooters cost 30
	walkers cost 60
	runners cost 50

Netrual Units spawn periodically
	two walkers will spawn 1 going after each base
	less often, up to 2 shooters will spawn, these face a random direction
		a shooter will not spawn if its random slot is already filled

Occassionally, a boss unit will spawn
	while this unit has a lot of health, which ever side kills it gets a large amount of money
	The boss will periodically send devistating attacks to both sides, beware!
		these attacks deal 50% of the hit units max hp, inluding barriors

Actions:
each player has access to player actions,
each action effects all apporopriate units in the players current row

Heal Buff - Heals all friendly units by max hp, this hp can go over max hp
AOE Attack - Deals 70% of enemies max hp, also destroys bullets, doesnt effect boss
Speed Buff - Doubles the speed of any friendly offensive unit, falls off if unit backs up
