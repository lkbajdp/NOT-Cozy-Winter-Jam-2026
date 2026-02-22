using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreenPrefab;
    private GameObject _currentLoadingScreen;

    private Slider _progressBar;
    private Text _progressText;

    public void LoadScene(string sceneName)
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            return;
        }

        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        if (_loadingScreenPrefab != null)
        {
            _currentLoadingScreen = Instantiate(_loadingScreenPrefab);
            DontDestroyOnLoad(_currentLoadingScreen);

            _progressBar = _currentLoadingScreen.GetComponentInChildren<Slider>();
            _progressText = _currentLoadingScreen.GetComponentInChildren<Text>();
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            if (_progressBar != null)
                _progressBar.value = progressValue;

            if (_progressText != null)
                _progressText.text = (progressValue * 100f).ToString("F0") + "%";

            yield return null;
        }

        if (_loadingScreenPrefab != null)
            Destroy(_currentLoadingScreen);
    }
}