using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void FixedUpdate() 
    {
        MovePrefabLeft();
    }

    void MovePrefabLeft() 
    {
        //Doesn't move prefab if Lose
        if (GameManager.Instance.State != GameManager.GameState.Lose)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        
    }
}
