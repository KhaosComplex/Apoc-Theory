using UnityEngine;
using System.Collections;

public class ObeliskBossShotShooter : MonoBehaviour
{
    [SerializeField]
    private Transform controller;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private float fireRate = 0.5f;
    private float nextFire = 0.5f;

    [SerializeField]
    private bool movingRight;

    void Update()
    {
        Quaternion nextRotation = controller.rotation;
        nextRotation *= Quaternion.Euler(0, 10, 0);
        controller.rotation = Quaternion.RotateTowards(controller.rotation, nextRotation, Time.deltaTime * speed);

        //NOW MAKE SURE THE GUN FIRES CONSISTENT WITH THE FIRE RATE
        if (Time.timeSinceLevelLoad > nextFire)
        {
            nextFire = Time.timeSinceLevelLoad + fireRate;
            GameObject shotHolder = (GameObject)Instantiate(shot, controller.position, controller.rotation);
            shotHolder.transform.parent = GameObject.Find("Boss Shots").transform;
        }
    }
}
