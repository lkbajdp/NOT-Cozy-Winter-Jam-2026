using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGameButtonClick()
    {
        GameManager.Instance.LoadGameScene();
    }

    public void OpenSettingButtonClick()
    {
        GameManager.Instance.LoadSettingScene();
    }

    public void QuitGameButtonClick()
    {
        Application.Quit();
    }
    
}
