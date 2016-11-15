using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    private float playerHP;
    private float bossHP;
    [SerializeField] private Text playerHPText;
    [SerializeField] private Text bossHPText;
    [SerializeField] private Text gameOverText;

    private GameObject playerObject;
    private GameObject bossObject;

    private bool gameOver = false;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        bossObject = GameObject.FindWithTag("Boss");
        gameOverText.enabled = false;
    }

    void Update()
    {
        if (playerObject != null)
        {
            playerHP = playerObject.GetComponent<PlayerController>().getHP();
            if (playerHP <= 0)
            {
                playerHP = 0;
                gameOver = true;
            }
        }
        if (bossObject != null)
        {
            bossHP = bossObject.GetComponent<BossController>().getHP();
            if (bossHP <= 0)
            {
                bossObject.GetComponent<Renderer>().material.color = Color.red;
                bossHP = 0;
            }
        }
        playerHPText.text = ("Player HP: " + playerHP);
        bossHPText.text = ("Boss HP: " + bossHP);

        if (gameOver == true)
        {
            gameOverText.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
