using UnityEngine;
using System.Collections;

public class BossShockwaveController : MonoBehaviour
{
    [SerializeField] private GameObject shockwave;
    [SerializeField] private GameObject shockwaveUP;
    [SerializeField] private float timeToSpawnShockwave;
    [SerializeField] private float timeBetweenShockwaveSpawn;
    private int whichShockwaveToSpawn;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnShockwave)
        {
            GameObject shockwaveInstance;
            whichShockwaveToSpawn = Random.Range(0, 3);
            if (whichShockwaveToSpawn == 0)
            {
                shockwaveInstance = (GameObject)Instantiate(shockwave, new Vector3(0, 0, -42.77f), shockwave.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
            else if (whichShockwaveToSpawn == 1)
            {
                shockwaveInstance = (GameObject)Instantiate(shockwaveUP, new Vector3(0, 0, -42.77f), shockwaveUP.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
            else
            {
                shockwaveInstance = (GameObject)Instantiate(shockwave, new Vector3(0, 0, -42.77f), shockwave.transform.rotation);
                shockwaveInstance = (GameObject)Instantiate(shockwaveUP, new Vector3(0, 0, -42.77f), shockwaveUP.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
        }
    }
}
