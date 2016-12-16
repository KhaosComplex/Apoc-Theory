using UnityEngine;
using System.Collections;

public class BossSpikeController : MonoBehaviour
{
    [SerializeField]
    private GameObject spike;
    [SerializeField]
    private float timeToSpawnSpike;
    [SerializeField]
    private float timeBetweenSpikeSpawn;
    [SerializeField]
    private float timeToWaitBeforeFirstSpike;
    private GameObject playerObject;

    private int currentStage;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        timeToWaitBeforeFirstSpike = Time.timeSinceLevelLoad + timeToWaitBeforeFirstSpike;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToWaitBeforeFirstSpike)
        {
            if (Time.timeSinceLevelLoad >= timeToSpawnSpike)
            {
                switch (currentStage)
                {
                    case 2:
                        mainStageAttack();
                        pushBackTimeTillSpawn();
                        break;
                    case 3:
                        mainStageAttack();
                        pushBackTimeTillSpawn();
                        break;
                    case 6:
                        mainStageAttack();
                        pushBackTimeTillSpawn();
                        break;
                }
            }
        }
    }

    private void mainStageAttack()
    {
        //SPAWN THE SPIKE BENEATH THE PLAYER
        spawnSpikeAtPlayerPosition();
    }

    public void setCurrentStage(int stage)
    {
        currentStage = stage;
    }

    private void spawnSpikeAtPlayerPosition()
    {
        Debug.Log("Player: " + playerObject.transform.position);
        GameObject spikeHolder = (GameObject)Instantiate(spike, new Vector3(playerObject.transform.position.x, 0, playerObject.transform.position.z), spike.transform.rotation);
        spikeHolder.transform.parent = GameObject.Find("Boss Shots").transform;
        Debug.Log("spikeHolder: " + spikeHolder.transform.position);
    }

    private void pushBackTimeTillSpawn()
    {
        timeToSpawnSpike = Time.timeSinceLevelLoad + timeBetweenSpikeSpawn;
    }
}
