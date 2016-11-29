using UnityEngine;
using System.Collections;

public class BossObeliskController : MonoBehaviour {

    [SerializeField] private GameObject obelisk;
    [SerializeField] private float timeToSpawnObelisk;
    [SerializeField] private float timeBetweenObeliskSpawn;
    private int whichObeliskToSpawn;

    void Update()
    {
        bool immune = GetComponent<BossObeliskBossShotController>().isImmune();

        if (!immune)
        {
            if (Time.timeSinceLevelLoad >= timeToSpawnObelisk)
            {
                GameObject obeliskInstant;
                if (whichObeliskToSpawn == 0)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(5.3f, 7.6f, 24.43f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.backward);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 1)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(-18.23f, 7.6f, 13.5f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.right);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 2)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(18.73f, 7.6f, 5.28f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.left);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 3)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(-35f, 7.6f, -3.9f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.right);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 4)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(31f, 7.6f, -9.91f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.left);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn;
                    whichObeliskToSpawn++;
                }
                else if (whichObeliskToSpawn == 5)
                {
                    obeliskInstant = (GameObject)Instantiate(obelisk, new Vector3(-4.75f, 7.6f, -21.64f), obelisk.transform.rotation);
                    obeliskInstant.GetComponent<ObeliskController>().setDirection(ObeliskController.Directions.forward);
                    timeToSpawnObelisk = Time.timeSinceLevelLoad + timeBetweenObeliskSpawn * 4;
                    whichObeliskToSpawn = 0;
                }
            }
        }
    }
}
