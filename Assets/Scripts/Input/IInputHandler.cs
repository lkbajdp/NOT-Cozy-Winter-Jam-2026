using UnityEngine;

public interface IInputHandler
{
    bool TryGetClickPosition(out Vector3 position);
}
