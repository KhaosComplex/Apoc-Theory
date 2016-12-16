using UnityEngine;
using System.Collections;

public class BossControllerTutorial2 : BossController
{
    [SerializeField]
    private float hpPerStage;

    private bool meleeMode = false;

    private int currentStage;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;
    private BossSpikeController bossSpikeController;

    new void Start()
    {
        base.Start();
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossSpikeController = GetComponent<BossSpikeController>();

        if (StaticGameState.playing)
            StaticGameState.currentLevel = 2;

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
        bossSpikeController.setCurrentStage(2);
        bossSpikeController.enabled = true;

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
