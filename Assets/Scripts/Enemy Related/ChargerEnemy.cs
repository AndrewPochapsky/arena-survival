using UnityEngine;
using System.Collections;

public class ChargerEnemy: MonoBehaviour
{

    public float dropRate = 0.33f;
    public HealthPack healthPack;    
    private Rigidbody2D rb;
    private Vector3 playerPos;
    public int maxRayDistance = 100;
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

    public float speed = 0.01f;


  
    //public AudioClip deathSound;

    public int damage = 4;
    public bool spotted = false;
    public int GetDamage()
    {
        return damage;
    }
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
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
