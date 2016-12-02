using UnityEngine;
using System.Collections;

public class BossObeliskHoneInController : MonoBehaviour
{

    [SerializeField]
    private GameObject obelisk;
    [SerializeField]
    private float timeToSpawnObelisk;
    [SerializeField] private float timeBetweenWavesFifthStage;
    [SerializeField] private float fifthStageTimeBetweenSpawns;
    private float timeBetweenObeliskSpawn;
    private int obeliskToSpawn;

    private int[] firstStagePatterns = { 0, 1 };

    private int[] secondStagePatterns = { 0 };
    private int secondStagePatternCounter;

    private int currentStage;

    void Start()
    {
        //MAKE THE ORDER OF OBELISK PATTERN SPAWNS RANDOM
        BossController.ShuffleArray<int>(firstStagePatterns);
        timeBetweenObeliskSpawn = timeBetweenWavesFifthStage;
    }

    void Update()
    {
        switch (currentStage)
        {
            case 1:
                autoReshufflePatterns(firstStagePatterns);
                break;
            case 2:
                autoReshufflePatterns(secondStagePatterns);
                break;
        }

        bool immune = GetComponent<BossObeliskBossShotController>().isImmune();

        //ONLY IF OUR BOSS ISN'T IN THE IMMUNE STATE, DO WE USE THE OBELISK ATTACKS
        if (!immune)
        {
            //SPAWN BASED ON THE RATE
            if (Time.timeSinceLevelLoad >= timeToSpawnObelisk)
            {
                //FIRST STAGE ATTACK
                switch (currentStage)
                {
                    case 5:
                        mainStageAttack();
                        pushBackTimeTillSpawn();
                        break;
                    case 6:
                        mainStageAttack();
                        pushBackTimeTillSpawn();
                        break;
                }
            }
        }
    }

    private void mainStageAttack()
    {
          timeBetweenObeliskSpawn = fifthStageTimeBetweenSpawns;
          spawnSurrounderPattern();
    }

    public void setCurrentStage(int stage)
    {
        obeliskToSpawn = 0;
        currentStage = stage;
    }

    private void spawnMiddle()
    {
        Instantiate(obelisk, transform.TransformPoint(0, -1.899f, -4.0f), obelisk.transform.rotation);
    }

    private void spawnLeftMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(-3.80f, -1.899f, -4.075f), obelisk.transform.rotation);
    }

    private void spawnRightMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(3.80f, -1.899f, -4.075f), obelisk.transform.rotation);
    }

    private void spawnSurrounderPattern()
    {
        switch (secondStagePatternCounter) {
            case 0:
                Instantiate(obelisk, transform.TransformPoint(.5075f, -1.899f, -0.746f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 1:
                Instantiate(obelisk, transform.TransformPoint(1.94f, -1.899f, -2.16f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 2:
                Instantiate(obelisk, transform.TransformPoint(3.912f, -1.899f, -4.019f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 3:
                Instantiate(obelisk, transform.TransformPoint(1.94f, -1.899f, -5.90f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 4:
                Instantiate(obelisk, transform.TransformPoint(-1.94f, -1.899f, -5.90f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 5:
                Instantiate(obelisk, transform.TransformPoint(-3.912f, -1.899f, -4.019f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 6:
                Instantiate(obelisk, transform.TransformPoint(-1.94f, -1.899f, -2.16f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 7:
                Instantiate(obelisk, transform.TransformPoint(-.5075f, -1.899f, -0.746f), obelisk.transform.rotation);
                secondStagePatternCounter = 0;
                timeBetweenObeliskSpawn = timeBetweenWavesFifthStage;
                break;
        }
    }

    private void pushBackTimeTillSpawn()
    {
        timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
    }

    private void autoReshufflePatterns(int[] obeliskPatterns)
    {
        //IF WE'VE REACHED THE END OF OUR LIST OF OBELISK PATTERNS
        if (obeliskToSpawn == obeliskPatterns.Length)
        {
            //RESET THE POSITION BACK TO 0 AND RESHUFFLE THE PATTERNS
            obeliskToSpawn = 0;
            BossController.ShuffleArray<int>(obeliskPatterns);
        }
    }
}
