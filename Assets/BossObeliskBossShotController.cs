using UnityEngine;
using System.Collections;

public class BossObeliskBossShotController : MonoBehaviour
{

    [SerializeField] private GameObject obeliskBossShot;
    [SerializeField] private float timeToSpawnObeliskBossShots;
    [SerializeField] private float timeBetweenObeliskBossShotsSpawn;
    private GameObject[] obeliskBossShotInstances;
    bool immune;

    void Start()
    {
        obeliskBossShotInstances = new GameObject[4];
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnObeliskBossShots)
        {
            obeliskBossShotInstances[0] = (GameObject)Instantiate(obeliskBossShot, new Vector3(-18.70f, 8.50f, 9.30f), obeliskBossShot.transform.rotation);
            obeliskBossShotInstances[1] = (GameObject)Instantiate(obeliskBossShot, new Vector3(16.37f, 8.50f, 10.10f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 90, 0));
            obeliskBossShotInstances[2] = (GameObject)Instantiate(obeliskBossShot, new Vector3(15.43f, 8.50f, -19.78f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 180, 0));
            obeliskBossShotInstances[3] = (GameObject)Instantiate(obeliskBossShot, new Vector3(-16.80f, 8.50f, -20.30f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 270, 0));
        }

        int deadObeliskCount = 0;
        for (int i = 0; i < obeliskBossShotInstances.Length; i++)
        {
            //Debug.Log(obeliskBossShotInstances[i]);
            if (obeliskBossShotInstances[i] == null) deadObeliskCount++;
        }

        if (deadObeliskCount != obeliskBossShotInstances.Length)
        {
            timeToSpawnObeliskBossShots = Time.timeSinceLevelLoad + timeBetweenObeliskBossShotsSpawn;
            immune = true;
        }
        else
            immune = false;

    }

    public bool isImmune()
    {
        return immune;
    }
}
