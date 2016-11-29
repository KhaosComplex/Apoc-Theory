using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
    
    [SerializeField] private float HP;
    [SerializeField] private Attack attack;
    private bool immune;

    private float maxHP;
    private bool meleeMode = false;

    void Start()
    {
        maxHP = HP;
    }

    void Update()
    {
        immune = (GetComponent<BossObeliskBossShotController>().isImmune());

        Component[] bossShooters = GetComponentsInChildren<BossShooter>();
        foreach (BossShooter bossShooterScript in bossShooters)
        {
            if (immune)
                bossShooterScript.enabled = false;
            else
                bossShooterScript.enabled = true;
        }

    }

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

    public float getMaxHP()
    {
        return maxHP;
    }

    public void setHP(float newHP)
    {
        HP = newHP;
    }

    public void takeDamage(float damage)
    {
        HP = HP - damage;
    }

    public bool isImmune()
    {
        return immune;
    }
}
