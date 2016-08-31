using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;

    public Text healthText;
    public int maxHealth = 10;
    //public static float currentHealth = 10f;

    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }


    void Start()
    {
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
    }

    void Update()
    {

        //healthText.text = "Health: " + currentHealth.ToString()+"/"+maxHealth.ToString();

    }

    //public static void ResetHealth()
    //{
    //    maxHealth = 10;
    //    currentHealth = 10;
    //}

    public void SetHealth(int _current, int _max)
    {
        float _value = (float)_current / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _current + "/" + _max + " HP";
    }

    public void IncreaseMaxHealth(int _health)
    {
        if (Player.skillPoints > 0 && Player.currentMaxHealthUpgrades < Player.maxUpgrades)
        {

            Player.currentMaxHealthUpgrades++;
            maxHealth += _health;
            SetHealth(currentHealth, maxHealth);
            Player.skillPoints--;
        }
    }

}
