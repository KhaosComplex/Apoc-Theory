﻿using UnityEngine;
using System.Collections;

public class PlayerShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody rb;
    private GameObject bossObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        bossObject = GameObject.FindWithTag("Boss");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Boss"))
        {
            bossObject.GetComponent<BossController>().setHP((bossObject.GetComponent<BossController>().getHP()) - damage);
            Destroy(this.gameObject);
        }
    }
}
