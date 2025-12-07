using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPausePLayReturnToMenu
{
    void Pause();
    void Play();
    void ReturnToMenu(int indexScene);
}
