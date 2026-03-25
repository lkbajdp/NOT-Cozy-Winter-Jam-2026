using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class SceneLoader
{
    private readonly string _gameSceneName;
    private GameObject _loadingScreenPrefab;

    public SceneLoader(string gameSceneName)
    {
        _gameSceneName = gameSceneName;

        //_loadingScreenPrefab = Resources.Load<GameObject>("UI/LoadingScreen");
    }

    public void LoadScene(string sceneName)
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError($"scena(scene) {sceneName} is not foudn!");
            return;
        }

        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}