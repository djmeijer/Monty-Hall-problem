# Monty-Hall-problem
A simple game. There is a game master and a player, you!
- There are n doors. Let's take n = 3.
- Behind one door there is a price, only the game master knows where it is.
- You must pick a door.
- The game master will open one door. He has two rules:
  1. do not open the winning door
  2. do not open the door picked by the player
- In a generalized version the game master will continue opening doors, given the rules, untill there are 2 doors left.
- Now you have a choice again and this is the main question of the game: there are 2 doors left, do you want to switch?

## Analysis
- Let's take 3 doors.
- 'P' means door with price and 'Y' means that you picked that door.

This are all the possible scenarios.

| 1 | 2 | 3 |
| ------ | ------ | ------ |
| P,Y | | |
| Y | P | |
| Y | | P |
| P | Y | |
| | P,Y | |
| | | P,Y |
| P | | Y |
| | P | Y |
| | | P,Y |

Now the game master must open a door. When we merge to possible scenarios we get to following list.

|  |  | # |
| ------ | ------ | ------ |
| P,Y | | 3x |
| Y | P | 6x |

So now it is easy to see that switching gives you a 2/3 change of winning.

## What!?

For me this is really counterintuitive so I made a small C# console program to validate this result and to play a little with different game master strategies.
