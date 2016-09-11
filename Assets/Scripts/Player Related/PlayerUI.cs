using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {

    public Text damage, speed, shotSpeed, fireRate, skillText, skillPopUp;

    private float fadeDuration = 0.75f;
    private float alpha = 0;
    private Color color;
    // Use this for initialization
    void Start() {
        color = skillPopUp.color;
    }

    // Update is called once per frame
    void Update() {
        damage.text = "Damage: " + Player.damage.ToString();
        speed.text = "Speed: " + Player.speed.ToString();
        shotSpeed.text = "Shot Speed: " + Player.speedOfLaser.ToString();
        fireRate.text = "Fire Rate: " + Player.firingRate.ToString();
        skillText.text = "Skill Points: " + Player.skillPoints.ToString();
        PopUp();


    }

    void PopUp()
    {

        if (WaveSpawner.popUp)
        {

            skillPopUp.gameObject.SetActive(true);

        }
        else
        {
            skillPopUp.gameObject.SetActive(false);
        }
        float lerp = Mathf.PingPong(Time.time, fadeDuration) / fadeDuration;

        alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
        color.a = alpha;
        skillPopUp.color = color;
    }

  

}
