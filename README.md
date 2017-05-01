# Monty Hall problem
A simple game. There is a game master and a player, you!
- There are n doors. Let's take n = 3.
- Behind one door there is a price, only the game master knows where it is.
- You must pick a door.
- The game master will open one door. He has two rules:
  1. do not open the winning door
  2. do not open the door picked by the player
- When n > 3 the game master will continue opening doors, given the rules, untill there are 2 doors left.
- Now you have a choice again and this is the main question of the game: do you want to switch? Or: will switching give you a better change of winning?

## Analysis
- Let's take 3 doors.
- 'P' means the door with price and 'Y' means that you picked that door.

This are all the possible scenarios.

| 1 | 2 | 3 |
| ------ | ------ | ------ |
| P,Y | | |
| Y | P | |
| Y | | P |
| P | Y | |
| | P,Y | |
| | Y | P |
| P | | Y |
| | P | Y |
| | | P,Y |

Now the game master must open a door. When we merge the possible scenarios we get to following list.

|  |  | # |
| ------ | ------ | ------ |
| P,Y | | 3x |
| Y | P | 6x |

So now it is trivial to see that switching gives you a 2/3 change of winning.

## What!?
For me this is really counterintuitive. When you take a large number for n, switching gives you a near 100% change of winning the price! Because I couldn't believe my own analysis I decided to make a small C# console program to validate this result and to play a little with different game master strategies.
