using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    public int speed;
    public float padding = 1;
    float xmin;
    float xmax;
    public float health = 250;
    public LevelManager levelManager;
    public AudioClip dieSound;
    
    
    private LivesText livesText;
   
	// Use this for initialization
	void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        LivesText.ResetLives();
        HealthText.ResetHealth();


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
        
   

    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Projectile missle = collider.gameObject.GetComponent<Projectile>();
    //    if (missle.tag !="Friendly")
    //    {
    //        HealthText.health -= missle.GetDamage();
    //        missle.Hit();
    //        if (HealthText.health <= 0)
    //        {
    //            if(LivesText.lives > 0)
    //            {
    //                Respawn();
    //            }
    //            else
    //            {
    //                Die();
    //            }
                
                 
    //        }
    //    }

    //}

    void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        levelManager.LoadLevel("Win");
    }

    void Respawn()
    {
        LivesText.LoseLives();
        HealthText.health = 250f;
        //Destroy(gameObject);
        
    }
}
