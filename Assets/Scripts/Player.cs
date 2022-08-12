using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int toiletPaperCount = 0;
    public float forwardSpeed;
    private GameManager _gameManager;
    public float startForwardSpeed;
    public int puan;
    public UIManager _uiManager;
    public Rigidbody rb;

    void Start()
    {
        startForwardSpeed = forwardSpeed;
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
    }

    // Player movement
    private float firstTouchx;
    void Update()
    {
        if(_gameManager.currentGameState != GameState.Start)
        {
            return;
        }
        Vector3 moveVector = new Vector3(-1 * forwardSpeed * Time.deltaTime, 0, 0);
        float diff = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchx = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float lastTouchX = Input.mousePosition.x ;
            diff = lastTouchX - firstTouchx;
            moveVector += new Vector3(0 , 0, diff * Time.deltaTime / 3);
            firstTouchx = lastTouchX;
        }
        transform.position += moveVector;

        
    }

    // Checking for collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            toiletPaperCount += 1;
            other.gameObject.SetActive(false);
            _uiManager.inGameStopUI.SetActive(false);

        }
        else if (other.CompareTag("Poop"))
        {
            if (toiletPaperCount > -5)
            {
                transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                _uiManager.SmallWarn();
            }
            toiletPaperCount -= 1;
            other.gameObject.SetActive(false);
        }

        else if (other.CompareTag("Finish"))
        {
            puan = int.Parse(other.name);
        }

        else if (other.CompareTag("AraFinish"))
        {
            if (toiletPaperCount > 0)
            {
                forwardSpeed = 8;
                toiletPaperCount -= 1;
                transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
            else if (toiletPaperCount <= 0)
            {
                _uiManager.txtScore.text = "Score : " + puan;                
                _gameManager.EndGame();
            }
        }
        else if (other.CompareTag("Dead"))
        {
            rb.useGravity = false;
            _gameManager.EndGame();
        }
        
    }


}

