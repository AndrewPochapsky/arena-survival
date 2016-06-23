using UnityEngine;
using System.Collections;

public class ShooterEnemyBehaviour : MonoBehaviour
{
    public int speed;
    private float range;
    private PlayerController player;
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
        currentHealth = maxHealth;
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }


    
    public int scoreValue = 150;
    //private ScoreKeeper scoreKeeper;
    //public AudioClip fireSound;
    //public AudioClip deathSound;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        Init();
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            currentHealth -= missle.GetDamage();
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
        //scoreKeeper.Score(scoreValue);
        //AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

}