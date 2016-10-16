using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class Player : MonoBehaviour {
    Rigidbody2D rb;
    private FadeController fadeController;
    
    public AudioClip dieSound;
    private AudioSource audioSource;
    private float invincibleTime = 0.75f;
    public bool invincible = false;
    private PlayerProjectile proj;
    private HealthController healthController;
   
    private SpriteRenderer sp;
    private CircleCollider2D col;
    public static bool isAlive = true;

    public static float speedOfLaser = 10;
    public static float firingRate = 1f;
    public static int damage = 2;
    public static int skillPoints = 5;
    public static float speed = 5;

    public static bool canMove = true;
    private bool canDash;
    private float dashSpeed = 13;
    private float dashCoolDown = 0;

    private int healthBonus = 1;
    // Use this for initialization
    void Start () {
        col = GetComponent<CircleCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        fadeController = GameObject.FindObjectOfType<FadeController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("sfxVolume", 1);

        //Time.timeScale = 1;
        proj = GameObject.FindObjectOfType<PlayerProjectile>();
        rb = GetComponent<Rigidbody2D>();
        healthController = GameObject.FindObjectOfType<HealthController>();

    }

    // Update is called once per frame
    void Update()
    {
        firingRate = (float)Math.Round(firingRate, 2);
        speed = (float)Math.Round(speed, 2);
        
        if (dashCoolDown > 0)
        {
            canDash = false;
            dashCoolDown -= Time.deltaTime;
        }
        if(dashCoolDown <= 0)
        {
            canDash = true;
        }
        rb.freezeRotation = true;
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
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
       
        if (canDash)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(DashLeft());
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
            {
        
                StartCoroutine(DashUp());
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
            {

                StartCoroutine(DashRight());
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(DashDown());
            }
        }
    }


    IEnumerator OnTriggerStay2D(Collider2D col)
    {
        if (!invincible)
        {  
            ChargerEnemy chargerEnemy = col.gameObject.GetComponent<ChargerEnemy>();
            if (chargerEnemy)
            {
                audioSource.Play();
                healthController.currentHealth -= chargerEnemy.GetDamage();
                healthController.SetHealth(healthController.currentHealth, HealthController.maxHealth);

                if (healthController.currentHealth> 0)
                {
                    invincible = true;
                    yield return new WaitForSeconds(invincibleTime);
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
                audioSource.Play();
                healthController.currentHealth -= chaserEnemy.GetDamage();
                healthController.SetHealth(healthController.currentHealth, HealthController.maxHealth);
                if (healthController.currentHealth> 0)
                {
                    invincible = true;
                    yield return new WaitForSeconds(invincibleTime);
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
                    audioSource.Play();
                    healthController.currentHealth -= missle.GetDamage();
                    //invincible = true;
                     healthController.SetHealth(healthController.currentHealth, HealthController.maxHealth);
                    if (healthController.currentHealth > 0)
                    {
                        invincible = true;
                        yield return new WaitForSeconds(invincibleTime);
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
        if (healthPack && healthController.currentHealth!=HealthController.maxHealth)
        {
            healthController.currentHealth += healthPack.amountOfHealing;
            healthController.SetHealth(healthController.currentHealth, HealthController.maxHealth);
            Destroy(col.gameObject);
        }
    }

    void Die()
    {
        audioSource.Play();
        //HighScoreManager.StoreHighScore();
        fadeController.InstantiateFadeOutPanel();
        PlayerPrefs.SetInt("isInteractable", 0);

        HighScoreManager.DetermineHighScore();

        canMove = false;
        canDash = false;
        isAlive = false;
        sp.enabled = false;
        col.enabled = false;
        audioSource.Play();
        
        //AudioSource.PlayClipAtPoint(dieSound, transform.position);
       
        
        
    }
    
    IEnumerator DashUp()
    {
        canMove = false;
        rb.velocity = Vector2.up * dashSpeed;
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
        canMove = true;
        dashCoolDown = 2;   
    }

    IEnumerator DashDown()
    {
        canMove = false;
        rb.velocity = Vector2.down * dashSpeed;
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
        canMove = true;
        dashCoolDown = 2;
    }
    IEnumerator DashLeft()
    {
        canMove = false;
        rb.velocity = Vector2.left * dashSpeed;
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
        canMove = true;
        dashCoolDown = 2;
    }
    IEnumerator DashRight()
    {
        canMove = false;
        rb.velocity = Vector2.right * dashSpeed;
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
        canMove = true;
        dashCoolDown = 2;
    }

    public static int IncreaseSkillPoints(int _sp)
    {
        skillPoints += _sp;
        
        return skillPoints;
    }


    public void HealAfterWave()
    {
        if (healthController.currentHealth != HealthController.maxHealth)
        {
            healthController.currentHealth += healthBonus;
            healthController.SetHealth(healthController.currentHealth, HealthController.maxHealth);
        }  

    }

    //public void ChangeSFXVolume(float _volume)
    //{
    //    audioSource.volume = _volume;
    //}

}
