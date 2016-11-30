using UnityEngine;
using System.Collections;

public class BossBurstShooter : MonoBehaviour
{
    [SerializeField] private Transform controller;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shot;

    [SerializeField] private float rotationRateY;
    [SerializeField] private float timeBetweenBursts = 10.0f;
    [SerializeField] private float timeToStart;

    [SerializeField] private bool movingRight;

    private bool isFiring;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToStart)
        {
            isFiring = true;
            while (isFiring)
            {
                //MAKE SURE THE GUN FIRES
                if (isFiring)
                {
                    GameObject shotHolder = (GameObject)Instantiate(shot, controller.position, controller.rotation);
                    shotHolder.transform.parent = GameObject.Find("Boss Shots").transform;
                }

                //CONTINUE ROTATING GUN IN THE DIRECTION IT'S TRAVELING
                if (movingRight == true)
                    controller.rotation *= Quaternion.Euler(0, -rotationRateY, 0);
                else
                    controller.rotation *= Quaternion.Euler(0, rotationRateY, 0);

                //IF GUN HAS ROTATED FAR ENOUGH, BEGIN ROTATING IN OTHER DIRECTION
                if (movingRight == true && controller.eulerAngles.y <= end.eulerAngles.y)
                {
                    movingRight = false;
                    isFiring = false;
                    timeToStart = Time.timeSinceLevelLoad + timeBetweenBursts;
                }
                else if (movingRight == false && controller.eulerAngles.y >= start.eulerAngles.y)
                {
                    movingRight = true;
                    isFiring = false;
                    timeToStart = Time.timeSinceLevelLoad + timeBetweenBursts;
                }

            }
        }
    }
}
