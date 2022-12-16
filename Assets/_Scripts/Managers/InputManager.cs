using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpVelocity = 2;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        //Doesn't run if GameState is Lose
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && GameManager.Instance.State != GameManager.GameState.Lose)
        {
            //Update GameState to PlayActive
            GameManager.Instance.UpdateGameState(GameManager.GameState.PlayActive);
            rb.velocity = Vector2.up * jumpVelocity;
            PlayMovementSound();
        }
    }

    private void PlayMovementSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
