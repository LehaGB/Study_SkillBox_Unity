using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectLevelScene : MonoBehaviour
{
    [SerializeField] private string nameScene;

    public void SceneLoad()
    {
        SceneManager.LoadScene(nameScene);
    }
}
