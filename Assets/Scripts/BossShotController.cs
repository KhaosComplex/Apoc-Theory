using UnityEngine;
using System.Collections;

public class BossShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody rb;
    private GameObject playerObject;

    void Start()
    {
        //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;


        playerObject = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        //IF PLAYER GETS HIT, HAVE PLAYER LOSE HEALTH
        if(other.gameObject.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
