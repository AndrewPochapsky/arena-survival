using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        EnemyProjectile enemyMissle = col.gameObject.GetComponent<EnemyProjectile>();
        PlayerProjectile playerMissle = col.gameObject.GetComponent<PlayerProjectile>();
        if (enemyMissle || playerMissle)
        {
            Destroy(col.gameObject);
        }
    }
}


