using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
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
