using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<System.Type, object> pools = new Dictionary<System.Type, object>();

    public void CreatePool<T>(T prefab, int initialSize, string name) where T : MonoBehaviour 
    {
        if (!pools.ContainsKey(typeof(T)))
        {
            GameObject poolObject = new GameObject(typeof(T).Name + "Pool");
            poolObject.transform.SetParent(this.transform);
            ObjectPool<T> pool = new ObjectPool<T>();
            pool.Initialize(prefab, initialSize, name);
            pools.Add(typeof(T), pool);
        }
    }

    public T GetObject<T>(T prefab, string name, int initialSize = 1) where T : MonoBehaviour
    {
        if (!pools.TryGetValue(typeof(T), out object pool))
        {
            CreatePool(prefab, initialSize, name);
            pool = pools[typeof(T)];
        }

        return (pool as ObjectPool<T>).Get();
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