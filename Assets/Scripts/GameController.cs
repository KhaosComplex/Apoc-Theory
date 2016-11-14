using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    [SerializeField] private float playerHP;
    [SerializeField] private float bossHP;
    [SerializeField] private Text playerHPText;
    [SerializeField] private Text bossHPText;

    void Update()
    {
        if (playerHP <= 0)
            playerHP = 0;
        if (bossHP <= 0)
            bossHP = 0;
        playerHPText.text = ("Player HP: " + playerHP);
        bossHPText.text = ("Boss HP: " + bossHP);
    }
}
