using UnityEngine;
using System.Collections;

public class MeleeController : MonoBehaviour {

    private bool damageOK = false;

    //UPDATES IF BOSS IS IN MELEE HITBOX
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Boss"))
            damageOK = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Boss"))
            damageOK = false;
    }

    //IS BOSS IN MELEE HITBOX
    public bool doesDamage()
    {
        return damageOK;
    }
}
