using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public bool TryGetClickPosition(out Vector3 position)
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            position = Vector3.zero;
            return false;
        }

        else
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

            position = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

            Debug.Log(position);

            return true;
        }
    }
}
