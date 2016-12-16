using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    [SerializeField] private Canvas quitMenu;
    [SerializeField] private Button startText;
    [SerializeField] private Button quitText;
    [SerializeField] private Button controllerText;
    [SerializeField] private GameObject playerObject;
    private PlayerSettingsFileReader playerSettingsFileReader;

    private string PLAYER_SETTINGS_FILE;

    // Use this for initialization
    void Start () {
        /*PLAYER_SETTINGS_FILE = Application.dataPath + "/Settings/PlayerSettings.txt";
        playerSettingsFileReader = playerObject.GetComponent<PlayerSettingsFileReader>();
        playerSettingsFileReader.Load(PLAYER_SETTINGS_FILE);*/

        /*if (playerSettingsFileReader.getController())
        {
            controllerText.GetComponentInChildren<Text>().color = Color.green;
            controllerText.GetComponentInChildren<Text>().text = "Controller (ENABLED)";
        }
        else {
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
            controllerText.GetComponentInChildren<Text>().text = "Controller (DISABLED)";
        }*/

        quitMenu.enabled = false;
        StaticGameState.playing = false;

        if (StaticGameState.controller)
        {
            controllerText.GetComponentInChildren<Text>().color = Color.green;
            controllerText.GetComponentInChildren<Text>().text = "Controller (ENABLED)";
        }
        else {
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
            controllerText.GetComponentInChildren<Text>().text = "Controller (DISABLED)";
        }
    }

    void Update()
    {
        if (Input.GetButton("A"))
        {
            StaticGameState.timeToWaitButtonPress = 1;
        }
    }
	
	public void QuitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
        controllerText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
        controllerText.enabled = true;
    }

    public void StartLevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void Controller()
    {
        /*playerSettingsFileReader.setController(PLAYER_SETTINGS_FILE, !playerSettingsFileReader.getController());

        if (playerSettingsFileReader.getController())
        {
            controllerText.GetComponentInChildren<Text>().color = Color.green;
            controllerText.GetComponentInChildren<Text>().text = "Controller (ENABLED)";

        }
        else {
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
            controllerText.GetComponentInChildren<Text>().text = "Controller (DISABLED)";
        }*/

        StaticGameState.controller = !StaticGameState.controller;

        if (StaticGameState.controller)
        {
            controllerText.GetComponentInChildren<Text>().color = Color.green;
            controllerText.GetComponentInChildren<Text>().text = "Controller (ENABLED)";

        }
        else {
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
            controllerText.GetComponentInChildren<Text>().text = "Controller (DISABLED)";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
