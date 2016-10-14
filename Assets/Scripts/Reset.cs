﻿using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
    bool hasPlayed = false;
    public void Restart()
    {
        TutorialScreen.done = false;

        Player.canMove = true;
        Player.isAlive = true;
        Player.speedOfLaser = 10;
        Player.damage = 2;
        Player.firingRate = 1f;
        Player.speed = 5f;
        Player.skillPoints = 0;

        UpgradeManager.currentDamageUpgrades = 0;
        UpgradeManager.currentFiringRateUpgrades = 0;
        UpgradeManager.currentMaxHealthUpgrades = 0;
        UpgradeManager.currentShotSpeedUpgrades = 0;
        UpgradeManager.currentSpeedUpgrades = 0;

        WaveSpawner.currentWave = 1;
        WaveSpawner.nextWave = 0;
        WaveSpawner.timesLooped = 0;

        HealthController.healthDifference = 0;
        HealthController.maxHealth = 10;

        HighScoreManager.localNormalHighScore = 1;
        HighScoreManager.localEasyHighScore = 1;
    }



}
