using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public void OpenStteings()
    {
        GameSceneManager.instance.LoadLevelSelection();
    }
}
