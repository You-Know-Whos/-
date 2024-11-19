using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreativeMode_ObjectPool : MonoBehaviour
{
    public static CreativeMode_ObjectPool Instance { get; private set; }
    public Dictionary<string, ObjectPool<GameObject>> objectPools = new Dictionary<string, ObjectPool<GameObject>>();
    public GameObject objects;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    public void AddObjectPool(GameObject prefab)
    {
        objectPools.Add(prefab.name, new ObjectPool<GameObject>
            (
            () =>
            {
                GameObject obj = Instantiate(prefab, objects.transform.Find(prefab.name));
                obj.name = prefab.name;
                return obj;
            },
            obj => obj.SetActive(true),
            obj => obj.SetActive(false),
            obj => Destroy(obj),
            true, 10, 1000
            ));
    }
}
