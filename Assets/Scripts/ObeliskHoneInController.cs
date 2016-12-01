using UnityEngine;
using System.Collections;

public class ObeliskHoneInController : MonoBehaviour
{

    [SerializeField] private float timeToWait;
    [SerializeField] private float speed;
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
        if (Time.timeSinceLevelLoad >= timeToMove)
        {
            if (!foundTarget)
            {
                transform.LookAt(new Vector3(playerObject.transform.position.x, transform.position.y, playerObject.transform.position.z));
                foundTarget = true;
                boxCollider.isTrigger = true;
            }
            
            rb.velocity = transform.forward * speed;
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
        //ONLY HURT THE PLAYER ONCE THE OBELISK IS MOVING
        if ((timeToMove - Time.timeSinceLevelLoad) >= (timeToWait - .02))
        {
            //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
            if (other.gameObject.tag.Equals("Player"))
            {
                playerObject.GetComponent<PlayerController>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }

}
