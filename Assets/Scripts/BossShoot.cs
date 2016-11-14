using UnityEngine;
using System.Collections;

public class BossShoot : MonoBehaviour
{
    public Transform controller, start, end;
    public float speed;
    public GameObject shot;

    public float fireRate = 0.5f;
    private float nextFire = 0.5f;
    public bool movingRight;

    void Update()
    {
        Debug.Log("C" + controller.eulerAngles.y);
        Debug.Log("S" + start.eulerAngles.y);
        Debug.Log("E" + end.eulerAngles.y);
        Debug.Log(movingRight);
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
