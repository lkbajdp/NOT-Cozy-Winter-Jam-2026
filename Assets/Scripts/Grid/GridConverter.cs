using UnityEngine;

public class GridConverter : MonoBehaviour
{
    private float _cellSize;
    private Vector2 _origin;
    public float CellSize => _cellSize;

    public GridConverter(float cellSize, Vector2 origin)
    {
        _cellSize = cellSize;
        _origin = origin;
    }

    public Vector2Int WorldToCell(Vector3 worldPosition)
    {
        int cellX = Mathf.FloorToInt((worldPosition.x - _origin.x) / _cellSize);
        int cellY = Mathf.FloorToInt((worldPosition.y - _origin.y) / _cellSize);

        return new Vector2Int(cellX, cellY);
    }

    public Vector3 CellToWorld(Vector2Int cellPosition)
    {
        float worldX = _origin.x + (cellPosition.x + 0.5f) * _cellSize;
        float worldY = _origin.y + (cellPosition.y + 0.5f) * _cellSize;
        float worldZ = 0f;

        return new Vector3(worldX, worldY, worldZ);
    }
}
