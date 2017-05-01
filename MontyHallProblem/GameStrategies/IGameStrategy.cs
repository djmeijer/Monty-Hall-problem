using System.Collections.Generic;

namespace MontyHallProblem.GameStrategies
{
  /// <summary>
  ///   Strategy of the game host, what strategy will he use to determine which door to open next.
  /// </summary>
  public interface IGameStrategy
  {
    int OpenDoor(List<int> doors, int choosenDoor, int winningDoor);
  }
}