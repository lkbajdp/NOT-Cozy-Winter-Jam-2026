using UnityEngine;

public class GridData : MonoBehaviour
{
    public int Width { get; }
    public int Height { get; }

    private Tile[,] _tile;

    public GridData(int width, int height)
    {
        Width = width;
        Height = height;

        _tile = new Tile[this.Width, this.Height];
    }

    private Tile GetTile(int x, int y)
    {
        return _tile[x, y];
    }
}
