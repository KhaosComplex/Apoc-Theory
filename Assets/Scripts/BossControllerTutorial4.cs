using UnityEngine;
using System.Collections;

public class BossControllerTutorial4 : BossController
{
    [SerializeField]
    private float hpPerStage;

    private bool meleeMode = false;

    private int currentStage;

    private BossObeliskHoneInController bossObeliskHoneInController;
    private BossShockwaveController bossShockwaveController;


    new void Start()
    {
        base.Start();
        maxHP = HP;

        bossObeliskHoneInController = GetComponent<BossObeliskHoneInController>();
        bossShockwaveController = GetComponent<BossShockwaveController>();

        if (StaticGameState.playing)
            StaticGameState.currentLevel = 4;

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

        bossObeliskHoneInController.setCurrentStage(5);
        bossObeliskHoneInController.enabled = true;

        bossShockwaveController.setCurrentStage(4);
        bossShockwaveController.enabled = true;

    }

    private void secondStage()
    {
        currentStage = 2;

        bossShockwaveController.setCurrentStage(5);
    }
}
