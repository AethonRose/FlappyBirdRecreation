using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region singleton
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion singleton

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpVelocity = 2;

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        //Doesn't run if GameState is Lose
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && GameManager.Instance.State != GameManager.GameState.Lose)
        {
            //Update GameState to PlayActive
            GameManager.Instance.UpdateGameState(GameManager.GameState.PlayActive);

            rb.velocity = Vector2.up * jumpVelocity;
        }
    }
}
