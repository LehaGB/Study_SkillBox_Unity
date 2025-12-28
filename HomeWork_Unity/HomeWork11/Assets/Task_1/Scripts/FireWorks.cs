using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorks : MonoBehaviour
{
    public static FireWorks Instance {  get; private set; }

    public GameObject m_fireworksPrefab;
    public Transform parent;
    private GameObject m_fireworks;
    private ParticleSystem m_ps;

    private IPrefabFactory m_createfireworks;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_createfireworks = GetComponent<FireworksPrefab>();

        if (m_createfireworks == null)
        {
            m_createfireworks = gameObject.AddComponent<FireworksPrefab>();
        }
        m_createfireworks.Prefab = m_fireworksPrefab;
        m_ps = m_fireworksPrefab.GetComponent<ParticleSystem>();
    }

    //private void Start()
    //{
    //    FireWorksStart();
    //}
    //public void FireWorksStart()
    //{
    //    m_createfireworks.CreatePrefab(transform);    
    //}
    //public void StartFireworks()
    //{
    //    if (m_ps != null)
    //    {
    //        m_ps.Play();
    //    }
    //    else
    //    {
    //        m_ps.Stop();
    //    }
    //}
    public void StartFireworks()
    {
        if (m_fireworks == null)
        {
            Debug.LogError("m_fireworks is null!  Did the prefab instantiate correctly?");
            return;
        }

        ParticleSystem ps = m_fireworks.GetComponent<ParticleSystem>();
        if (ps == null)
        {
            Debug.LogError("ParticleSystem not found on fireworks object!");
            return;
        }

        ps.Play();
    }

    public void FireWorksStart()
    {
        m_fireworks = m_createfireworks.CreatePrefab(parent);
        StartFireworks();
    }
}
