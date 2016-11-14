using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0.5f;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
           // GetComponent<AudioSource>().Play();
        }
    }
}
