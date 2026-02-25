using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
}
