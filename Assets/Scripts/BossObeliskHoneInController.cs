using UnityEngine;
using System.Collections;

public class BossObeliskHoneInController : MonoBehaviour
{

    [SerializeField]
    private GameObject obelisk;
    [SerializeField]
    private float timeToSpawnObelisk;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float secondStageTimeBetweenSpawns;
    private float timeBetweenObeliskSpawn;
    private int obeliskToSpawn;

    private int[] firstStagePatterns = { 0, 1 };

    private int[] secondStagePatterns = { 0 };
    private int secondStagePatternCounter;

    private BossController.Stages currentStage;

    void Start()
    {
        //MAKE THE ORDER OF OBELISK PATTERN SPAWNS RANDOM
        BossController.ShuffleArray<int>(firstStagePatterns);
        timeBetweenObeliskSpawn = timeBetweenWaves;
    }

    void Update()
    {
        switch (currentStage)
        {
            case BossController.Stages.first:
                autoReshufflePatterns(firstStagePatterns);
                break;
            case BossController.Stages.second:
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
                    case BossController.Stages.first:
                        firstStageAttack();
                        break;
                    case BossController.Stages.second:
                        secondStageAttack();
                        break;
                }
            }
        }
    }

    private void firstStageAttack()
    {
        switch (firstStagePatterns[obeliskToSpawn])
        {
            case 0:
                spawnLeftMostCorner();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
            case 1:
                spawnRightMostCorner();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
        }
    }

    private void secondStageAttack()
    {
        switch (secondStagePatterns[obeliskToSpawn])
        {
            case 0:
                timeBetweenObeliskSpawn = secondStageTimeBetweenSpawns;
                spawnSurrounderPattern();
                pushBackTimeTillSpawn();
                break;
            case 1:
                //spawnRightMostCorner();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
        }
    }

    public void setCurrentStage(BossController.Stages stage)
    {
        obeliskToSpawn = 0;
        currentStage = stage;
    }

    private void spawnMiddle()
    {
        Instantiate(obelisk, transform.TransformPoint(0, .35f, -4.0f), obelisk.transform.rotation);
    }

    private void spawnLeftMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(-3.80f, .35f, -4.075f), obelisk.transform.rotation);
    }

    private void spawnRightMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(3.80f, .35f, -4.075f), obelisk.transform.rotation);
    }

    private void spawnSurrounderPattern()
    {
        switch (secondStagePatternCounter) {
            case 0:
                Instantiate(obelisk, transform.TransformPoint(.5075f, .35f, -0.746f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 1:
                Instantiate(obelisk, transform.TransformPoint(1.94f, .35f, -2.16f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 2:
                Instantiate(obelisk, transform.TransformPoint(3.912f, .35f, -4.019f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 3:
                Instantiate(obelisk, transform.TransformPoint(1.94f, .35f, -5.90f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 4:
                Instantiate(obelisk, transform.TransformPoint(-1.94f, .35f, -5.90f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 5:
                Instantiate(obelisk, transform.TransformPoint(-3.912f, .35f, -4.019f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 6:
                Instantiate(obelisk, transform.TransformPoint(-1.94f, .35f, -2.16f), obelisk.transform.rotation);
                secondStagePatternCounter++;
                break;
            case 7:
                Instantiate(obelisk, transform.TransformPoint(-.5075f, .35f, -0.746f), obelisk.transform.rotation);
                secondStagePatternCounter = 0;
                timeBetweenObeliskSpawn = timeBetweenWaves;
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
