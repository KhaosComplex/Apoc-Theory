using UnityEngine;
using System.Collections;

public class ObeliskBossShotController : MonoBehaviour {
    [SerializeField] private Transform container;
    [SerializeField] private Transform end;
    [SerializeField] private float speedToRise;
    [SerializeField] private float HP;

    void Update()
    {
        if (container.position.y >= end.position.y)
        {
            if (HP <= 0)
            {
                Destroy(transform.parent.parent.gameObject);
            }
        }
        else
        {
            container.transform.position = Vector3.MoveTowards(container.transform.position, end.position, speedToRise * Time.deltaTime);
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
        if (container.position.y == end.position.y)
            HP = HP - damage;
    }

}
