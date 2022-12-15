using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion singleton

    [SerializeField] private GameObject player;
    [SerializeField] private Image mainMenuImage;
    [SerializeField] private Image gameOverImage;
    [SerializeField] private TextMeshProUGUI scoreText;

    public GameState State;
    public static event Action<GameState> StateChanged;

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                MainMenuState();
                break;
            case GameState.PlayActive:
                PlayActiveState();
                break;
            case GameState.Lose:
                LoseState();
                break;
        }

        StateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        MainMenu,
        PlayActive,
        Lose
    }

    public void RestartEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    private void MainMenuState()
    {
        mainMenuImage.gameObject.SetActive(true); 
    }

    private void PlayActiveState()
    {
        mainMenuImage.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }

    private void LoseState()
    {
        scoreText.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(true);
    }

    
}
