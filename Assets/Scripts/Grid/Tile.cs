using UnityEngine;

public class Tile
{
    public Vector2Int Position { get; private set; }
    public bool IsWalkable { get;  set; }
    public bool IsObstacle { get; set; }
    public GameObject ObstacleObject { get; set; }


    public Tile(Vector2Int position)
    {
        Position = position;
        IsWalkable = true;
        IsObstacle = false;
        ObstacleObject = null;
    }
}
