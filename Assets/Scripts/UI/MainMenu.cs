using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private readonly GameManager _gameManager;
    

    public MainMenu(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void PlayGameButtonClick()
    {
        _gameManager.LoadGameScene();
    }

    public void OpenSettingButtonClick()
    {
        _gameManager.LoadSettingScene();
    }

    public void QuitGameButtonClick()
    {
        Application.Quit();
    }
    
}
