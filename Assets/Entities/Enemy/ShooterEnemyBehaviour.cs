using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float firingRate = 0.2f;
    public GameObject enemyLaser;
    public float speedOfLaser;
    private Projectile projectile;
    public float health = 150f;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;
    //private ScoreKeeper scoreKeeper;
    public AudioClip fireSound;
    public AudioClip deathSound;
    void Start()
    {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            health -= missle.GetDamage();
            missle.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Update()
    {
        float probability = shotsPerSecond * Time.deltaTime;
        if(Random.value < probability)
        {
            ShootLaser();
        }

       
    }

    void ShootLaser()
    {
        GameObject beam = Instantiate(enemyLaser, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedOfLaser, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Die()
    {
        Destroy(gameObject);
        //scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

}