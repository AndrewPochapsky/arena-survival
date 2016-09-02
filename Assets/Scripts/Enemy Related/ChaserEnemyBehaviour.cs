using UnityEngine;
using System.Collections;

public class ChaserEnemyBehaviour : MonoBehaviour
{
    public HealthPack healthPack;
    public float dropRate = 0.33f;
    public int maxHealth=10;
    private Player player;
    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    public void Init()
    {
        currentHealth = maxHealth;
    }

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    public int scoreValue = 150;
    public float speed = 0.01f;
    private float range;
    //public AudioClip deathSound;

    public int damage = 2;

    public int GetDamage()
    {
        return damage;
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        Init();
        
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
    }

    void Update()
    {
        ChasePlayer();  
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
        if(Random.Range(0f,1f) <= dropRate)
        {
           Instantiate(healthPack, new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        }
       
        //AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            //LookAtPlayer
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            range = Vector2.Distance(transform.position, player.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }


    }
}
