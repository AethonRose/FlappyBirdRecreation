using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.Instance.AddScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.Instance.UpdateHighScore();
        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }
}
