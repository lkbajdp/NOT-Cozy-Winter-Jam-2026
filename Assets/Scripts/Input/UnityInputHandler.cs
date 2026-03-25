using UnityEngine;
using UnityEngine.InputSystem;


public class UnityInputHandler : IInputHandler
{
    private readonly Camera _camera;

    public UnityInputHandler(Camera camera)
    {
        _camera = camera;
    }

    public bool TryGetClickPosition(out Vector3 position)
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            position = Vector3.zero;
            return false;
        }

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        position = _camera.ScreenToWorldPoint(new Vector3(
            mouseScreenPosition.x,
            mouseScreenPosition.y,
            -_camera.transform.position.z));

        return true;
    }
}
