using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private SceneLoader sceneLoader;
    private GameState currentState;

    public GameState CurrentState => currentState;
    public event System.Action<GameState> OnStateChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        OnStateChanged?.Invoke(newState);
    }

    public void LoadMainMenu() => sceneLoader.LoadScene("MainMenu");
    public void LoadGameScene() => sceneLoader.LoadScene("Game");
    public void LoadSettingScene() => sceneLoader.LoadScene("Setting");
    public void QuitGame() => Application.Quit();
}