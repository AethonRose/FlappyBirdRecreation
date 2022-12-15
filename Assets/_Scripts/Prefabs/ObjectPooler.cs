using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion Singleton

    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 3;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _prefabSpawner;

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(_prefab, _prefabSpawner.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

   public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
