using UnityEngine;
using System.Collections;

public class BossShooter : MonoBehaviour
{
    [SerializeField] private Transform controller;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shot;

    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0.5f;

    [SerializeField] private float timeToStart;

    [SerializeField] private bool movingRight;

    private int currentStage;

    void Start()
    {
        timeToStart = Time.timeSinceLevelLoad + timeToStart;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToStart)
        {
            //CONTINUE ROTATING GUN IN THE DIRECTION IT'S TRAVELING
            if (movingRight == true)
                controller.rotation = Quaternion.RotateTowards(controller.rotation, end.rotation, Time.deltaTime * speed);
            else
                controller.rotation = Quaternion.RotateTowards(controller.rotation, start.rotation, Time.deltaTime * speed);

            //IF GUN HAS ROTATED FAR ENOUGH, BEGIN ROTATING IN OTHER DIRECTION
            if (movingRight == true && controller.eulerAngles.y <= end.eulerAngles.y)
                movingRight = false;
            else if (movingRight == false && controller.eulerAngles.y >= start.eulerAngles.y)
                movingRight = true;

            //NOW MAKE SURE THE GUN FIRES CONSISTENT WITH THE FIRE RATE
            if (Time.timeSinceLevelLoad > nextFire)
            {
                nextFire = Time.timeSinceLevelLoad + fireRate;
                GameObject shotHolder = (GameObject)Instantiate(shot, controller.position, controller.rotation);
                shotHolder.transform.parent = GameObject.Find("Boss Shots").transform;
            }
        }
    }

    void thirdStage()
    {
        speed = 300f;
        fireRate = .05f;
    }

    public void setCurrentStage(int stage)
    {
        currentStage = stage;

        switch(currentStage)
        {
            case 3:
                thirdStage();
                break;
        }
    }
}
