using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {

    public enum SpriteRotation
    {
        Up=-90,
        Down=90,
        Right=0,
        Left=180
    }

    public Camera camera;
    public SpriteRotation spriteRotation;
    private Vector2 direction;
    private Vector2 mousePosition;
    private Transform myTransform;
    private GameObject player;
    public GameObject laserPrefab;
    public float speedOfLaser;
    public float firingRate;
    private float angle;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + (int)spriteRotation;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
        //beam.GetComponent<Rigidbody2D>().velocity = player.transform.forward * speedOfLaser;
        beam.GetComponent<Rigidbody2D>().velocity=(direction * speedOfLaser);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
