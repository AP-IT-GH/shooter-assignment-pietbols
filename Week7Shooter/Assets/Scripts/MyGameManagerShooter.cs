using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManagerShooter : MonoBehaviour
{
    public GameObject player;
    public GameObject introCanvas;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject endScreenCanvas;

    public Text scoreText;
    public int maxScore;

    private Health healthPlayer;
    
    

    public enum GameStates { Intro, Playing, GameOver, End }
    public GameStates gameState = GameStates.Intro;

    // Start is called before the first frame update
    void Start()
    {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        healthPlayer = player.GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // state machine of the game
        switch (gameState)
        {
            case GameStates.Intro:
                if (GameObject.FindWithTag("Intro") == null || !introCanvas.activeSelf)
                {
                    gameState = GameStates.Playing;
                    mainCanvas.SetActive(true);
                    gameOverCanvas.SetActive(false);
                }
                else
                {
                    introCanvas.SetActive(true);
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(false);
                }

                break;

            case GameStates.Playing:

                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                else if (endScreenCanvas.activeSelf == true)
                {
                    mainCanvas.SetActive(false);
                    gameState = GameStates.End;
                }
                else if (maxScore == Int32.Parse(scoreText.text.Substring(6))) // remove "Score: "
                {
                    mainCanvas.SetActive(false);
                    endScreenCanvas.SetActive(true);
                }
                break;


        }

    }
}
