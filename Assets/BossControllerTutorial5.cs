using UnityEngine;
using System.Collections;

public class BossControllerTutorial5 : BossController
{
    [SerializeField]
    private float hpPerStage;

    private bool meleeMode = false;

    private int currentStage;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;
    private BossObeliskBossShotController bossObeliskBossShotController;
    private BossShockwaveController bossShockwaveController;

    void Start()
    {
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossObeliskBossShotController = GetComponent<BossObeliskBossShotController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

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
            case 1:

                break;
            case 2:
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

        bossShockwaveController.setCurrentStage(4);
        bossShockwaveController.enabled = true;

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

        bossObeliskBossShotController.setCurrentStage(6);
        bossObeliskBossShotController.enabled = true;

        foreach (BossBurstShooter bossShooterScript in bossBurstShooters)
        {
            bossShooterScript.enabled = false;
        }

        foreach (BossShooter bossShooterScript in bossLRShooters)
        {
            bossShooterScript.enabled = true;
        }
    }
}
