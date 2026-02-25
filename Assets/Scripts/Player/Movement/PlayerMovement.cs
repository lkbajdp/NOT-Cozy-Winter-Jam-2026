using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveDuration = 0.2f;

    public bool isMoving { get; private set; }


    public IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        if (isMoving) yield break;

        isMoving = true;
        Vector3 currentPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < _moveDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsed / _moveDuration);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
