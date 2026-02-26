using UnityEngine;

public class GridData : MonoBehaviour
{
    public int Width { get; }
    public int Height { get; }

    public GridData(int width, int height)
    {
        Width = width;
        Height = height;
    }
}
