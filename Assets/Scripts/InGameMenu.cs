using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    void Update()
    {
        if (Input.GetButton("Back"))
            BackToLevelSelect();
    }

    public void BackToLevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

}
