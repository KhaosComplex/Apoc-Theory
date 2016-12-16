using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public void BackToLevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
