﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
public class SaveManager : MonoBehaviour {

    public int testNumber = 3;

    public static SaveManager saveManager;

    private HealthController healthController;
	// Use this for initialization
	void Awake () {
        healthController = GetComponent<HealthController>();
        
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

       
        data.damage = Player.damage;
        data.shotspeed = Player.speedOfLaser;
        data.speed = Player.speed;
        data.fireRate = Player.firingRate;
        //data.currentHealth = healthController.currentHealth;
        data.maxHealth = HealthController.maxHealth;
        data.healthDifference = HealthController.healthDifference;

        data.skillPoints = Player.skillPoints;
        data.currentDamageUpgrades = UpgradeManager.currentDamageUpgrades;
        data.currentMaxHealthUpgrades = UpgradeManager.currentMaxHealthUpgrades;
        data.currentSpeedUpgrades = UpgradeManager.currentSpeedUpgrades;
        data.currentShotSpeedUpgrades = UpgradeManager.currentShotSpeedUpgrades;
        data.currentFiringRateUpgrades = UpgradeManager.currentFiringRateUpgrades;

        data.currentWave = WaveSpawner.currentWave;
        data.nextWave = WaveSpawner.nextWave;
        bf.Serialize(file, data);
        Debug.Log("saved");
        file.Close();
        
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Player.damage = data.damage;
            Player.speedOfLaser = data.shotspeed;
            Player.speed = data.speed;
            Player.firingRate = data.fireRate;
            //healthController.currentHealth = data.currentHealth;
            HealthController.maxHealth = data.maxHealth;
            HealthController.healthDifference = data.healthDifference;

            Player.skillPoints = data.skillPoints;
            UpgradeManager.currentDamageUpgrades = data.currentDamageUpgrades;
            UpgradeManager.currentMaxHealthUpgrades = data.currentMaxHealthUpgrades;
            UpgradeManager.currentSpeedUpgrades = data.currentSpeedUpgrades;
            UpgradeManager.currentShotSpeedUpgrades = data.currentShotSpeedUpgrades;
            UpgradeManager.currentFiringRateUpgrades = data.currentFiringRateUpgrades;

            WaveSpawner.currentWave = data.currentWave;
            WaveSpawner.nextWave = data.nextWave;
        }
    }

}

[Serializable]
class PlayerData
{
    public int healthDifference;
    public float shotspeed, speed, fireRate;
    public int damage, currentHealth, maxHealth, skillPoints, currentDamageUpgrades, currentMaxHealthUpgrades, currentSpeedUpgrades, currentShotSpeedUpgrades, currentFiringRateUpgrades;
    public int currentWave, nextWave;
}
