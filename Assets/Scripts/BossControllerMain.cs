using UnityEngine;
using System.Collections;

public class BossControllerMain : BossController
{

    [SerializeField] private float hpPerStage;
    private bool meleeMode = false;
    private int currentStage;

    private Component[] bossBurstShooters;
    private Component[] bossLRShooters;
    private BossSpikeController bossSpikeController;
    private BossObeliskController bossObeliskController;
    private BossObeliskBossShotController bossObeliskBossShotController;
    private BossObeliskHoneInController bossObeliskHoneInController;
    private BossShockwaveController bossShockwaveController;



    new void Start()
    {
        base.Start();
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossSpikeController = GetComponent<BossSpikeController>();
        bossObeliskController = GetComponent<BossObeliskController>();
        bossObeliskHoneInController = GetComponent<BossObeliskHoneInController>();
        bossObeliskBossShotController = GetComponent<BossObeliskBossShotController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

        if (StaticGameState.playing)
            StaticGameState.currentLevel = 6;

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
            mainCamera.shakeCamera();
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
}
