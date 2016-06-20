using UnityEngine;
using System.Collections;

public class ChaserEnemyBehaviour : MonoBehaviour
{

    private PlayerController player;
    public float health = 150f;
    public int scoreValue = 150;
    public float speed = 0.01f;

    
    private float minDistance = 1f;
    private float range;
    private ScoreKeeper scoreKeeper;
    public AudioClip deathSound;

    public float damage = 2f;

    public float GetDamage()
    {
        return damage;
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    void Update()
    {
        ChasePlayer();  
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile>();
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

    void Die()
    {
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
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

}
