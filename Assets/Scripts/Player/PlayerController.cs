using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        CheckAndMove();
    }


    private void CheckAndMove()
    {
        if (Player.Instance.Movement.IsMoving) return;

        if (Player.Instance.Input.TryGetClickPosition(out Vector3 clickPos))
        {
            Vector2Int targetCell = GridManager.Instance.Converter.WorldToCell(clickPos);
            Vector2Int currentCell = Player.Instance.GridTracker.CurrentCell;

            if (!GridManager.Instance.Data.IsInGrid(targetCell)) return;

            List<Vector2Int> path = GridManager.Instance.Pathfinder.FindPath(currentCell, targetCell);

            if (path.Count > 0)
            {
                Player.Instance.Movement.MoveAlongPath(path);
            }
        }
    }
}
