using UnityEngine;
//using VContainer.Unity;

public class GameBootstrapper : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameBootstrapper", this);
    }
}
