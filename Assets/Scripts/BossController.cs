using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

    [SerializeField]
    private float HP;
    [SerializeField]
    private Attack attack;
    [SerializeField] private float hpPerStage;
    private bool immune;

    private float maxHP;
    private bool meleeMode = false;

    private int currentStage;
    private float healthLost;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;
    private BossSpikeController bossSpikeController;
    private BossObeliskController bossObeliskController;
    private BossObeliskBossShotController bossObeliskBossShotController;
    private BossObeliskHoneInController bossObeliskHoneInController;
    private BossShockwaveController bossShockwaveController;



    void Start()
    {
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossSpikeController = GetComponent<BossSpikeController>();
        bossObeliskController = GetComponent<BossObeliskController>();
        bossObeliskHoneInController = GetComponent<BossObeliskHoneInController>();
        bossObeliskBossShotController = GetComponent<BossObeliskBossShotController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

        firstStage();

    }

    void Update()
    {
        if (healthLost >= hpPerStage)
        {
            healthLost = healthLost % hpPerStage;
            switch(currentStage)
            {
                case 1:
                    secondStage();
                    break;
                case 2:
                    thirdStage();
                    break;
                case 3:
                    fourthStage();
                    break;
                case 4:
                    fifthStage();
                    break;
                case 5:
                    sixthStage();
                    break;
            }
        }

        switch (currentStage)
        {
            case 0:

                break;
            case 1:

                break;
            case 6:
                immune = (GetComponent<BossObeliskBossShotController>().isImmune());

                foreach (BossShooter bossShooterScript in bossLRShooters)
                {
                    if (immune)
                        bossShooterScript.enabled = false;
                    else
                        bossShooterScript.enabled = true;
                }
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

        bossSpikeController.setCurrentStage(currentStage);
        bossSpikeController.enabled = true;
    }

    private void thirdStage()
    {
        currentStage = 3;

        foreach (BossBurstShooter bossShooterScript in bossBurstShooters)
        {
            bossShooterScript.enabled = false;
        }

        foreach (BossShooter bossShooterScript in bossLRShooters)
        {
            bossShooterScript.enabled = true;
        }

        bossSpikeController.setCurrentStage(currentStage);

        bossObeliskController.setCurrentStage(currentStage);
        bossObeliskController.enabled = true;

    }

    private void fourthStage()
    {
        currentStage = 4;

        bossObeliskController.setCurrentStage(currentStage);
        bossShockwaveController.setCurrentStage(currentStage);
        bossSpikeController.setCurrentStage(currentStage);

        bossShockwaveController.setCurrentStage(currentStage);
        bossShockwaveController.enabled = true;

    }

    private void fifthStage()
    {
        currentStage = 5;

        bossObeliskController.enabled = false;

        bossShockwaveController.setCurrentStage(currentStage);

        bossObeliskHoneInController.setCurrentStage(currentStage);
        bossObeliskHoneInController.enabled = true;
    }

    private void sixthStage()
    {
        currentStage = 6;

        bossShockwaveController.setCurrentStage(currentStage);
        bossObeliskHoneInController.setCurrentStage(currentStage);

        bossObeliskBossShotController.setCurrentStage(currentStage);
        bossObeliskBossShotController.enabled = true;
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
