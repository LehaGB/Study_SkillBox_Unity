using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPrefabCreate
{
    public abstract GameObject Prefab { get; set; }
    public abstract GameObject CreatePrefab(Transform parent);
}
