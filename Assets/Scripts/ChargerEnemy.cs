using UnityEngine;
using System.Collections;

public class ChargerEnemy: MonoBehaviour
{
   






    public int maxRayDistance = 25;
    private PlayerController player;
    public int maxHealth = 10;

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

    public float damage = 4f;

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

    //void Update()
    //{
    //    //ChasePlayer();
    //}
    Vector3 previousGood = Vector3.zero;

    void Update()
    {
        //    Ray ray = new Ray(transform.position, Vector2.left);
        //    Debug.DrawLine(transform.position, transform.position-Vector3.up*maxRayDistance, Color.red);

        Physics2D.Raycast(transform.position, transform.up, maxRayDistance);
        Vector3 up = transform.TransformDirection(Vector3.up) * maxRayDistance;
        Debug.DrawRay(transform.position,up, Color.green);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        PlayerProjectile missle = col.gameObject.GetComponent<PlayerProjectile>();
        if (missle)
        {
            currentHealth -= player.damage;
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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }


    }
}
