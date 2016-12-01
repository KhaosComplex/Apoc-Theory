using UnityEngine;
using System.Collections;

public class BossObeliskHoneInController : MonoBehaviour
{

    [SerializeField]
    private GameObject obelisk;
    [SerializeField]
    private float timeToSpawnObelisk;
    [SerializeField]
    private float timeBetweenObeliskSpawn;
    private int[] firstStagePatterns = { 0, 1 };
    private int obeliskToSpawn;

    private BossController.Stages currentStage;

    void Start()
    {
        //MAKE THE ORDER OF OBELISK PATTERN SPAWNS RANDOM
        BossController.ShuffleArray<int>(firstStagePatterns);
    }

    void Update()
    {
        autoReshufflePatterns(firstStagePatterns);

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

    public void setCurrentStage(BossController.Stages stage)
    {
        currentStage = stage;
    }

    private void spawnMiddle()
    {
        Instantiate(obelisk, transform.TransformPoint(0, 0, -4.0f), obelisk.transform.rotation);
    }

    private void spawnLeftMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(-3.80f, 0, -4.075f), obelisk.transform.rotation);
    }

    private void spawnRightMostCorner()
    {
        Instantiate(obelisk, transform.TransformPoint(3.80f, 0, -4.075f), obelisk.transform.rotation);
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
