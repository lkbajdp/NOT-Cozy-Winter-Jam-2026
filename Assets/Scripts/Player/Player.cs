using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerInputHandler Input { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerGridTracker GridTracker { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        Input = GetComponent<PlayerInputHandler>();
        Movement = GetComponent<PlayerMovement>();
        GridTracker = GetComponent<PlayerGridTracker>();
    }

    private void Start()
    {
        if (GridManager.Instance == null)
        {
            return;
        }

        Vector2Int startCell = GridManager.Instance.Converter.WorldToCell(transform.position);
        GridTracker.Initialize(startCell);
    }
}
