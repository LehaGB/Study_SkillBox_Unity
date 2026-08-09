using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasSettings;

    private void Start()
    {
        canvasSettings.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        GameSceneManager.instance.LoadMainMenu();
    }


    public void OpenSettingsCanvas()
    {
        canvasSettings.gameObject.SetActive(true);
        Time.timeScale = 0;
    }


    public void BackToGame()
    {
        canvasSettings.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
