using UnityEngine;
using System.Collections;

public class PlayerShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody rb;

    void Start()
    {
        //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        //IF BOSS GETS HIT, HAVE BOSS LOSE HEALTH
        if (other.gameObject.tag.Equals("Boss"))
        {
            GetComponent<AudioSource>().Play();
            BossController bossController = other.gameObject.GetComponent<BossController>();
            if (!bossController.isImmune())
                bossController.takeDamage(damage);
            GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 1.0f);
        }
        else if (other.gameObject.tag.Equals("ObeliskBossShot"))
        {
            GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<ObeliskBossShotController>().takeDamage(damage);
            GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject, 1.0f);
        }
    }
}
