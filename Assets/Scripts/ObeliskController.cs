using UnityEngine;
using System.Collections;

public class ObeliskController : MonoBehaviour {

    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Directions direction;
    private float timeToMove;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private GameObject playerObject;

    public enum Directions {forward, backward, right, left };

    void Start ()
    {
        timeToMove = Time.timeSinceLevelLoad + timeToWait;

        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        playerObject = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad >= timeToMove)
        {
            switch (direction)
            {
                //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
                case Directions.forward:
                    rb.velocity = transform.forward * speed;
                    break;
                case Directions.backward:
                    rb.velocity = -transform.forward * speed;
                    break;
                case Directions.right:
                    rb.velocity = transform.right * speed;
                    break;
                case Directions.left:
                    rb.velocity = -transform.right * speed;
                    break;
            }

            boxCollider.isTrigger = true;
        } 
	}

    public Directions getDirection()
    {
        return direction;
    }

    public void setDirection(Directions directionToTravelIn)
    {
        direction = directionToTravelIn;
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

    /*void OnCollisionEnter(Collision other)
    {
        //ONLY HURT THE PLAYER ONCE THE OBELISK IS MOVING
        if ((timeToMove-Time.timeSinceLevelLoad) >= (timeToWait-.02))
        {
            //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
            if (other.gameObject.tag.Equals("Player"))
            {
                playerObject.GetComponent<PlayerController>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }*/

}
