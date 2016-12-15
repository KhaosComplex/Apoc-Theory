using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject[] listOfLevels;

    private PlayerSettingsFileReader playerSettingsFileReader;
    private int currentLevel;
    private GameObject currentLoadedLevel;

    private string PLAYER_SETTINGS_FILE;

    // Use this for initialization
    void Start()
    {
        PLAYER_SETTINGS_FILE = Application.dataPath + "/Settings/PlayerSettings.txt";
        playerSettingsFileReader = playerObject.GetComponent<PlayerSettingsFileReader>();
        playerSettingsFileReader.Load(PLAYER_SETTINGS_FILE);
        currentLevel = playerSettingsFileReader.getCurrentLevel();

        loadLevelMenu();
    }

    private void loadLevelMenu()
    {
        
        switch(currentLevel)
        {
            case 1:
                title.text = "Introduction to Bullet Hell";
                description.text = @"Red balls are gonna fly at your face, juke by using either WASD or the left stick.

Also be sure to kill the boss by aiming with the mouse or right stick to shoot.";
                Destroy(currentLoadedLevel);
                currentLoadedLevel = Instantiate(listOfLevels[0]);
                break;
            case 2:
                title.text = "Spikes at your Feet!";
                description.text = @"Spikes are going to appear beneath you.
You have a short amount of time to juke before the spike flys up.";
                Destroy(currentLoadedLevel);
                currentLoadedLevel = Instantiate(listOfLevels[1]);
                break;
            case 3:
                title.text = "Jump Up Jump Up Jump Around";
                description.text = @"Shockwaves are pulsating and you have to jump to avoid them. Dashing will also work.

Be sure to also avoid the obelisks that spawn. They'll damage you once they start moving!";
                Destroy(currentLoadedLevel);
                currentLoadedLevel = Instantiate(listOfLevels[2]);
                break;
            case 4:
                title.text = "Juke and Dash!";
                description.text = @"Turns out the Shockwaves have another trick up their sleeve! Some are tall now, so you'll have to dash through them to avoid damage.

Also be sure to juke the oncomming Obelisks that now hone in on your location!";
                Destroy(currentLoadedLevel);
                currentLoadedLevel = Instantiate(listOfLevels[3]);
                break;
            case 5:
                title.text = "Final Stand";
                description.text = @"Obelisks will arise from the ground. During this time the boss is immune and you have to shoot and take down all the Obelisks to lower the bosses shields!";
                Destroy(currentLoadedLevel);
                currentLoadedLevel = Instantiate(listOfLevels[4]);
                break;
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevel != listOfLevels.Length)
        {
            currentLevel++;
        }

        loadLevelMenu();
    }

    public void LoadPreviousLevel()
    {
        if (currentLevel != 1)
        {
            currentLevel--;
        }

        loadLevelMenu();
    }

    public void StartLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
