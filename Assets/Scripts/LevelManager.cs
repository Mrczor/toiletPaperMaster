using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public int currentLevel;
    private Player _player;
    private Vector3 playerDefaultPosition;
    private Vector3 playerDefaultScale;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerDefaultPosition = _player.transform.position;
        playerDefaultScale = _player.transform.localScale;
    }
    // Start Level
    public void StartLevel()
    {

        levels[currentLevel % levels.Length].gameObject.SetActive(true);
        _player.transform.position = playerDefaultPosition;
        _player.transform.localScale = playerDefaultScale;

    }
    // Start the game when the game is lost
    public void StartLostLevel() 
    {
        levels[currentLevel % levels.Length].ResetLevel();
        _player.forwardSpeed = _player.startForwardSpeed;
        _player.transform.position = playerDefaultPosition;
        _player.transform.localScale = playerDefaultScale;
        _player.toiletPaperCount = 0;
    }
    // Start next level
    public void StartNextLevel()
    {
        levels[currentLevel % levels.Length].ResetLevel();
        _player.forwardSpeed = _player.startForwardSpeed;
        levels[currentLevel % levels.Length].gameObject.SetActive(false);
        currentLevel++;
        StartLevel();
        PlayerPrefs.SetInt("Level",currentLevel);
        PlayerPrefs.Save();
    }
    public void EndLevel()
    {
    }
}
