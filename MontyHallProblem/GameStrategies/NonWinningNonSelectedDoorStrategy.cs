using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblem.GameStrategies
{
  public class NonWinningNonSelectedDoorStrategy : GameStrategy
  {
    public override int OpenDoor(List<int> doors, int choosenDoor, int winningDoor)
    {
      return doors.Where(n => n != choosenDoor && n != winningDoor).OrderBy(d => Guid.NewGuid()).First();
    }

    public override string ToString() => "Open random door, but not winning nor selected door";
  }
}