using UnityEngine;
using System.Collections;

public class BossControllerLevel1 : MonoBehaviour
{

    [SerializeField]
    private float HP;
    [SerializeField]
    private float hpPerStage;
    private bool immune;

    private float maxHP;
    private bool meleeMode = false;

    private int currentStage;
    private float healthLost;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;

    void Start()
    {
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();

        firstStage();

    }

    void Update()
    {
        if (healthLost >= hpPerStage)
        {
            healthLost = healthLost % hpPerStage;
            switch (currentStage)
            {
                case 1:
                    secondStage();
                    break;
            }
        }

        switch (currentStage)
        {
            case 0:

                break;
            case 1:

                break;
        }

    }

    private void firstStage()
    {
        currentStage = 1;

        foreach (BossBurstShooter bossShooterScript in bossBurstShooters)
        {
            bossShooterScript.enabled = true;
        }

        /*foreach (BossShooter bossShooterScript in bossLRShooters)
        {
            bossShooterScript.enabled = true;
        }*/

    }

    private void secondStage()
    {
        currentStage = 2;
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
        healthLost += damage;
    }

    public bool isImmune()
    {
        return immune;
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
