using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void GameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Выход из игрового режима в редакторе
        #else
            Application.Quit(); // Выход из скомпилированной игры
        #endif
    }
}
