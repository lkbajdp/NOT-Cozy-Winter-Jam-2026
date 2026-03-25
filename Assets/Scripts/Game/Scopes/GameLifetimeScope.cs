using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [Header("Prefabs")]
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private GridManager _gridManagerPrefab;

    [Header("Scenes")]
    [SerializeField] private string _gameSceneName = "Game";

    [Header("Camera")]
    [SerializeField] private Camera _camera;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SceneLoader>(Lifetime.Singleton)
            .WithParameter("gameSceneName", _gameSceneName);

        builder.Register<UnityInputHandler>(Lifetime.Singleton)
               .WithParameter("camera", _camera)
               .As<IInputHandler>();

        builder.RegisterComponentInNewPrefab(_gridManagerPrefab, Lifetime.Singleton)
            .AsImplementedInterfaces();

        builder.RegisterComponentInNewPrefab(_playerPrefab, Lifetime.Singleton)
            .AsImplementedInterfaces();

        builder.Register<PlayerController>(Lifetime.Singleton);

        builder.RegisterEntryPoint<GameManager>().WithParameter("initialState", GameState.Playing);
    }
}
