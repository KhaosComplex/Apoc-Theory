using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    [SerializeField] private float fireRate;
    private float nextFire = 0.5f;

    void Update()
    {
        //FIRE GUN, CONSISTENT WITH FIRE RATE
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shotHolder = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation); ;
            shotHolder.transform.parent = GameObject.Find("Player Shots").transform;
            // GetComponent<AudioSource>().Play();
        }
    }
}
