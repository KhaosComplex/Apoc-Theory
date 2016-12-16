using UnityEngine;
using System.Collections;

public class ObeliskController : MonoBehaviour {

    [SerializeField] private Transform model;
    [SerializeField] private Transform end;
    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float speedToRise;
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
        if (model.position.y >= end.position.y)
        {
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
                rb.constraints = RigidbodyConstraints.None;
                boxCollider.isTrigger = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(model.transform.position, end.position, speedToRise * Time.deltaTime);
            timeToMove = Time.timeSinceLevelLoad + timeToWait;
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

    void OnCollisionEnter(Collision other)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 20;

        float verticalMovement = Input.GetAxis("Vertical");
        if (verticalMovement < 0)
        {
            force = force * 2;
        }

        // If the object we hit is the enemy
        if (other.gameObject.tag.Equals("Player"))
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            //MAKE SURE WE DON'T LAUNCH THE PLAYER UPWARDS
            dir = new Vector3(dir.x, 0, dir.z);

            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            other.gameObject.GetComponent<CharacterController>().Move(dir * force);
        }
    }
}
