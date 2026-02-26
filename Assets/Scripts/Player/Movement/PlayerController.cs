using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _input;
    [SerializeField] private PlayerMovement _movement;

    private void Update()
    {
        CheckAndMove();
    }


    private void CheckAndMove()
    {
        if (_input.TryGetClickPosition(out Vector3 position))
        {
            Vector2Int targetPosition = GridManager.Instance.Converter.WorldToCell(position);

            if (GridManager.Instance.Data.IsInGrid(targetPosition))
            {
                StartCoroutine(_movement.MoveCoroutine(position));
            }
        }
    }
}
