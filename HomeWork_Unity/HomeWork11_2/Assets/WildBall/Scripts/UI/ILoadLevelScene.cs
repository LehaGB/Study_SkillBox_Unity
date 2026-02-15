using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadLevelScene
{
    event Action <int> OnLoadLevel;
    void LoadScene(int indexScene);
    void LoadLevelButtonClicked(int levelIndex);

    void Game();

    void Exit();

    void Menu();

    void Back();
}
