using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallProblem.GameStrategies;

namespace MontyHallProblem
{
  public class Program
  {
    static void Main()
    {
      IGameStrategy strategy = new RandomDoorStrategy();
      //IGameStrategy strategy = new NonSelectedDoorStrategy();
      //IGameStrategy strategy = new NonWinningDoorStrategy();
      //IGameStrategy strategy = new NonWinningNonSelectedDoorStrategy();
      int gamesPerLoop = 10000;
      int numberOfDoors = 3;

      int winnings = 0;
      int losses = 0;
      while(true)
      {
        for(int i = 0; i < gamesPerLoop; i++)
        {
          bool gameEnded = false;
          List<int> doors = GetDoors(numberOfDoors);
          int winningDoor = SelectRandomDoorNumber(doors);
          int choosenDoor = SelectRandomDoorNumber(doors);

          while(doors.Count > 2 && !gameEnded)
          {
            int doorToOpenNext = strategy.OpenDoor(doors, winningDoor, choosenDoor);
            gameEnded = doorToOpenNext == winningDoor || doorToOpenNext == choosenDoor;
            doors.Remove(doorToOpenNext);
          }

          if(!gameEnded)
          {
            choosenDoor = doors.First(n => n != choosenDoor);
            bool winst = choosenDoor == winningDoor;

            if(winst)
            {
              winnings++;
            }
            else
            {
              losses++;
            }
          }
        }
        Console.WriteLine($"{winnings}+, {losses}-, {100*winnings/(winnings+losses)}% win");
        Console.ReadKey();
      }
    }

    private static List<int> GetDoors(int n)
    {
      var doorNumbers = new List<int>();
      for(int i = 0; i < n; i++)
      {
        doorNumbers.Add(i + 1);
      }
      return doorNumbers;
    }

    private static int SelectRandomDoorNumber(List<int> doorNumbers) => doorNumbers.OrderBy(i => Guid.NewGuid()).First();
  }
}