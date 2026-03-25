using UnityEngine;
using System.Collections.Generic;

public interface IPlayerMovement
{
    bool IsMoving { get; }
    void MoveAlongPath(List<Vector2Int> path, System.Action<Vector2Int> onCellReached);
}
