using UnityEngine;
using System.Collections;

public class PlayerShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody rb;
    private GameObject bossObject;
    private GameObject obeliskBossShotObject;

    void Start()
    {
        //WHEN PROJECTILE IS SPAWNED, SEND IT FORWARD
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        bossObject = GameObject.FindWithTag("Boss");
        obeliskBossShotObject = GameObject.FindWithTag("ObeliskBossShot");
    }

    void OnTriggerEnter(Collider other)
    {
        //IF BOSS GETS HIT, HAVE BOSS LOSE HEALTH
        if (other.gameObject.tag.Equals("Boss"))
        {
            BossController bossController = bossObject.GetComponent<BossController>();
            if (!bossController.isImmune()) bossController.takeDamage(damage);

            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag.Equals("ObeliskBossShot"))
        {
            obeliskBossShotObject.GetComponent<ObeliskBossShotController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
