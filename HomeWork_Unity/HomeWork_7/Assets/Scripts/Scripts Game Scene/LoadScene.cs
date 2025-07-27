using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string nameSceneToLoad;  // Имя сцены.
    public int indexSceneToLoad;  // индекс сцены.


    // Загрузка сцены.
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
