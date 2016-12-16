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

    void OnCollisionEnter(Collision other)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 20;

        float verticalMovement = Input.GetAxis("Vertical");
        if (verticalMovement < 0)
        {
            force = force * 2;
        }

        // If the object we hit is the enemy
        if (other.gameObject.tag.Equals("Player"))
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            dir = new Vector3(dir.x, 0, dir.z);
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            other.gameObject.GetComponent<CharacterController>().Move(dir * force);
        }
    }

}
