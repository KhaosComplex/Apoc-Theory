using UnityEngine;
using System.Collections;

public class BossShockwaveController : MonoBehaviour
{
    [SerializeField] private GameObject shockwave;
    [SerializeField] private float timeToSpawnShockwave;
    [SerializeField] private float timeBetweenShockwaveSpawn;
    private int whichShockwaveToSpawn;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawnShockwave)
        {
            GameObject shockwaveInstance;
            if (whichShockwaveToSpawn == 0)
            {
                shockwaveInstance = (GameObject)Instantiate(shockwave, new Vector3(0, 0, -42.77f), shockwave.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
        }
    }
}
