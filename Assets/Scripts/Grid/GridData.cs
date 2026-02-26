using UnityEngine;

public class GridData : MonoBehaviour
{
    public int Width { get; }
    public int Height { get; }

    private Tile[,] _tiles;

    public GridData(int width, int height)
    {
        Width = width;
        Height = height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = new Tile(new Vector2Int(x, y));
            }
        }
    }

    private Tile GetTile(Vector2Int coordinate)
    {
        return _tiles[coordinate.x, coordinate.y];
    }

    public bool IsInGrid(Vector2Int coordinate)
    {
        return (coordinate.x <= 0 && coordinate.x < Width && coordinate.y >= 0 && coordinate.y < Height);
    }
}
