﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject playerObject;
    private PlayerController playerController;

    [SerializeField] private GameObject bossObject;
    private BossController bossController;

    private float playerHP;
    private float bossHP;
    private float playerMaxHP;
    private float bossMaxHP;
    [SerializeField] private Text playerHPText;
    [SerializeField] private Slider playerHPSlider;
    [SerializeField] private Slider bossHPSlider;
    [SerializeField] private Text bossHPText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text gameWonText;
    [SerializeField] private float timeAfterLossSlowDown;

    private bool gameOver = false;
    private bool gameWon = false;
    private float timeTillFullPause;

    private int currentScene;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        bossController = bossObject.GetComponent<BossController>();
        gameOverText.enabled = false;
        gameWonText.enabled = false;

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        playerHP = playerController.getHP();
        playerMaxHP = playerController.getMaxHP();
        if (playerHP <= 0 && !gameOver)
        {
            playerHP = 0;
            gameOver = true;
            Time.timeScale = .5f;
            timeTillFullPause = Time.timeSinceLevelLoad + timeAfterLossSlowDown;
        }
        bossHP = bossController.getHP();
        bossMaxHP = bossController.getMaxHP();
        if (bossHP <= 0 && !gameWon)
        {
            bossObject.GetComponent<Renderer>().material.color = Color.red;
            bossHP = 0;
            gameWon = true;
            Time.timeScale = 0;
        }
        playerHPText.text = ("Player HP: " + playerHP);
        playerHPSlider.value = playerHP / playerMaxHP;
        bossHPText.text = ("Boss HP: " + bossHP);
        bossHPSlider.value = bossHP / bossMaxHP;

        if (gameOver)
        {
            gameOverText.enabled = true;
            if (Time.timeSinceLevelLoad >= timeTillFullPause)
                Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButton("Start"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(currentScene);
            }
        }

        if (gameWon)
        {
            gameWonText.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Start"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
                StaticGameState.timeToWaitButtonPress = 1;
            }
        }
    }
}
