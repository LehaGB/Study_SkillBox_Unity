using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadNewScne : MonoBehaviour
{
    public string sceneToLoad;  // ��� �����.
    public int sceneIndexToLoad;  // ������ �����.

    // �������� �����(������ ������).
    public void LoadSceneByName()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }


}
