using UnityEngine;
using System.Collections;

public class EnemyLocator : MonoBehaviour {

    private Transform lastEnemy;
    private SpriteRenderer sp;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && WaveSpawner.waveStarted)
        {
            lastEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
            FindEnemy();
        }
        else
        {
            sp.enabled = false;
        }
	}



    void FindEnemy()
    {
        sp.enabled = true;
        Vector3 dir = lastEnemy.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
           



