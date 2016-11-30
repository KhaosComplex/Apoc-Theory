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
            Debug.Log(transform.TransformPoint(0,0,0));
            whichShockwaveToSpawn = Random.Range(0, 3);
            if (whichShockwaveToSpawn == 0)
            {
                Instantiate(shockwave, transform.TransformPoint(
                    0 / transform.localScale.x,
                    -3.5f / transform.localScale.y,
                    -9.6f / transform.localScale.z), shockwave.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
            else if (whichShockwaveToSpawn == 1)
            {
                Instantiate(shockwaveUP, transform.TransformPoint(
                    0 / transform.localScale.x,
                    -3.5f / transform.localScale.y,
                    -9.6f / transform.localScale.z), shockwaveUP.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
            else
            {
                Instantiate(shockwave, transform.TransformPoint(
                    0 / transform.localScale.x,
                    -3.5f / transform.localScale.y,
                    -9.6f / transform.localScale.z), shockwave.transform.rotation);
                Instantiate(shockwaveUP, transform.TransformPoint(
                    0 / transform.localScale.x,
                    -3.5f / transform.localScale.y,
                    -9.6f / transform.localScale.z), shockwaveUP.transform.rotation);
                timeToSpawnShockwave = Time.timeSinceLevelLoad + timeBetweenShockwaveSpawn;
            }
        }
    }
}
