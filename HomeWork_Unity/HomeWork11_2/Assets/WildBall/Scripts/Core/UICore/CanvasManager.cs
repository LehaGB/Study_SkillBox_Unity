using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : IUICanvasManager
{
    public void ToggCanvasLevel(GameObject canvasGameLevel, bool IsPausedActive)
    {
        IsPausedActive = !IsPausedActive;
        canvasGameLevel.SetActive(IsPausedActive);
        canvasGameLevel.SetActive(!IsPausedActive);
    }

    public void ToggCanvasMain(GameObject canvasMain, bool IsPausedActive)
    {
        IsPausedActive = !IsPausedActive;
        canvasMain.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }

    public void ToggButtonBack(GameObject canvasMain, bool IsPausedActive)
    {
        IsPausedActive = !IsPausedActive;
        canvasMain.SetActive(IsPausedActive);
        canvasMain.SetActive(!IsPausedActive);
    }

    public void ToggCanvasSettings(GameObject canvasSettings, bool IsPausedActive)
    {
        IsPausedActive = !IsPausedActive;
        canvasSettings.SetActive(IsPausedActive);
        canvasSettings.SetActive(!IsPausedActive);
    }

    public void ToggButtonMenu(GameObject canvasMenu, bool IsPausedActive)
    {
        IsPausedActive = !IsPausedActive;
        canvasMenu.SetActive(IsPausedActive);
        canvasMenu.SetActive(!IsPausedActive);
    }

    public void ToggCanvasResume(GameObject canvasPause, bool IsPausedActive)
    {

    }
}
