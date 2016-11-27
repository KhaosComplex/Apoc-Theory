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
    [SerializeField] Camera overheadCamera;
    [SerializeField] Camera meleeCamera;

    private bool gameOver = false;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        bossController = bossObject.GetComponent<BossController>();
        gameOverText.enabled = false;

        overheadCamera.enabled = true;
        meleeCamera.enabled = false;
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

        if (playerController.isInMelee())
        {
            overheadCamera.enabled = false;
            meleeCamera.enabled = true;
        }
        else
        {
            overheadCamera.enabled = true;
            meleeCamera.enabled = false;
        }

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
