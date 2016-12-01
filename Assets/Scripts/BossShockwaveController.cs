using UnityEngine;
using System.Collections;

public class BossShockwaveController : MonoBehaviour
{
    [SerializeField] private GameObject shockwave;
    [SerializeField] private GameObject shockwaveUP;
    [SerializeField] private float timeToSpawnShockwave;
    [SerializeField] private float timeBetweenShockwaveSpawn;

    private BossController.Stages currentStage;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnShockwave)
        {
            switch (currentStage)
            {
                case BossController.Stages.first:
                    firstStageAttack();
                    break;
                case BossController.Stages.third:
                    thirdStageAttack();
                    break;
            }
        }
    }

    private void firstStageAttack()
    {
        //SPAWN HORIZONTAL SHOCKWAVE
        spawnShockwaveHorizontal();
        pushBackTimeTillSpawn();
    }

    private void thirdStageAttack()
    {
        //PICK ONE OF THE 3 SHOCKWAVES TO SPAWN
        switch (Random.Range(0, 3))
        {
            //SPAWN HORIZONTAL SHOCKWAVE
            case 0:
                spawnShockwaveHorizontal();
                pushBackTimeTillSpawn();
                break;
            //SPAWN VERTICAL SHOCKWAVE
            case 1:
                spawnShockwaveVertical();
                pushBackTimeTillSpawn();
                break;
            //SPAWN BOTH
            case 2:
                spawnShockwaveHorizontal();
                spawnShockwaveVertical();
                pushBackTimeTillSpawn();
                break;
        }
    }

    public void setCurrentStage(BossController.Stages stage)
    {
        currentStage = stage;
    }

    private void spawnShockwaveHorizontal()
    {
        Instantiate(shockwave, transform.TransformPoint(0, -.35f, -.96f), shockwave.transform.rotation);
    }

    private void spawnShockwaveVertical()
    {
        Instantiate(shockwaveUP, transform.TransformPoint(0, -.35f, -.96f), shockwaveUP.transform.rotation);
    }

    private void pushBackTimeTillSpawn()
    {
        timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
    }
}
