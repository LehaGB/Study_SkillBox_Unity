using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPausePLayReturnToMenu
{
    void Pause();
    void Play();

    void Again();
    void ReturnToMenu(int indexScene);
}
