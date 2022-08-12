using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button BtnStart, BtnNextLevel,BtnRestartLevel;
    private GameManager _gameManager;
    public GameObject menuUI,inGameUI,inGameStopUI,endUI,lostUI;
    public TextMeshProUGUI txtLevel, txtLevelComp, txtScore;

    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        SetBindings();
    }
    // Button inputs
    private void SetBindings()
    {
        BtnStart.onClick.AddListener(call:() =>
        {
            _gameManager.StartGame();
            menuUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        ) ;
        BtnNextLevel.onClick.AddListener(call:() =>
        {
            _gameManager.StartNextGame();
            endUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        );
        BtnRestartLevel.onClick.AddListener(call: () => 
        {
            _gameManager.StartRestartGame();
            lostUI.SetActive(false);
            inGameUI.SetActive(true);
        }
        );
    }
    // Update the level text in the game
    public void UpdateLevelText(int level)
    {
        txtLevel.text = (level + 1).ToString();

    }
    // UI change when completing level
    public void EndLevel()
    {
        inGameUI.SetActive(false);
        endUI.SetActive(true);
    }
    // UI change when level is lost
    public void LostLevel()
    {
        inGameUI.SetActive(false);
        lostUI.SetActive(true);
        
    }
    // Show warning text when player gets too small
    public void SmallWarn()
    {
        inGameStopUI.SetActive(true);        
    }

}