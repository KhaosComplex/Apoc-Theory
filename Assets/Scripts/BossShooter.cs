using UnityEngine;
using System.Collections;

public class BossShooter : MonoBehaviour
{
    [SerializeField] private Transform controller, start, end;
    [SerializeField] private float speed;
    [SerializeField] private GameObject shot;

    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0.5f;
    [SerializeField] private bool movingRight;

    void Update()
    {
        if (movingRight == true)
            controller.rotation = Quaternion.RotateTowards(controller.rotation, end.rotation, Time.deltaTime * speed);
       else
            controller.rotation = Quaternion.RotateTowards(controller.rotation, start.rotation,Time.deltaTime * speed);
        if (movingRight == true && controller.eulerAngles.y <= end.eulerAngles.y)
            movingRight = false;
        else if (movingRight == false && controller.eulerAngles.y >= start.eulerAngles.y)
            movingRight = true;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, controller.position, controller.rotation);
        }
    }
}
