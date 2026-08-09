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


    // Глвное меню.
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    // Начать игру.
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }


    // Выбрать уровень.
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }


    // Настройки.
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }


    // Автор.
    public void LoadAuthor()
    {
        SceneManager.LoadScene("Author");
    }


    // Выйти из игры.
    public void QuitGame()
    {
        Application.Quit();
    }
}
