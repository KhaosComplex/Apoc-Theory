using UnityEngine;
using System.Collections;

public class BossControllerTutorial1 : BossController
{
    [SerializeField] private float hpPerStage;

    private bool meleeMode = false;

    private int currentStage;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;

    new void Start()
    {
        base.Start();
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();

        if (StaticGameState.playing)
            StaticGameState.currentLevel = 1;

        firstStage();

    }

    void Update()
    {
        if (healthLost >= hpPerStage && HP > 0)
        {
            healthLost = healthLost % hpPerStage;
            switch (currentStage)
            {
                case 1:
                    secondStage();
                    break;
            }
            mainCamera.shakeCamera();
        }

        switch (currentStage)
        {
            case 1:

                break;
            case 2:

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
