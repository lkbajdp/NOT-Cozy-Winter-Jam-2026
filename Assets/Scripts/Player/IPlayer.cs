using UnityEngine;


public interface IPlayer
{
    PlayerMovement Movement { get; }
    PlayerInputHandler InputHandler { get; }
    PlayerGridTracker GridTracker { get; }

    void SetPosition(Vector2Int cellPosition);

}
