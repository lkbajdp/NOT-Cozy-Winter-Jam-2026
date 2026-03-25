using System;
using UnityEngine;
using VContainer;


public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private PlayerInputHandler _inputHandler;
    [SerializeField] private PlayerGridTracker _gridTracker;

    private PlayerMovement _movement;

    public PlayerMovement Movement => _movement;

    public PlayerInputHandler InputHandler => _inputHandler;
    public PlayerGridTracker GridTracker => _gridTracker;

    private IGridManager _gridManager;


    [Inject]
    public void Construct(IGridManager gridManager)
    {
        _gridManager = gridManager;
        _movement = new PlayerMovement(gridManager, this, transform);
    }

    private void Start()
    {
        if (_gridManager == null || !_gridManager.IsInitialized)
        {
            Debug.Log("NOT GridManager in Player");
            return;
        }

        Vector2Int startCellPosition = _gridManager.Converter.WorldToCell(transform.position);
        _gridTracker.Initialize(startCellPosition);
    }

    public void SetPosition(Vector2Int cellPosition)
    {
        transform.position = _gridManager.Converter.CellToWorld(cellPosition);
        _gridTracker.UpdatePosition(cellPosition);
    }

    private void OnDestroy()
    {
        (_movement as IDisposable)?.Dispose();
    }
}
