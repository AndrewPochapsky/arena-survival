using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;
    public static int savableCurrentHealth;
    public Text healthText;
    public static int maxHealth = 10;
    public static int healthDifference;

    //public static float currentHealth = 10f;

    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    void Awake()
    {
        if (DifficultyManager.difficulty == DifficultyManager.Difficulty.HARD)
        {
            maxHealth = 6;
        }

        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
    }
    void Start()
    {
        //savableCurrentHealth = currentHealth;
        currentHealth -= healthDifference;
        SetHealth(currentHealth, maxHealth);
    }

    void Update()
    {
        healthDifference = maxHealth - currentHealth;
        //print("Health difference: " +healthDifference);
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
        if (Player.skillPoints > 0 && UpgradeManager.currentMaxHealthUpgrades < UpgradeManager.maxUpgrades)
        {

            UpgradeManager.currentMaxHealthUpgrades++;
            maxHealth += _health;
            SetHealth(currentHealth, maxHealth);
            Player.skillPoints--;
        }
    }

}
