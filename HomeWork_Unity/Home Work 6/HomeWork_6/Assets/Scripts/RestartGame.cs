using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public string sceneToRestart = "GameHandller";

    // �������� �����.
    public void OnClickRestartGame()
    {
        SceneManager.LoadScene(sceneToRestart);
    }
}
