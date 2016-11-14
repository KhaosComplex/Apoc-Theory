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
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        playerObject = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            playerObject.GetComponent<PlayerController>().setHP((playerObject.GetComponent<PlayerController>().getHP()) - damage);
            Destroy(this.gameObject);
        }
    }
}
