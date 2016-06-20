using UnityEngine;
using System.Collections;

public class ChaserEnemyBehaviour : MonoBehaviour
{
    public float health = 150f;
    public int scoreValue = 150;
    //private ScoreKeeper scoreKeeper;
    public AudioClip deathSound;
    void Start()
    {
        //scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    void Update()
    {

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

}
