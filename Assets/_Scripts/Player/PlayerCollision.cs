using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    private bool soundPlayed;

    private void Start()
    {
        soundPlayed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.Instance.AddScore();
        ScoreManager.Instance.PlayScoreSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.Instance.UpdateHighScore();
        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);

        if (!soundPlayed)
        {
            GameManager.Instance.PlayLoseSound();
            soundPlayed = true;
        }
    }
}
