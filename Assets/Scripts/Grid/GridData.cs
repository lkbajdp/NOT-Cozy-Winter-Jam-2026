using UnityEngine;

public class GridData
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Tile[,] _tiles;

    public GridData(int width, int height)
    {
        Width = width;
        Height = height;

        _tiles = new Tile[Width, Height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = new Tile(new Vector2Int(x, y));
            }
        }
    }

    public Tile GetTile(Vector2Int coordinate)
    {
        return _tiles[coordinate.x, coordinate.y];
    }

    public bool IsInGrid(Vector2Int coordinate)
    {
        return (coordinate.x >= 0 && coordinate.x < Width && coordinate.y >= 0 && coordinate.y < Height);
    }
}
