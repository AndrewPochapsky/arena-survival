using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {
    public Text damageText, speedText, healthText, firingRateText, shotSpeedText;

    //Enemy modifiers:
    public static int modifiedDamage = 1;
    public static int modifiedHealth = 3;
    public static int modifiedSpeed = 1;
    public static float modifiedFireRate = -0.1f;


    public static int maxUpgrades = 5;
    public static int currentDamageUpgrades = 0;
    public static int currentMaxHealthUpgrades = 0;
    public static int currentFiringRateUpgrades = 0;
    public static int currentShotSpeedUpgrades = 0;
    public static int currentSpeedUpgrades = 0;

    // Update is called once per frame
    void Update () {
        damageText.text = currentDamageUpgrades + "/" + maxUpgrades;
        speedText.text =  currentSpeedUpgrades+ "/" + maxUpgrades;
        healthText.text = currentMaxHealthUpgrades+ "/" + maxUpgrades;
        firingRateText.text = currentFiringRateUpgrades + "/" + maxUpgrades;
        shotSpeedText.text = currentShotSpeedUpgrades+ "/" + maxUpgrades;
    }

    public void IncreaseDamage(int _damage)
    {
        if (Player.skillPoints > 0 && currentDamageUpgrades < maxUpgrades)
        {
            currentDamageUpgrades++;
            Player.damage += _damage;
            Player.skillPoints--;
        }
    }
    public void IncreaseSpeed(float _speed)
    {
        if (Player.skillPoints > 0 && currentSpeedUpgrades < maxUpgrades)
        {
            currentSpeedUpgrades++;
            Player.speed += _speed;
            Player.skillPoints--;
        }
    }

    public void IncreaseShotSpeed(int _shotSpeed)
    {
        if (Player.skillPoints > 0 && currentShotSpeedUpgrades < maxUpgrades)
        {
            currentShotSpeedUpgrades++;
            Player.speedOfLaser += _shotSpeed;
            Player.skillPoints--;
        }
    }

    public void IncreaseFireRate(float _fireRate)
    {
        if (Player.skillPoints > 0 && currentFiringRateUpgrades < maxUpgrades)
        {
            currentFiringRateUpgrades++;
            Player.firingRate += _fireRate;
            Player.skillPoints--;
        }
    }


}
