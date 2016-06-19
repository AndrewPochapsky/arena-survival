using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{


    public Text healthText;
  
    public static float health = 250f;


    void Start()
    {
        
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        
        healthText.text = "Health: " + health.ToString();

    }

    public static void ResetHealth()
    {
        health = 250f;
    }

   



}
