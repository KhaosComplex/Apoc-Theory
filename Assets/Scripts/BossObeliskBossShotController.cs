using UnityEngine;
using System.Collections;

public class BossObeliskBossShotController : MonoBehaviour
{
    [SerializeField] private GameObject obeliskBossShot;
    [SerializeField] private float timeToSpawnObeliskBossShots;
    [SerializeField] private float timeBetweenObeliskBossShotsSpawn;
    private GameObject[] obeliskBossShotInstances;
    bool immune;

    private int currentStage;

    void Start()
    {
        obeliskBossShotInstances = new GameObject[4];
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnObeliskBossShots)
        {
            switch (currentStage)
            {
                case 6:
                    sixthStage();
                    break;
            }
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

    private void sixthStage()
    {
        spawnSquarePattern();
    }

    private void spawnSquarePattern()
    {
        obeliskBossShotInstances[0] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(-1.870f, -1.899f, -3.0f), obeliskBossShot.transform.rotation);
        obeliskBossShotInstances[1] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(1.637f, -1.899f, -3.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 90, 0));
        obeliskBossShotInstances[2] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(1.543f, -1.899f, -5.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 180, 0));
        obeliskBossShotInstances[3] = (GameObject)Instantiate(obeliskBossShot, transform.TransformPoint(-1.680f, -1.899f, -5.0f), obeliskBossShot.transform.rotation * Quaternion.Euler(0, 270, 0));
    }

    public void setCurrentStage(int stage)
    {
        currentStage = stage;
    }

    public bool isImmune()
    {
        return immune;
    }
}
