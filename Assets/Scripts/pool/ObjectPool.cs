using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Rendering;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Queue<T> pool = new Queue<T>();
    private GameObject parent;

    public void Initialize(T prefab, int initialSize, string name)
    {
        this.prefab = prefab;
        parent = new GameObject(name);
        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateNewObject();
            ReturnToPool(obj);
        }
    }

    private T CreateNewObject()
    {
        T newObject = UnityEngine.Object.Instantiate(prefab);
        //newObject.gameObject.SetActive(false);
        return newObject;
    }

    public T Get()
    {
        T obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = CreateNewObject();
        }
        obj.gameObject.SetActive(true);
        obj.transform.SetParent(parent.transform);
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}