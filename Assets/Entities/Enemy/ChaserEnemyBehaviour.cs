using UnityEngine;
using System.Collections;

public class ChaserEnemyBehaviour : MonoBehaviour
{
    private PlayerController player;
    public float health = 150f;
    public int scoreValue = 150;
    //private ScoreKeeper scoreKeeper;
    public AudioClip deathSound;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    void Update()
    {
        LookAtPlayer();  
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
        //scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void LookAtPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

}
