using UnityEngine;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncreaseDamage(int _damage)
    {
        if (Player.skillPoints > 0)
        {
            Player.damage += _damage;
            Player.skillPoints--;
        }
    }
    public void IncreaseSpeed(int _speed)
    {
        if (Player.skillPoints > 0)
        {
            Player.speed += _speed;
            Player.skillPoints--;
        }
    }

    public void IncreaseMaxHealth(int _health)
    {
        if (Player.skillPoints > 0)
        {
            HealthController.maxHealth += _health;
            Player.skillPoints--;
        }
    }

    public void IncreaseShotSpeed(int _shotSpeed)
    {
        if (Player.skillPoints > 0)
        {
            Player.speedOfLaser += _shotSpeed;
            Player.skillPoints--;
        }
    }

    public void IncreaseFireRate(float _fireRate)
    {
        if (Player.skillPoints > 0)
        {
            Player.firingRate += _fireRate;
            Player.skillPoints--;
        }
    }


}
