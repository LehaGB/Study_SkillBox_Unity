using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{

    private FactoryButtonManager _buttonManager = new ButtonManager();
    public GameObject gameObjectButton;

    private static DeathPlayer _instance;
    public static DeathPlayer Instanse
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DeathPlayer>();
                if (_instance == null)
                {
                    GameObject soundmanagerGo = new GameObject("DeathPlayer");
                    _instance = soundmanagerGo.AddComponent<DeathPlayer>();
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void DeathPlayerS()
    {
        _buttonManager.Again(gameObjectButton);
        Debug.Log("Проверяем падаю я или нет");
        SoundManager.Instance._audioSource.Stop();
        Destroy(gameObject);
    }
}
