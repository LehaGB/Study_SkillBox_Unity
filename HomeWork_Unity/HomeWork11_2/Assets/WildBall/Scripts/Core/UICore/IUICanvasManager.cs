using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUICanvasManager
{
    void ToggCanvasLevel(GameObject canvasGameLevel, bool IsPausedActive);

    void ToggCanvasMain(GameObject canvasMain, bool IsPausedActive);

    void ToggCanvasSettings(GameObject canvasSetting, bool IsPausedActive);

    void ToggButtonMenu(GameObject canvasMenu, bool IsPausedActive);

    void ToggCanvasResume(GameObject canvasPause, bool IsPausedActive);

    void ToggButtonBack(GameObject canvasMain, bool IsPausedActive);
}
