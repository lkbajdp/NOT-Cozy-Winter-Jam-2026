using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerMovement : IPlayerMovement
{
    private readonly IGridManager _gridManager;
    private readonly MonoBehaviour _coroutineRunner;
    private readonly Transform _playerTransform;

    private bool _isMoving;

    public bool IsMoving => _isMoving;

    public PlayerMovement(
        IGridManager gridManager,
        MonoBehaviour coroutineRunner,
        Transform playerTransform)
    {
        _gridManager = gridManager;
        _coroutineRunner = coroutineRunner;
        _playerTransform = playerTransform;
    }

    public void MoveAlongPath(List<Vector2Int> path, System.Action<Vector2Int> onCellReached)
    {
        if (_isMoving || path == null || path.Count == 0) return;
        _coroutineRunner.StartCoroutine(MoveCoroutine(path, onCellReached));
    }

    private IEnumerator MoveCoroutine(List<Vector2Int> path, System.Action<Vector2Int> onCellReached)
    {
        _isMoving = true;
        float moveDuration = 0.2f;

        foreach (Vector2Int cell in path)
        {
            Vector3 targetPos = _gridManager.Converter.CellToWorld(cell);

            float elapsed = 0f;
            Vector3 startPos = _playerTransform.position;

            while (elapsed < moveDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / moveDuration;
                _playerTransform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            _playerTransform.position = targetPos;
            onCellReached?.Invoke(cell);
        }

        _isMoving = false;
    }
}