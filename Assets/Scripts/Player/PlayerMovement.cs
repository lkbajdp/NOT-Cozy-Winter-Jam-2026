using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveDuration = 0.2f;
    public bool IsMoving { get; private set; }

    public System.Action<Vector2Int> OnMoveStarted;
    public System.Action<Vector2Int> OnMoveCompleted;

    public IEnumerator MoveToPosition(Vector2Int newPosition, Vector3 startWorldPos, Vector3 endWorldPos)
    {
        if (IsMoving) yield break;

        IsMoving = true;
        OnMoveStarted?.Invoke(newPosition);

        float elapsed = 0f;
        while (elapsed < _moveDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startWorldPos, endWorldPos, elapsed / _moveDuration);
            yield return null;
        }

        transform.position = endWorldPos;
        IsMoving = false;
        OnMoveCompleted?.Invoke(newPosition);
    }

    public void Teleport(Vector3 worldPosition)
    {
        transform.position = worldPosition;
    }
}
