using UnityEngine;
using System.Collections;

public class BossObeliskController : MonoBehaviour {

    [SerializeField] private GameObject obelisk;
    [SerializeField] private float timeToSpawnObelisk;
    [SerializeField] private float timeBetweenObeliskSpawn;
    private int[] whichObeliskToSpawn = { 0, 1, 2 };
    private int nextObeliskPattern;

    private BossController.Stages currentStage;

    void Start()
    {
        BossController.ShuffleArray<int>(whichObeliskToSpawn);
    }

    void Update()
    {
        if (nextObeliskPattern == whichObeliskToSpawn.Length)
        {
            nextObeliskPattern = 0;
            BossController.ShuffleArray<int>(whichObeliskToSpawn);
        }

        bool immune = GetComponent<BossObeliskBossShotController>().isImmune();

        if (!immune)
        {
            if (Time.timeSinceLevelLoad >= timeToSpawnObelisk)
            {
               if (currentStage == BossController.Stages.first)
                {
                    firstStageAttack();
                }
            }
        }
    }

    private void firstStageAttack()
    {
        GameObject obeliskInstant;
        switch (whichObeliskToSpawn[nextObeliskPattern])
        {
            case 0:
                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -6.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, 30, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    0 / transform.localScale.x,
                    0 / transform.localScale.y,
                    -7.5f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -6.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, -30, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);

                timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                nextObeliskPattern++;
                break;
            case 1:
                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -19.5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -59f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -9.75f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -59f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    0 / transform.localScale.x,
                    0 / transform.localScale.y,
                    -59f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    9.75f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -59f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    19.5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -59f / transform.localScale.z), obelisk.transform.rotation);
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                nextObeliskPattern++;
                break;
            case 2:
                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -36f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -43.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -28.5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -51f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    -21f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -58.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, 45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    21f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -58.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    28.5f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -51f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(
                    36f / transform.localScale.x,
                    0 / transform.localScale.y,
                    -43.5f / transform.localScale.z), obelisk.transform.rotation * Quaternion.Euler(0, -45, 0));
                obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);

                timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                nextObeliskPattern++;
                break;
        }
    }

    public void setCurrentStage(BossController.Stages stage)
    {
        currentStage = stage;
    }


}

                /*if (whichObeliskToSpawn == 0)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(0, 0, -5f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 1)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-18.23f, 0, 13.5f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.right);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 2)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(18.73f, 0, 5.28f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.left);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 3)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-35f, 0, -3.9f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.right);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 4)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(31f, 0, -9.91f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.left);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 5)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, transform.TransformPoint(-4.75f, 0, -21.64f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn* 4;
                    whichObeliskToSpawn = 0;
                }*/
