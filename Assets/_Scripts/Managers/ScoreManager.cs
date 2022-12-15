using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region singleton

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion singleton

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score;
    private int highScore;

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void AddScore()
    {
        score += 1;
        scoreText.SetText(score.ToString());
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.SetText(highScore.ToString());
    }
}
