using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotSpawn;

    [SerializeField] private float fireRate;
    private float nextFire;
    private bool inMeleeRange = false;

    [SerializeField] private bool controller;

    void Start()
    {
        if (controller)
        {
            GetComponent<AimAtMouse>().enabled = false;
        }
    }

    void Update()
    {
        if (controller)
        {
            //GET THE CONTROLLER ROTATIONAL DIRECTION
            float horizontalRotation = Input.GetAxis("Right_Horizontal");
            float verticalRotation = -Input.GetAxis("Right_Vertical");

            float angleForRotation = Mathf.Atan2(horizontalRotation, verticalRotation) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angleForRotation, 0);

            if ((horizontalRotation != 0 || verticalRotation != 0) && Time.timeSinceLevelLoad > nextFire && !inMeleeRange)
            {
                nextFire = Time.timeSinceLevelLoad + fireRate;
                GameObject shotHolder = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                shotHolder.transform.parent = GameObject.Find("Player Shots").transform;
                // GetComponent<AudioSource>().Play();
            }
        }
        else {

            //FIRE GUN, CONSISTENT WITH FIRE RATE
            if (Input.GetButton("Fire1") && Time.timeSinceLevelLoad > nextFire && !inMeleeRange)
            {
                nextFire = Time.timeSinceLevelLoad + fireRate;
                GameObject shotHolder = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                shotHolder.transform.parent = GameObject.Find("Player Shots").transform;
                // GetComponent<AudioSource>().Play();
            }
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

    public bool getController()
    {
        return controller;
    }

    public void setController(bool controllerBool)
    {
        controller = controllerBool;
    }
}
