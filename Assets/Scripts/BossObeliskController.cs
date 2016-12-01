using UnityEngine;
using System.Collections;

public class BossObeliskController : MonoBehaviour
{

    [SerializeField]
    private GameObject obelisk;
    [SerializeField]
    private float timeToSpawnObelisk;
    [SerializeField]
    private float timeBetweenObeliskSpawn;
    private int[] firstStagePatterns = { 0, 1, 2 };
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
                spawnTrianglePattern();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
            case 1:
                spawnBackArrayPattern();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
            case 2:
                spawnConvergerSideCornerPattern();
                pushBackTimeTillSpawn();
                obeliskToSpawn++;
                break;
        }
    }

    public void setCurrentStage(BossController.Stages stage)
    {
        currentStage = stage;
    }

    private void spawnTrianglePattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-.5f, 0, -.65f), obelisk.transform.rotation * Quaternion.Euler(0, 30, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(0, 0, -.75f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(.5f, 0, -.65f), obelisk.transform.rotation * Quaternion.Euler(0, -30, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);
    }

    private void spawnBackArrayPattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-1.95f, 0, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-.975f, 0, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(0, 0, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(.975f, 0, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(1.95f, 0, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);
    }

    private void spawnConvergerSideCornerPattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-3.6f, 0, -4.35f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-2.85f, 0, -5.1f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-2.1f, 0, -5.85f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(2.1f, 0, -5.85f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(2.85f, 0, -5.1f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(3.6f, 0, -4.35f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);
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
