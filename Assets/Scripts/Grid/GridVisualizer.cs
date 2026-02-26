using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Color _gridColor = Color.white;
    [SerializeField] private bool _showInGame = false;

    private void OnDrawGizmos()
    {
        if (_gridManager == null) return;

        if (Application.isPlaying && !_showInGame) return;

        Gizmos.color = _gridColor;

        for (int x = 0; x < _gridManager.Data.Width; x++)
        {
            for (int y = 0; y < _gridManager.Data.Height; y++)
            {
                Vector3 center = _gridManager.Converter.CellToWorld(new Vector2Int(x, y));
                Vector3 size = Vector3.one * _gridManager.Converter.CellSize;

                Gizmos.DrawWireCube(center, size);
            }
        }
    }
}
