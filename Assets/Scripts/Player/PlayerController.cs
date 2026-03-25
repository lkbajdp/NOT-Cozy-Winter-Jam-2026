using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using VContainer;


public class PlayerController
{
    private readonly IPlayer _player;
    private readonly IGridManager _gridManager;
    private readonly IInputHandler _inputHandler;

    
    public PlayerController(IPlayer player, IGridManager gridManager, IInputHandler inputHandler)
    {
        _player = player;
        _gridManager = gridManager;
        _inputHandler = inputHandler;
    }

    public void HandleUpdate()
    {
        if (_player.Movement.IsMoving) return;

        if (_inputHandler.TryGetClickPosition(out Vector3 clickPos))
        {
            Vector2Int targetCell = _gridManager.Converter.WorldToCell(clickPos);

            if (!_gridManager.Data.IsInGrid(targetCell)) return;

            Vector2Int currentCell = _player.GridTracker.CurrentCell;

            List<Vector2Int> path = _gridManager.Pathfinder.FindPath(currentCell, targetCell);

            if (path.Count > 0)
            {
                _player.Movement.MoveAlongPath(path, (cell) =>
                {
                    _player.GridTracker.UpdatePosition(cell);
                });
            }
        }
    }
}
