using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Сцена выбора уровня.
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }


    // Начать игру.
    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }


    // Выбрать уровень.
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }


    // Выйти из игры.
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
