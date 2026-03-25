using UnityEngine;
using VContainer;


public class GridManager : MonoBehaviour, IGridManager
{
    [SerializeField] private int _width = 32;
    [SerializeField] private int _height = 32;
    [SerializeField] private float _cellSize = 1f;
    [SerializeField] private Vector2 _origin = new Vector2Int(0, 0);

    public GridData Data { get; private set; }
    public GridConverter Converter { get; private set; }
    public Pathfinder Pathfinder { get; private set; }
    public bool IsInitialized { get; private set; }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Data = new GridData(_width, _height);
        Converter = new GridConverter(_cellSize, _origin);
        Pathfinder = new Pathfinder(this);
        IsInitialized = true;

        Debug.Log($"GridManager инициализирован: {_width}x{_height}");
    }
}
