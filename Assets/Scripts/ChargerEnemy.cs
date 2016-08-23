using UnityEngine;
using System.Collections;

public class ChargerEnemy: MonoBehaviour
{
    bool noMore = false;
    float chargeTime= 5f;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    public int maxRayDistance = 100;
    private PlayerController player;
    public int maxHealth = 25;

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
    public bool spotted = false;
    public float GetDamage()
    {
        return damage;
    }
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerController>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
    void Start()
    {
     
        Init();
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
    }

   

    void Update()
    {
        if (!spotted)
        {
            DetectPlayerPosition();
        }
        else if (spotted)
        {
            Charge();
        }
    }


    void OnTriggerEnter2D(Collider2D col)
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

    void DetectPlayerPosition()
    {   
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector2.up));
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            print("player hit with raycast");
            playerPos = hit.transform.position;
            spotted = true;  
        }
    }

    void Charge()
    { 
        print("Charging");
        rb.AddForce((playerPos -transform.position) * speed);
        rb.angularDrag = 0.05f;
        Invoke("Transition", 5f);  
    }

   void Transition()
    {
        spotted = false;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0.05f;
    }

}
