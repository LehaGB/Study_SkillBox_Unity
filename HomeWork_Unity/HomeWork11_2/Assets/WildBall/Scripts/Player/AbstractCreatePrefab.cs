using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCreatePrefab : ICreatePrefab
{
    public abstract GameObject Prefab { get; set; }
    public abstract GameObject CreatePrefab(Transform parent);

    public abstract GameObject DestroyPrefab(Transform parent);

    public abstract GameObject MovementPrefab(Transform parent);
}
