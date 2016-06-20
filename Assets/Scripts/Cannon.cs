using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public enum SpriteRotation
    {
        Up=-90,
        Down=90,
        Right=0,
        Left=180
    }

    public Camera camera;
    public SpriteRotation spriteRotation;
    public Vector2 direction;
    private Vector2 mousePosition;
    private Transform myTransform;
    private GameObject player;
    public GameObject laserPrefab;
    public float speedOfLaser;
    public float firingRate=0.5f;
    private float angle;
    public GameObject cannonExit;
    private float nextFire = 0.0f;

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

        if (Input.GetMouseButton(0)&&Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject beam = Instantiate(laserPrefab, new Vector3(cannonExit.transform.position.x, cannonExit.transform.position.y, cannonExit.transform.position.z), Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = (direction * speedOfLaser);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
}
