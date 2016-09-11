using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    public Text damage, speed, shotSpeed, fireRate, skillText, skillPopUp;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        damage.text = "Damage: " + Player.damage.ToString();
        speed.text = "Speed: " + Player.speed.ToString();
        shotSpeed.text = "Shot Speed: " + Player.speedOfLaser.ToString();
        fireRate.text = "Fire Rate: " + Player.firingRate.ToString();
        skillText.text = "Skill Points: " + Player.skillPoints.ToString();

        if(WaveSpawner.popUp)
        {
            StartCoroutine(PopUp());
        }
       
    }

    public IEnumerator PopUp()
    {
        float lerp = Mathf.PingPong(Time.time, fadeDuration) / fadeDuration;

        alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
        color.a = alpha;
        renderer.color = color;
        skillPopUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        skillPopUp.gameObject.SetActive(false);
        
    }

}
