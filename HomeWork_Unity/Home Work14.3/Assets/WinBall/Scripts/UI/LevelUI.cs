using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasSettings;

    private void Start()
    {
        canvasSettings.gameObject.SetActive(false);
    }

    public void BackToMenu(string name)
    {
        GameSceneManager.instance.LoadSceneName(name);
    }


    public void OpenSettingsCanvas()
    {
        canvasSettings.gameObject.SetActive(true);
        TimeController.Pause();
    }


    public void BackToGame()
    {
        canvasSettings.gameObject.SetActive(false);
        TimeController.OnPause();
    }
}
