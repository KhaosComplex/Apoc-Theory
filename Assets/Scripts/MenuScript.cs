using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    [SerializeField] private Canvas quitMenu;
    [SerializeField] private Button startText;
    [SerializeField] private Button quitText; 

	// Use this for initialization
	void Start () {
        quitMenu.enabled = false;
	}
	
	public void QuitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
