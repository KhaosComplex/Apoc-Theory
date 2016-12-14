using UnityEngine;
using System.Collections;

public class ObeliskHoneInController : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private Transform end;
    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
    [SerializeField] private float speedToRise;
    [SerializeField] private float damage;

    private float timeToMove;
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private GameObject playerObject;
    private bool foundTarget;

    void Start()
    {
        timeToMove = Time.timeSinceLevelLoad + timeToWait;

        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (model.position.y == end.position.y)
        {
            if (Time.timeSinceLevelLoad >= timeToMove)
            {
                if (!foundTarget)
                {
                    transform.LookAt(new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z));
                    foundTarget = true;
                    boxCollider.isTrigger = true;
                }
                rb.constraints = RigidbodyConstraints.None;
                rb.velocity = transform.forward * speed;
            }
            else
            {
                transform.LookAt(new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z));
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(model.transform.position, end.position, speedToRise * Time.deltaTime);
            timeToMove = Time.timeSinceLevelLoad + timeToWait;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //ONLY HURT THE PLAYER ONCE THE OBELISK IS MOVING
        if (Time.timeSinceLevelLoad >= timeToMove)
        {
            //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
            if (other.gameObject.tag.Equals("Player"))
            {
                playerObject.GetComponent<PlayerController>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 20;

        // If the object we hit is the enemy
        if (other.gameObject.tag.Equals("Player"))
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            other.gameObject.GetComponent<CharacterController>().Move(dir * force);
        }
    }

}
