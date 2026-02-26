using UnityEngine;
using System.Collections;
using UnityEngine.Accessibility;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveDuration = 0.2f;

    public bool IsMoving { get; private set; }

    public event System.Action<Vector2Int> OnMoveCompleted;


    public void MoveAlongPath(List<Vector2Int> path)
    {
        if (IsMoving || path == null || path.Count == 0) return;
        StartCoroutine(MoveCoroutine(path));
    }

    private IEnumerator MoveCoroutine(List<Vector2Int> path)
    {
        IsMoving = true;

        foreach (Vector2Int cell in path)
        {
            Vector3 targetPos = GridManager.Instance.Converter.CellToWorld(cell);

            float elapsed = 0f;
            Vector3 startPos = transform.position;

            while (elapsed < _moveDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / _moveDuration;
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            transform.position = targetPos;

            Player.Instance.GridTracker.UpdatePosition(cell);

            Debug.Log($"({cell.x}, {cell.y})");
        }

        IsMoving = false;
    }
}
