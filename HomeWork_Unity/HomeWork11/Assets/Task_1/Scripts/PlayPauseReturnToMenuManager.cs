using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayPauseReturnToMenuManager : MonoBehaviour, IPausePLayReturnToMenu
{

    public abstract void Play();
    public abstract void Pause();
    public abstract void ReturnToMenu(int indexScene);
}
