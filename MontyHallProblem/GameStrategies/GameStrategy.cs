﻿using System.Collections.Generic;

namespace MontyHallProblem.GameStrategies
{
  /// <summary>
  ///   Strategy of the game host, what strategy will he use to determine which door to open next.
  /// </summary>
  public abstract class GameStrategy
  {
    public abstract int OpenDoor(List<int> doors, int choosenDoor, int winningDoor);

    public abstract override string ToString();
  }
}