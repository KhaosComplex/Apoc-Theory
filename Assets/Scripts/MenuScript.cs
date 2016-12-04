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
        quitMenu.enabled = false;
        PLAYER_SETTINGS_FILE = Application.dataPath + "/Settings/PlayerSettings.txt";
        playerSettingsFileReader = playerObject.GetComponent<PlayerSettingsFileReader>();
        playerSettingsFileReader.Load(PLAYER_SETTINGS_FILE);

        if (playerSettingsFileReader.getController())
            controllerText.GetComponentInChildren<Text>().color = Color.green;
        else
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
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

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Controller()
    {
        playerSettingsFileReader.setController(PLAYER_SETTINGS_FILE, !playerSettingsFileReader.getController());

        if (playerSettingsFileReader.getController())
            controllerText.GetComponentInChildren<Text>().color = Color.green;
        else
            controllerText.GetComponentInChildren<Text>().color = new Color(1f, .404f, .404f, 1f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
