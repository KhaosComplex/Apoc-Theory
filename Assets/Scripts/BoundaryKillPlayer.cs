using UnityEngine;
using System.Collections;

public class BoundaryKillPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            other.gameObject.GetComponent<PlayerController>().killPlayer();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            Destroy(other.gameObject);
    }

}
