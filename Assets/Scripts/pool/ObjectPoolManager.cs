using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<System.Type, object> pools = new Dictionary<System.Type, object>();

    public void CreatePool<T>(T prefab, int initialSize) where T : MonoBehaviour 
    {
        if (!pools.ContainsKey(typeof(T)))
        {
            GameObject poolObject = new GameObject(typeof(T).Name + "Pool");
            poolObject.transform.SetParent(transform);
            ObjectPool<T> pool = new ObjectPool<T>();
            pool.Initialize(prefab, initialSize, prefab.name);
            pools.Add(typeof(T), pool);
        }
    }

    public T GetObject<T>(T prefab, int initialSize = 3) where T : MonoBehaviour
    {
        if (!pools.TryGetValue(typeof(T), out object pool))
        {
            CreatePool(prefab, initialSize);
            pool = pools[typeof(T)];
        }

        return (pool as ObjectPool<T>).Get();     
    }
    public T GetObject<T>(T prefab, Vector2 position, int initialSize = 1) where T : MonoBehaviour
    {
        if (!pools.TryGetValue(typeof(T), out object pool))
        {
            CreatePool(prefab, initialSize);
            pool = pools[typeof(T)];
        }

        return (pool as ObjectPool<T>).Get(position);
    }
    public void ReturnObject<T>(T obj) where T : MonoBehaviour
    {
        if (pools.TryGetValue(typeof(T), out object pool))
        {
            (pool as ObjectPool<T>).ReturnToPool(obj);
        }
        else
        {
            Debug.LogWarning("No pool found for type " + typeof(T).Name);
        }
    }
}