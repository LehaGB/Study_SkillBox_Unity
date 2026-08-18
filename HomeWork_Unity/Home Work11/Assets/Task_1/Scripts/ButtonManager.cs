using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

  public class ButtonManager : FactoryButtonManager
  {
       public override void Again(GameObject again)
       {
            again.SetActive(true);
            Debug.Log("Включили кнопку");
       }

        public override void Pause(GameObject pause, GameObject play)
        {
            Time.timeScale = 0f;
            play.SetActive(true);
            pause.SetActive(false);
        }

        public override void Play(GameObject play, GameObject pause)
        {
            Time.timeScale = 1f;
            play.SetActive(false);
            pause.SetActive(true);
        }

        public override void ReturnToMenu(int indexScene)
        {
            SceneManager.LoadScene(indexScene, LoadSceneMode.Single);
        }
  }
