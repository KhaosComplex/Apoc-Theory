using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    [SerializeField] private float fireRate;
    private float timeWhenCanFire = 0.5f;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > timeWhenCanFire)
        {
            timeWhenCanFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            // GetComponent<AudioSource>().Play();
        }
    }
}
