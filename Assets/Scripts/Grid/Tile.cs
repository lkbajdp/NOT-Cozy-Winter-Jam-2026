using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int position { get; private set; }
    public bool isWalkable { get;  set; }
    public bool isObstacle { get; set; }
    public GameObject obstacleObject { get; set; }


    public Tile(Vector2Int position)
    {
        this.position = position;
        isWalkable = true;
        isObstacle = false;
        obstacleObject = null;
    }
}
