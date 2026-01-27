using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

 public abstract class FactoryButtonManager
 {
    public abstract void Pause(GameObject pause, GameObject play);
    public abstract void Play(GameObject play, GameObject pause);
    public abstract void Again(GameObject again);
    public abstract void ReturnToMenu(int indexScene);
 }
