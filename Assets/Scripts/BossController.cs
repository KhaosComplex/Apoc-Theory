using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

    [SerializeField]
    private float HP;
    [SerializeField]
    private Attack attack;
    private bool immune;

    private float maxHP;
    private bool meleeMode = false;

    public enum Stages { first, second, third };
    private Stages currentStage;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;
    private BossObeliskController bossObeliskController;
    private BossObeliskBossShotController bossObeliskBossShotController;
    private BossObeliskHoneInController bossObeliskHoneInController;
    private BossShockwaveController bossShockwaveController;



    void Start()
    {
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossObeliskController = GetComponent<BossObeliskController>();
        bossObeliskHoneInController = GetComponent<BossObeliskHoneInController>();
        bossObeliskBossShotController = GetComponent<BossObeliskBossShotController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

        firstStage();

    }

    void Update()
    {
        if (currentStage != Stages.second && HP > maxHP / 3 && HP <= maxHP * 2 / 3)
        {
            currentStage = Stages.second;
            secondStage();
        }
        else if (currentStage != Stages.third && HP <= maxHP / 3)
        {
            currentStage = Stages.third;
            thirdStage();
        }

        switch (currentStage)
        {
            case Stages.first:
                break;
            case Stages.second:

                break;
            case Stages.third:

                immune = (GetComponent<BossObeliskBossShotController>().isImmune());

                Component[] bossShooters = GetComponentsInChildren<BossBurstShooter>();
                foreach (BossBurstShooter bossShooterScript in bossShooters)
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
        currentStage = Stages.first;

        foreach (BossBurstShooter bossShooterScript in bossBurstShooters)
        {
            bossShooterScript.enabled = true;
        }

        bossObeliskController.setCurrentStage(currentStage);
        bossObeliskController.enabled = true;

        bossObeliskHoneInController.setCurrentStage(currentStage);
        bossObeliskHoneInController.enabled = true;

        bossShockwaveController.setCurrentStage(currentStage);
        bossShockwaveController.enabled = true;
    }

    private void secondStage()
    {
        currentStage = Stages.second;

        bossObeliskController.setCurrentStage(currentStage);
    }

    private void thirdStage()
    {
        currentStage = Stages.third;

        bossObeliskController.setCurrentStage(currentStage);
        bossShockwaveController.setCurrentStage(currentStage);
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
