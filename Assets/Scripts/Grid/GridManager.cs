using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }
    public GridData Data { get; private set; }
    public GridConverter Converter { get; private set; }
    public Pathfinder Pathfinder { get; private set; }

    [SerializeField] private int _width = 32;
    [SerializeField] private int _height = 32;
    [SerializeField] private float _cellSize = 1f;
    [SerializeField] private Vector2 _origin = new Vector2Int(0, 0);


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            Instance = this;
        }

        Data = new GridData(_width, _height);
        Converter = new GridConverter(_cellSize, _origin);
        Pathfinder = new Pathfinder(this);
    }
}
