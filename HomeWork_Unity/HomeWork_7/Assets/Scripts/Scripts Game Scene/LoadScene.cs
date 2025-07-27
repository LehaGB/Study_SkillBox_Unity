using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nameSceneToLoad;  // ��� �����.
    public int indexSceneToLoad;  // ������ �����.


    // �������� �����.
    public void SceneByName()
    {
        if (!string.IsNullOrEmpty(nameSceneToLoad))
        {
            SceneManager.LoadScene(nameSceneToLoad);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(indexSceneToLoad);
        }
    }
}
