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
        Projectile missle = col.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            Destroy(col.gameObject);
        }
    }
}


