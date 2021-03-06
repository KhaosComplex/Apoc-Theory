﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    new void Start()
    {
        base.Start();
        maxHP = HP;
        bossBurstShooters = GetComponentsInChildren<BossBurstShooter>();
        bossLRShooters = GetComponentsInChildren<BossShooter>();
        bossObeliskBossShotController = GetComponent<BossObeliskBossShotController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

        if (StaticGameState.playing)
            StaticGameState.currentLevel = 5;

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
            if (SceneManager.GetActiveScene().buildIndex != 1)
                mainCamera.shakeCamera();
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
