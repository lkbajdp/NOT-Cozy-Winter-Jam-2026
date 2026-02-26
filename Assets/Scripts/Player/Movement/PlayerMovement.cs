using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveDuration = 0.2f;

    public bool IsMoving { get; private set; }

    public event System.Action<Vector2Int> OnMoveCompleted;


    public IEnumerator MoveCoroutine(Vector3 targetWorldPosition, Vector2Int targetCellPosition)
    {
        IsMoving = true;
        Vector3 currentWorldPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < _moveDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(currentWorldPosition, targetWorldPosition, elapsed / _moveDuration);
            yield return null;
        }

        transform.position = targetWorldPosition;
        IsMoving = false;
        OnMoveCompleted?.Invoke(targetCellPosition);
    }

    public void MoveToCell(Vector2Int targetCellPosition)
    {
        if (IsMoving) return;

        Vector3 targetWorldPosition = GridManager.Instance.Converter.CellToWorld(targetCellPosition);
        StartCoroutine(MoveCoroutine(targetWorldPosition, targetCellPosition));
    }
}
