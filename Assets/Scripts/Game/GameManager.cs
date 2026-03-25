using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameManager : IInitializable, ITickable
{
    private readonly IPlayer _player;
    private readonly IGridManager _gridManager;
    private readonly SceneLoader _sceneLoader;
    private readonly PlayerController _playerController;

    private GameState _currentState;

    public GameManager(
        IPlayer player,
        IGridManager gridManager,
        SceneLoader sceneLoader,
        PlayerController playerController
        )
    {
        _player = player;
        _gridManager = gridManager;
        _sceneLoader = sceneLoader;
        _playerController = playerController;
        _currentState = GameState.MainMenu;
    }

    public void Initialize()
    {
        Debug.Log("GameManager инициализирвоан");
        ChangeState(GameState.Playing);
    }

    public void Tick()
    {
        if (_currentState == GameState.Playing)
        {
            _playerController.HandleUpdate();
        }
    }

    public void ChangeState(GameState newState)
    {
        _currentState = newState;
        Debug.Log($"State is changed:{newState} ");
    }

    public void LoadGameScene()
    {
        _sceneLoader.LoadScene("Gamee");
    }

    public void LoadSettingScene()
    {
        _sceneLoader.LoadScene("Setting");
    }
}