using UnityEngine;
using System.Collections;

public class BossControllerTutorial3 : BossController
{
    [SerializeField]
    private float hpPerStage;

    private bool meleeMode = false;

    private int currentStage;

    private BossObeliskController bossObeliskController;
    private BossShockwaveController bossShockwaveController;


    void Start()
    {
        maxHP = HP;

        bossObeliskController = GetComponent<BossObeliskController>();
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

                break;
        }

    }

    private void firstStage()
    {
        currentStage = 1;

        bossObeliskController.setCurrentStage(3);
        bossObeliskController.enabled = true;

        bossShockwaveController.setCurrentStage(4);
        bossShockwaveController.enabled = true;

    }

    private void secondStage()
    {
        currentStage = 2;

        bossObeliskController.setCurrentStage(4);
    }
}
