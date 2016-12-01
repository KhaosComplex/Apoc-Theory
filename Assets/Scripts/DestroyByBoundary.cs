﻿using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("Attack"))
            Destroy(other.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("Attack"))
            Destroy(other.gameObject);
    }

}
