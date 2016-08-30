using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    
   
    public LevelManager levelManager;
    public AudioClip dieSound;
   
    public bool invincible = false;

    private LivesText livesText;
    private PlayerProjectile proj;


    public static float speedOfLaser = 10;
    public static float firingRate = 1f;
    public static int damage = 2;
    public static int skillPoints = 0;
    public static int speed = 5;
    public static int maxUpgrades = 5;
    public static int currentDamageUpgrades = 0;
    public static int currentMaxHealthUpgrades = 0;
    public static int currentFiringRateUpgrades = 0;
    public static int currentShotSpeedUpgrades = 0;
    public static int currentSpeedUpgrades = 0;

    // Use this for initialization
    void Start () {
        
        proj = GameObject.FindObjectOfType<PlayerProjectile>();
        rb = GetComponent<Rigidbody2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
       
        LivesText.ResetLives();
        HealthController.ResetHealth();


    }

    // Update is called once per frame
    void Update()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate (Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }


    IEnumerator OnTriggerStay2D(Collider2D col)
    {
        if (!invincible)
        {  
            ChargerEnemy chargerEnemy = col.gameObject.GetComponent<ChargerEnemy>();
            if (chargerEnemy)
            {
                HealthController.currentHealth -= chargerEnemy.GetDamage();

                if (HealthController.currentHealth> 0)
                {
                    invincible = true;
                    yield return new WaitForSeconds(2);
                    invincible = false;
                }
                else
                {
                    Die();
                }
            }
           

            
        }
    }

    IEnumerator OnCollisionStay2D(Collision2D col)
    {
        if (!invincible)
        {
            
            ChaserEnemyBehaviour chaserEnemy = col.gameObject.GetComponent<ChaserEnemyBehaviour>();
            if (chaserEnemy)
            {
                HealthController.currentHealth -= chaserEnemy.GetDamage();
                if (HealthController.currentHealth> 0)
                {
                    invincible = true;
                    yield return new WaitForSeconds(2);
                    invincible = false;
                }
                else
                {
                    Die();
                }
            
            }
        }
    }
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        print("Hit " + col);
        
            EnemyProjectile missle = col.gameObject.GetComponent<EnemyProjectile>();
            if (missle && missle.tag != "Friendly")
            {
                missle.Hit();
                if (!invincible)
                {
                    HealthController.currentHealth -= missle.GetDamage();
                    //invincible = true;

                    if (HealthController.currentHealth > 0)
                    {
                        invincible = true;
                        yield return new WaitForSeconds(2);
                        invincible = false;
                    }
                    else
                    {
                        Die();
                    }
                }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        HealthPack healthPack = col.gameObject.GetComponent<HealthPack>();
        if (healthPack && healthPack.canHeal)
        {
            HealthController.currentHealth += healthPack.amountOfHealing;
            Destroy(col.gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        levelManager.LoadLevel("Win");
    }
    



}
