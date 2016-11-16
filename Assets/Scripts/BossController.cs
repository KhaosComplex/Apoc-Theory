using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
    
    [SerializeField] private float HP;
    [SerializeField] private Attack attack;

    private bool meleeMode = false;

    class Attack
    {
        private string name;
        private float time;
        private float hp;
        public Attack(string name, float time, float hp)
        {
            this.name = name;
            this.time = time;
            this.hp = hp;
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
