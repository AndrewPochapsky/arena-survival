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
        damage.text = Player.damage.ToString();
        speed.text = Player.speed.ToString();
        shotSpeed.text = Player.speedOfLaser.ToString();
        fireRate.text = Player.firingRate.ToString();
	}
}
