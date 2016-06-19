using UnityEngine;
using System.Collections;

public class ShootLaser : MonoBehaviour {
    public GameObject laserPrefab;
    public float speedOfLaser;
    public float firingRate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Shoot", 0.000001f, firingRate);

        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject beam = Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speedOfLaser, 0);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
