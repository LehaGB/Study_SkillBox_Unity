using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TubeController : MonoBehaviour
{
    public string nameScene;

    public void SceneLoad()
    {
        SceneManager.LoadScene(nameScene);
    }
}
