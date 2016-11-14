using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
