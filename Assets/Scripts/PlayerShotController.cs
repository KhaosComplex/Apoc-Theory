using UnityEngine;
using System.Collections;

public class PlayerShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody rb;
    private GameObject bossObject;

    void Start()
    {
        //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        bossObject = GameObject.FindWithTag("Boss");
    }

    void OnTriggerEnter(Collider other)
    {
        //IF BOSS GETS HIT, HAVE BOSS LOSE HEALTH
        if (other.gameObject.tag.Equals("Boss"))
        {
            bossObject.GetComponent<BossController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
