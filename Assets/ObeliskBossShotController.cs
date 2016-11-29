using UnityEngine;
using System.Collections;

public class ObeliskBossShotController : MonoBehaviour {

    [SerializeField] private float HP;

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        } 
    }

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
