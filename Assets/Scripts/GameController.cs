using UnityEngine;
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
    [SerializeField] private Text playerHPText;
    [SerializeField] private Text bossHPText;
    [SerializeField] private Text gameOverText;

    private bool gameOver = false;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        bossController = bossObject.GetComponent<BossController>();
        gameOverText.enabled = false;
    }

    void Update()
    {
        playerHP = playerController.getHP();
        if (playerHP <= 0)
        {
            playerHP = 0;
            gameOver = true;
        }
        bossHP = bossController.getHP();
        if (bossHP <= 0)
        {
            bossObject.GetComponent<Renderer>().material.color = Color.red;
            bossHP = 0;
        }
        playerHPText.text = ("Player HP: " + playerHP);
        bossHPText.text = ("Boss HP: " + bossHP);

        if (gameOver == true)
        {
            gameOverText.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
