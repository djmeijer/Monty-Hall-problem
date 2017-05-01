using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblem.GameStrategies
{
  public class RandomDoorStrategy : IGameStrategy
  {
    public int OpenDoor(List<int> doors, int choosenDoor, int winningDoor)
    {
      return doors.OrderBy(d => Guid.NewGuid()).First();
    }
  }
}