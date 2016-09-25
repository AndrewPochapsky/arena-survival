using UnityEngine;
using System.Collections;

public class ShooterEnemyBehaviour : MonoBehaviour
{
    

    public float dropRate = 0.33f;
    public HealthPack healthPack;
    public int speed;
    public static float distance;
    private Player player;
    public int maxHealth = 20;

    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    public void Init()
    {
        player = GameObject.FindObjectOfType<Player>();
        currentHealth = maxHealth;
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
    }

    void Awake()
    {
        
        speed += UpgradeManager.modifiedSpeed * WaveSpawner.timesLooped;
        maxHealth += UpgradeManager.modifiedHealth * WaveSpawner.timesLooped;
    }

    void Start()
    {

        Init();
        
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerProjectile missle = col.gameObject.GetComponent<PlayerProjectile>();
        if (missle)
        {
            currentHealth -= Player.damage;
            missle.Hit();
            if (currentHealth <= 0)
            {
                Die();
            }

            if (statusIndicator != null)
            {
                statusIndicator.SetHealth(currentHealth, maxHealth);
            }
        }
    }

   

    

    void Die()
    {
        Destroy(gameObject);
        if (Random.Range(0f, 1f) <= dropRate)
        {
            Instantiate(healthPack, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

}