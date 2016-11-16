using UnityEngine;
using System.Collections;

public class ObeliskController : MonoBehaviour {

    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private int direction;
    private float currentTime;
    private Rigidbody rb;

    void Start ()
    {
        currentTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
	    if ((Time.time - currentTime) >= timeToWait) {
            switch(direction)
            {
                //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
                case 1:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * speed;
                    break;
                case 2:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = -transform.forward * speed;
                    break;
                case 3:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = transform.right * speed;
                    break;
                case 4:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = -transform.right * speed;
                    break;
            }
        }
	}

    public int getDirection()
    {
        return direction;
    }

    public void setDirection(int directionToTravelIn)
    {
        direction = directionToTravelIn;
    }

}
