using UnityEngine;
using System.Collections;

public class ObeliskController : MonoBehaviour {

    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private int direction;
    private float currentTime;
    private Rigidbody rb;
    private GameObject playerObject;

    public enum Directions {forward, backward, right, left };

    void Start ()
    {
        currentTime = Time.time;

        playerObject = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	    if ((Time.time - currentTime) >= timeToWait) {
            switch(direction)
            {
                //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
                case (int)Directions.forward:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * speed;
                    break;
                case (int)Directions.backward:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = -transform.forward * speed;
                    break;
                case (int)Directions.right:
                    rb = GetComponent<Rigidbody>();
                    rb.velocity = transform.right * speed;
                    break;
                case (int)Directions.left:
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

    public void setDirection(Directions directionToTravelIn)
    {
        direction = (int)directionToTravelIn;
    }

    void OnTriggerEnter(Collider other)
    {
        //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
        if (other.gameObject.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
