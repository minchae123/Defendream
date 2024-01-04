using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;

    private Dictionary<string, Pool<PoolableMono>> _pools
        = new Dictionary<string, Pool<PoolableMono>>();

    private Transform _trmParent;

    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }

    public void CreatePool(PoolableMono prefab, int count)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _trmParent, count);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public PoolableMono Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError($"no Prefab : {prefabName}");
            return null;
        }
        PoolableMono item = _pools[prefabName].Pop();
        WeekManager.Instance.activeObjects.Add(item);
        item.Init();
        return item;
    }

    public void Push(PoolableMono obj)
    {
        _pools[obj.name].Push(obj);
        WeekManager.Instance.activeObjects.Remove(obj);
    }
}
