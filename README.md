# 2024fa-475-Droll

----------Controls----------

Red(left):
WS - control player verticlly
	selector verticlly based on player position
AD - control selector horizontally
1 - spawns barrior unit at the cost of 40
2 - spawns shooter unit at the cost of 30
3 - spawns walker unit at the cost of 60
4 - spawns runner unit at the cost of 50
Z - Heal buff for current row friendly units
X - Atk against current row enemy units
C - speed buff for current row friendly offensive units

Blue(right):
up/down arrows - control player verticlly
	selector verticlly based on player position
left/right arrors - control selector horizontally
num1 - spawns barrior unit at the cost of 40
num2 - spawns shooter unit at the cost of 30
num3 - spawns walker unit at the cost of 60
num4 - spawns runner unit at the cost of 50
num7 - Heal buff for current row friendly units
num8 - Atk against current row enemy units
num9 - speed buff for current row friendly offensive units


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

Units, when destroyed, give half of their cost to the opposing side, even if destroy by netrual units


Netrual Units spawn periodically
	two walkers will spawn 1 going after each base
	less often, up to 2 shooters will spawn, these face a random direction
		a shooter will not spawn if its random slot is already filled

Occassionally, a boss unit will spawn
	while this unit has a lot of health, which ever side kills it gets a large amount of money
	The boss will periodically send devistating attacks to both sides, beware!
		these attacks deal 50% of the hit units max hp, inluding barriors
//

Actions:
each player has access to player actions,
each action effects all apporopriate units in the players current row

Heal Buff - Heals all friendly units by max hp, this hp can go over max hp
AOE Attack - Deals 70% of enemies max hp, also destroys bullets, doesnt effect boss
Speed Buff - Doubles the speed of any friendly offensive unit, falls off if unit backs up
