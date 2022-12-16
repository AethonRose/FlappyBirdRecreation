using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSpawner;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float spawnDelay;

    private float maxY = 1.5f;
    private float minY = -0.8f;

    private float nextSpawnTime;

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.PlayActive)
        {
            if (ShouldSpawn())
            {
                Spawn();
            }
        }
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;

        GameObject pipe = ObjectPooler.Instance.GetPooledObject();

        if (pipe != null)
        {
            pipe.transform.position = SetPrefabSpawnLocation(_prefabSpawner, minY, maxY);
            pipe.SetActive(true);
        }
        
    }

    private Vector2 SetPrefabSpawnLocation(GameObject spawner, float minY, float maxY)
    {
            return new Vector2(spawner.transform.position.x, Random.Range(minY, maxY));
    }

    
}
