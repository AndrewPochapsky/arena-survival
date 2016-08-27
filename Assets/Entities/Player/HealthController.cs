using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{


    public Text healthText;
    public static float maxHealth = 10f;
    public static float currentHealth = 10f;


    void Start()
    {

        healthText = GetComponent<Text>();
    }

    void Update()
    {

        healthText.text = "Health: " + currentHealth.ToString()+"/"+maxHealth.ToString();

    }

    public static void ResetHealth()
    {
        maxHealth = 10f;
        currentHealth = 10f;
    }

    //public void IncreaseCurrentHealth(int _health)
    //{
    //    if (PlayerController.skillPoints > 0)
    //    {
    //        currentHealth += _health;
    //        PlayerController.skillPoints--;
    //    }
    //}
    //public void IncreaeMaxHe


}
