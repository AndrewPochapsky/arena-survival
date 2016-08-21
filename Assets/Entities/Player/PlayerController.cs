using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private IsClicked isClicked;
    Rigidbody2D rb;
    public int speed;
    public float padding = 1;
    float xmin;
    float xmax;
    public LevelManager levelManager;
    public AudioClip dieSound;
    public int damage = 2;
    public static int skillPoints = 0;
    public bool invincible = false;
    private LivesText livesText;
    private PlayerProjectile proj;
	// Use this for initialization
	void Start () {
        isClicked = GameObject.FindObjectOfType<IsClicked>();
        proj = GameObject.FindObjectOfType<PlayerProjectile>();
        rb = GetComponent<Rigidbody2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
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
        //restrict the player to the gamespace
        //float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        //transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }



    IEnumerator OnCollisionStay2D(Collision2D col)
    {
        if (!invincible)
        {
            
            ChaserEnemyBehaviour chaserEnemy = col.gameObject.GetComponent<ChaserEnemyBehaviour>();
            if (chaserEnemy)
            {
                HealthController.health -= chaserEnemy.GetDamage();
                if (HealthController.health > 0)
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
                    HealthController.health -= missle.GetDamage();
                    //invincible = true;

                    if (HealthController.health > 0)
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

    void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        levelManager.LoadLevel("Win");
    }

    public void IncreaseDamage(int _damage)
    {
        if (skillPoints > 0)
        {
            damage += _damage;
            skillPoints--;
        }
    }

    
}
