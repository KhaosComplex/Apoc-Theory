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
    [SerializeField] private Image fadePlane;
    [SerializeField] private Color transparent;
    [SerializeField] private Color opaque;
    [SerializeField] private float fadeTime;

    private PlayerSettingsFileReader playerSettingsFileReader;
    private int currentLevel;
    private GameObject currentLoadedLevel;
    private bool fading;
    private float timeTillFinishedFading = -1;

    private string PLAYER_SETTINGS_FILE;

    // Use this for initialization
    void Start()
    {
        /*PLAYER_SETTINGS_FILE = Application.dataPath + "/Settings/PlayerSettings.txt";
        playerSettingsFileReader = playerObject.GetComponent<PlayerSettingsFileReader>();
        playerSettingsFileReader.Load(PLAYER_SETTINGS_FILE);
        currentLevel = playerSettingsFileReader.getCurrentLevel();*/

        StaticGameState.playing = false;

        if (StaticGameState.currentLevel == 0)
        {
            StaticGameState.currentLevel = 1;
            currentLevel = StaticGameState.currentLevel;
        }
        else
            currentLevel = StaticGameState.currentLevel;

        loadLevelMenu();
    }

    void Update()
    {
        if (fading)
        {
            if (Time.timeSinceLevelLoad <= timeTillFinishedFading)
                fadePlane.color = Color.Lerp(transparent, opaque, (fadeTime-(timeTillFinishedFading - Time.timeSinceLevelLoad))/fadeTime);
            else
            {
                loadLevelMenu();
                timeTillFinishedFading = Time.timeSinceLevelLoad + fadeTime;
                fading = false;
            }
        }
        else
        {
            if (Time.timeSinceLevelLoad <= timeTillFinishedFading)
                fadePlane.color = Color.Lerp(opaque, transparent, (fadeTime - (timeTillFinishedFading - Time.timeSinceLevelLoad)) / fadeTime);
        }
    }

    private void loadLevelMenu()
    {
        
        switch(currentLevel)
        {
            case 1:
                title.text = "Introduction to Bullet Hell";
                description.text = @"Red balls are gonna fly at your face, juke by using either WASD or the left stick.

Also be sure to kill the boss by aiming with the mouse or right stick to shoot.";
                break;
            case 2:
                title.text = "Spikes at your Feet!";
                description.text = @"Spikes are going to appear beneath you.
You have a short amount of time to juke before the spike flies up.";
                break;
            case 3:
                title.text = "Jump Up, Jump Up, Jump Around";
                description.text = @"Shockwaves are pulsating and you have to jump to avoid them. Dashing will also work.

Be sure to also avoid the obelisks that spawn. They'll damage you once they start moving!";
                break;
            case 4:
                title.text = "Juke and Dash!";
                description.text = @"Turns out the Shockwaves have another trick up their sleeve! Some are tall now, so you'll have to dash through them to avoid damage.

Also be sure to juke the oncomming Obelisks that now hone in on your location!";
                break;
            case 5:
                title.text = "Final Stand";
                description.text = @"Obelisks will arise from the ground. During this time the boss is immune and you have to shoot and take down all the Obelisks to lower the bosses shields!";
                break;
            case 6:
                title.text = "The First Boss";
                description.text = @"Prove yourself by combining all the mechanics you've learned to take down the first boss.";
                break;
        }

        Destroy(currentLoadedLevel);
        currentLoadedLevel = Instantiate(listOfLevels[currentLevel - 1]);
    }

    public void LoadNextLevel()
    {
        if (currentLevel != listOfLevels.Length)
        {
            currentLevel++;
            setFadeDuration();
        }      
    }

    public void LoadPreviousLevel()
    {
        if (currentLevel != 1)
        {
            currentLevel--;
            setFadeDuration();
        }   
    }

    public void PlayLevel()
    {
        //LOAD LEVEL, OFFSET BY AMOUNT OF SCENES THAT START BEFORE THE LEVEL
        StaticGameState.playing = true;
        SceneManager.LoadScene(currentLevel + 1);      
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void setFadeDuration()
    {
        timeTillFinishedFading = Time.timeSinceLevelLoad + fadeTime;
        fading = true;
    }

}
