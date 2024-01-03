using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pooling
{
    public PoolableMono prefab;
    public int poolCount;
}

[CreateAssetMenu(menuName = "SO/PoolingList")]
public class PoolingSO : ScriptableObject
{
    public List<Pooling> poolingList;
}
