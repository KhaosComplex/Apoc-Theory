using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    [SerializeField] private float fireRate;
    private float nextFire = 0.5f;
    private bool inMeleeRange = false;

    void Update()
    {
        //FIRE GUN, CONSISTENT WITH FIRE RATE
        if (Input.GetButton("Fire1") && Time.timeSinceLevelLoad > nextFire && !inMeleeRange)
        {
            nextFire = Time.timeSinceLevelLoad + fireRate;
            GameObject shotHolder = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotHolder.transform.parent = GameObject.Find("Player Shots").transform;
            // GetComponent<AudioSource>().Play();
        }
    }

    public void setMelee(bool set)
    {
        inMeleeRange = set;
        if (set)
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        else
            gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
