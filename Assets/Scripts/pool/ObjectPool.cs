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
        newObject.gameObject.SetActive(false);
        return newObject;
    }
    private T CreateNewObject(Vector2 position)
    {
        T newObject = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
        newObject.gameObject.SetActive(false);
        return newObject;
    }
    public T Get()
    {
        T obj;
        if (pool.Count > 0)
        {
            Debug.LogWarning("GET: Length before taking " + pool.Count);
            obj = pool.Dequeue();
        }
        else
        {
            obj = CreateNewObject();
        }
        obj.transform.SetParent(parent.transform);
        obj.gameObject.SetActive(true);
        return obj;
    }
    public T Get(Vector2 position)
    {

        T obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.transform.position = position;
        }
        else
        {
            obj = CreateNewObject(position);
        }
        obj.transform.SetParent(parent.transform);
        obj.gameObject.SetActive(true);  
        return obj;
    }
    public void ReturnToPool(T obj)
    {
        if (!pool.Contains(obj))
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}