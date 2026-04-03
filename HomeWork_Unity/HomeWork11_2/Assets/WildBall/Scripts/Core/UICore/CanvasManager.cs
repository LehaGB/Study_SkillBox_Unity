using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : IUICanvasManager
{

    public void ToggCanvasLevel(GameObject canvasGameLevel, bool IsActive)
    {
        SetUIVisibility(canvasGameLevel, IsActive);
    }


    public void ToggCanvasLevel1(GameObject canvasGameLevel1, bool IsActive)
    {
        SetUIVisibility(canvasGameLevel1, IsActive);
    }

    public void ToggCanvasMain(GameObject canvasMain, bool IsActive)
    {
        SetUIVisibility(canvasMain, IsActive);
    }

    public void ToggButtonBack(GameObject canvasMain, bool IsActive)
    {
        SetUIVisibility(canvasMain, IsActive);
    }

    public void ToggCanvasSettings(GameObject canvaasSetting, bool IsActive)
    {
        SetUIVisibility(canvaasSetting, IsActive);
    }

    public void ToggButtonMenu(GameObject canvasMenu, bool IsActive)
    {
        SetUIVisibility(canvasMenu, IsActive);
    }

    public void ToggButtonResume(GameObject canvasPause, bool IsActive)
    {
        SetUIVisibility(canvasPause, IsActive);
    }

    private void SetUIVisibility(GameObject uiObject, bool isActive)
    {
        if(uiObject != null)
        {
            uiObject.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning($"Попытка управлять невалидным UI объектом.");
        }
    }
}
