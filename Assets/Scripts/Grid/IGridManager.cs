using UnityEngine;


public interface IGridManager
{
    GridData Data { get; }
    GridConverter Converter { get; }
    Pathfinder Pathfinder { get; }
    bool IsInitialized { get; }
}
