using UnityEngine;
using System.Collections;

public class BossShockwaveController : MonoBehaviour
{
    [SerializeField] private GameObject shockwave;
    [SerializeField] private GameObject shockwaveUP;
    [SerializeField] private float timeToSpawnShockwave;
    [SerializeField] private float fourthStageTimeBetweenShockwaveSpawn;
    [SerializeField] private float fifthStageTimeBetweenShockwaveSpawn;
    private float timeBetweenShockwaveSpawn;

    private int currentStage;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnShockwave)
        {
            switch (currentStage)
            {
                case 4:
                    fourthStageAttack();
                    break;
                case 5:
                    fifthAndSixthStageAttack();
                    break;
                case 6:
                    fifthAndSixthStageAttack();
                    break;
            }
        }
    }

    private void fourthStageAttack()
    {
        //SPAWN HORIZONTAL SHOCKWAVE
        spawnShockwaveHorizontal();
        pushBackTimeTillSpawn();
    }

    /*private void hardStageAttack()
    {
        switch (Random.Range(0, 2))
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
        }
    }*/

    private void fifthAndSixthStageAttack()
    {
        //PICK ONE OF THE 3 SHOCKWAVES TO SPAWN
        switch (Random.Range(0, 2))
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
        }
    }

    public void setCurrentStage(int stage)
    {
        currentStage = stage;

        switch (currentStage)
        {
            case 4:
                timeBetweenShockwaveSpawn = fourthStageTimeBetweenShockwaveSpawn;
                break;
            case 5:
                timeBetweenShockwaveSpawn = fifthStageTimeBetweenShockwaveSpawn;
                break;
        }
    }

    private void spawnShockwaveHorizontal()
    {
        Instantiate (shockwave, transform.TransformPoint(0, -.35f, -.96f), shockwave.transform.rotation);
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
