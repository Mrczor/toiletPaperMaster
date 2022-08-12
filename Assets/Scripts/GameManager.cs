using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Determination of game states
public enum GameState
{
    Start,
    Pause,
    End,
    Lost
}
public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;
    public GameState currentGameState;
    private UIManager _uiManager;
    public Player _player;

    void Start()
    {
        _levelManager = GetComponent<LevelManager>();
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState = GameState.Pause;

    }
    // Start level
    public void StartGame()
    {
        currentGameState = GameState.Start;
        _uiManager.UpdateLevelText(_levelManager.currentLevel);
        _levelManager.StartLevel();
    }
    // Going to the same level when the game is lost
    public void StartRestartGame() 
    {
        currentGameState = GameState.Start;
        _player.rb.useGravity = true;
        _levelManager.StartLostLevel();
    }
    // Go to next level
    public void StartNextGame()
    {
        currentGameState = GameState.Start;
        _levelManager.StartNextLevel();
        _uiManager.UpdateLevelText(_levelManager.currentLevel);
    }

    // Finish the game
    public void EndGame()
    {
        
        if (_player.puan >= 1500)
        {
            _uiManager.EndLevel();
            _levelManager.EndLevel();
            currentGameState = GameState.End;
            _player.puan = 0;
        }
        else
        {
            _uiManager.LostLevel();
            currentGameState = GameState.Lost;
        }
    }
}
