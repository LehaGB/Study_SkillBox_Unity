using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPrefabFactory
{
    GameObject Prefab { get; set; }
    GameObject CreatePrefab(Transform parent);
}
