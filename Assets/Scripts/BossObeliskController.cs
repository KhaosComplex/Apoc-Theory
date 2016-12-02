using UnityEngine;
using System.Collections;

public class BossObeliskController : MonoBehaviour
{

    [SerializeField]
    private GameObject obelisk;
    [SerializeField]
    private float timeToSpawnObelisk;
    [SerializeField] private float thirdStageTimeBetweenObeliskSpawns;
    [SerializeField] private float fourthStageTimeBetweenObeliskSpawns;
    private float timeBetweenObeliskSpawn;
    private int[] mainStagePatterns = { 0, 1, 2 };
    private int obeliskToSpawn;

    private int currentStage;

    void Start()
    {
        //MAKE THE ORDER OF OBELISK PATTERN SPAWNS RANDOM
        BossController.ShuffleArray<int>(mainStagePatterns);
    }

    void Update()
    {
        autoReshufflePatterns(mainStagePatterns);

        bool immune = GetComponent<BossObeliskBossShotController>().isImmune();

        //ONLY IF OUR BOSS ISN'T IN THE IMMUNE STATE, DO WE USE THE OBELISK ATTACKS
        if (!immune)
        {
            //SPAWN BASED ON THE RATE
            if (Time.timeSinceLevelLoad >= timeToSpawnObelisk)
            {
                switch (currentStage)
                {
                    case 3:
                        mainStageAttack();
                        break;
                    case 4:
                        mainStageAttack();
                        break;
                }
            }
        }
    }

    private void mainStageAttack()
    {
        switch (mainStagePatterns[obeliskToSpawn])
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

    public void setCurrentStage(int stage)
    {
        obeliskToSpawn = 0;
        currentStage = stage;

        switch(currentStage)
        {
            case 3:
                timeBetweenObeliskSpawn = thirdStageTimeBetweenObeliskSpawns;
                break;
            case 4:
                timeBetweenObeliskSpawn = fourthStageTimeBetweenObeliskSpawns;
                break;
        }
    }

    private void spawnTrianglePattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-.5f, -1.899f, -.65f), obelisk.transform.rotation * Quaternion.Euler(0, 30, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.backward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(0, -1.899f, -.75f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.backward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(.5f, -1.899f, -.65f), obelisk.transform.rotation * Quaternion.Euler(0, -30, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.backward);
    }

    private void spawnBackArrayPattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-1.95f, -1.899f, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-.975f, -1.899f, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(0, -1.899f, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(.975f, -1.899f, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(1.95f, -1.899f, -5.9f), obelisk.transform.rotation);
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);
    }

    private void spawnConvergerSideCornerPattern()
    {
        GameObject obeliskInstant;
        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-3.6f, -1.899f, -4.35f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-2.85f, -1.899f, -5.1f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-2.1f, -1.899f, -5.85f), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(2.1f, -1.899f, -5.85f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(2.85f, -1.899f, -5.1f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);

        obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(3.6f, -1.899f, -4.35f), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
        obeliskInstant.GetComponentInChildren<ObeliskController>().setDirection(ObeliskController.Directions.forward);
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
