using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }
    public int damage = 100;


    public int GetDamage()
    {
        return damage;
    }


    public void Hit()
    {
        Destroy(gameObject);
    }
}
