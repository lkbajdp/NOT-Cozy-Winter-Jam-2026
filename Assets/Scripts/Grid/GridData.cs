using UnityEngine;

public class GridData : MonoBehaviour
{
    public int width { get; }
    public int height { get; }

    private Tile[,] _tile;

    public GridData(int width, int height)
    {
        this.width = width;
        this.height = height;

        _tile = new Tile[this.width, this.height];
    }

    private Tile GetTile(int x, int y)
    {
        return _tile[x, y];
    }
}
