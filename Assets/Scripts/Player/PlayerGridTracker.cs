using UnityEngine;

public class PlayerGridTracker : MonoBehaviour
{
    public Vector2Int CurrentCell { get; private set; }

    public void Initialize(Vector2Int startCell)
    {
        CurrentCell = startCell;
    }

    public void UpdatePosition(Vector2Int newCell)
    {
        CurrentCell = newCell;
    }
}