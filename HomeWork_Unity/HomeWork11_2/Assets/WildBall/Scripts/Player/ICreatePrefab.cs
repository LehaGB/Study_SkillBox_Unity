using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreatePrefab 
{
    public GameObject Prefab { get; set; }
    GameObject CreatePrefab(Transform parent);

    GameObject DestroyPrefab(Transform parent);

    GameObject MovementPrefab(Transform parent);
}
