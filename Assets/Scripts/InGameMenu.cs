using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    void Update()
    {
        if (Time.timeSinceLevelLoad >= StaticGameState.timeToWaitButtonPress && Input.GetButton("Back"))
        {
            BackToLevelSelect();
            StaticGameState.timeToWaitButtonPress = 1;
        }
    }

    public void BackToLevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

}
