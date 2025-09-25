using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public string nameScene;

    public void SceneLoad()
    {
        SceneManager.LoadScene(nameScene);
    }
}
