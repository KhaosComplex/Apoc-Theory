using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public void BackToLevelSelect()
    {
        SceneManager.LoadScene(1);
    }
}
