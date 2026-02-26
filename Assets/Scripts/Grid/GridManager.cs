using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }
    public GridData Data { get; private set; }

    [SerializeField] private int _width = 32;
    [SerializeField] private int _height = 32;


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

        Data = new GridData(_width, _height);
    }
}
