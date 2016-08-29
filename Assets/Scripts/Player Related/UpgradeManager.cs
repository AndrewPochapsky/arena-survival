using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Text damageText, speedText, healthText, firingRateText, shotSpeedText;

	// Update is called once per frame
	void Update () {
        damageText.text = Player.currentDamageUpgrades + "/" + Player.maxUpgrades;
        speedText.text = Player.currentSpeedUpgrades+ "/" + Player.maxUpgrades;
        healthText.text = Player.currentMaxHealthUpgrades+ "/" + Player.maxUpgrades;
        firingRateText.text = Player.currentFiringRateUpgrades + "/" + Player.maxUpgrades;
        shotSpeedText.text = Player.currentShotSpeedUpgrades+ "/" + Player.maxUpgrades;
    }

    public void IncreaseDamage(int _damage)
    {
        if (Player.skillPoints > 0 && Player.currentDamageUpgrades < Player.maxUpgrades)
        {
            Player.currentDamageUpgrades++;
            Player.damage += _damage;
            Player.skillPoints--;
        }
    }
    public void IncreaseSpeed(int _speed)
    {
        if (Player.skillPoints > 0 && Player.currentSpeedUpgrades < Player.maxUpgrades)
        {
            Player.currentSpeedUpgrades++;
            Player.speed += _speed;
            Player.skillPoints--;
        }
    }

    public void IncreaseMaxHealth(int _health)
    {
        if (Player.skillPoints > 0 && Player.currentMaxHealthUpgrades < Player.maxUpgrades)
        {
            Player.currentMaxHealthUpgrades++;
            HealthController.maxHealth += _health;
            Player.skillPoints--;
        }
    }

    public void IncreaseShotSpeed(int _shotSpeed)
    {
        if (Player.skillPoints > 0 && Player.currentShotSpeedUpgrades < Player.maxUpgrades)
        {
            Player.currentShotSpeedUpgrades++;
            Player.speedOfLaser += _shotSpeed;
            Player.skillPoints--;
        }
    }

    public void IncreaseFireRate(float _fireRate)
    {
        if (Player.skillPoints > 0 && Player.currentFiringRateUpgrades < Player.maxUpgrades)
        {
            Player.currentFiringRateUpgrades++;
            Player.firingRate += _fireRate;
            Player.skillPoints--;
        }
    }


}
