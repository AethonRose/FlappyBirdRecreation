using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePrefab : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    void Update()
    {
        DestroyPrefab();
    }

    private void DestroyPrefab()
    {
        if(transform.position.x <= -2.5)
        {
            _prefab.SetActive(false);
        }
    }

}
