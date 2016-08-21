﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{


    public Text healthText;

    public static float health = 10f;


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
        health = 10f;
    }

    public void IncreaseHealth(int _health)
    {
        if (PlayerController.skillPoints > 0)
        {
            health += _health;
            PlayerController.skillPoints--;
        }
    }



}
