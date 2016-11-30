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
            obeliskBossShotInstances[0] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(
                -18.70f / transform.localScale.x, 
                3.5f / transform.localScale.y, 
                -30f / transform.localScale.z), obeliskBossShot.transform.rotation);

            obeliskBossShotInstances[1] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(
                16.37f / transform.localScale.x,
                3.5f / transform.localScale.y, 
                -30f / transform.localScale.z), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 90, 0));

            obeliskBossShotInstances[2] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(
                15.43f / transform.localScale.x,
                3.5f / transform.localScale.y, 
                -50f / transform.localScale.z), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 180, 0));

            obeliskBossShotInstances[3] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(
                -16.80f / transform.localScale.x,
                3.5f / transform.localScale.y, 
                -50f / transform.localScale.z), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 270, 0));
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
