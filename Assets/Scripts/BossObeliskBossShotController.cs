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
            spawnSquarePattern();
        }

        int deadObeliskCount = 0;
        for (int i = 0; i < obeliskBossShotInstances.Length; i++)
        {
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

    private void spawnSquarePattern()
    {
        obeliskBossShotInstances[0] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(-1.870f, .35f, -3.0f), obeliskBossShot.transform.rotation);
        obeliskBossShotInstances[1] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(1.637f, .35f, -3.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 90, 0));
        obeliskBossShotInstances[2] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(1.543f, .35f, -5.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 180, 0));
        obeliskBossShotInstances[3] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(-1.680f, .35f, -5.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 270, 0));
    }

    public bool isImmune()
    {
        return immune;
    }
}
