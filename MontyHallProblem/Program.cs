using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MontyHallProblem.GameStrategies;

namespace MontyHallProblem
{
  public class Program
  {
    static void Main()
    {
      const int gamesPerLoop = 1000000;
      const int numberOfDoors = 3;

      List<GameStrategy> strategies = new List<GameStrategy>
      {
        new RandomDoorStrategy(),
        new NonSelectedDoorStrategy(),
        new NonWinningDoorStrategy(),
        new NonWinningNonSelectedDoorStrategy()
      };

      Console.WriteLine($"So we play the game with {numberOfDoors} doors and we repeat it {gamesPerLoop} times to collect the data.");
      Console.WriteLine($"We use {strategies.Count} different opening strategies.");
      Console.WriteLine("Now the question is whether you get a better change of winning when you switch to the other door at the final step in the game.\n");

      foreach(GameStrategy strategy in strategies)
      {
        int winnings = 0;
        int losses = 0;

        Parallel.For(0, gamesPerLoop, i =>
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
            var newChoosenDoor = doors.First(d => d != choosenDoor);
            bool winst = newChoosenDoor == winningDoor;

            if(winst)
            {
              Interlocked.Increment(ref winnings);
            }
            else
            {
              Interlocked.Increment(ref losses);
            }
          }
        });

        Console.WriteLine($"{strategy}: {winnings}+, {losses}-, {100 * winnings / (winnings + losses)}% win");
      }

      Console.WriteLine("\nDone! (press a key)");
      Console.ReadKey();
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