using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    public Text damage, speed, shotSpeed, fireRate;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        damage.text = "Damage: " + Player.damage.ToString();
        speed.text = "Speed: " + Player.speed.ToString();
        shotSpeed.text = "Shot Speed: " + Player.speedOfLaser.ToString();
        fireRate.text = "Fire Rate: " + Player.firingRate.ToString();
	}
}
