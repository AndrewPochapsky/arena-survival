using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public void Restart()
    {
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
    }



}
