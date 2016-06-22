using UnityEngine;
using System.Collections;

public class ChaserEnemyBehaviour : MonoBehaviour
{
    
    private PlayerController player;
    public int maxHealth=10;

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

    
    private float minDistance = 1f;
    private float range;
    private ScoreKeeper scoreKeeper;
    //public AudioClip deathSound;

    public float damage = 2f;

    public float GetDamage()
    {
        return damage;
    }

    void Start()
    {
        Init();
        player = GameObject.FindObjectOfType<PlayerController>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

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
        print("Hit "+col);
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
        scoreKeeper.Score(scoreValue);
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

            //if (range > minDistance)
            //{
            // Debug.Log(range);

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            // }
        }


    }
   
    void GetDamaged()
    {

    }

}
