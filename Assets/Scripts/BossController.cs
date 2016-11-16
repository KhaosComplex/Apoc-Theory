using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
    
    [SerializeField] private float HP;

    public float getHP()
    {
        return HP;
    }

    public void setHP(float newHP)
    {
        HP = newHP;
    }

    public void takeDamage(float damage)
    {
        HP = HP - damage;
    }
}
