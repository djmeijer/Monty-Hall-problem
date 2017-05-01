﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHallProblem.GameStrategies
{
  public class NonWinningNonSelectedDoorStrategy : IGameStrategy
  {
    public int OpenDoor(List<int> doors, int choosenDoor, int winningDoor)
    {
      return doors.Where(n => n != choosenDoor && n != winningDoor).OrderBy(d => Guid.NewGuid()).First();
    }
  }
}