using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUICanvasManager
{
    void ToggCanvasLevel(GameObject canvasGameLevel, bool IsActive);

    void ToggCanvasMain(GameObject canvasMain, bool IsActive);

    void ToggCanvasSettings(GameObject canvasLevel, bool IsActive);

    void ToggCanvasLevel1(GameObject canvasGameLevel1, bool IsActive);

    void ToggButtonMenu(GameObject canvasMenu, bool IsActive);

    void ToggButtonResume(GameObject canvasPause, bool IsActive);

    void ToggButtonBack(GameObject canvasMain, bool IsActive);
}
