using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    private Animator anim;

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
    public GameObject laserPrefab;
    
    private float angle;
    public GameObject cannonExit;
    private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player");
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveCannon();

        if (Input.GetMouseButton(0)&&Time.time > nextFire)
        {
            nextFire = Time.time + Player.firingRate;
            Shoot();
        }
    }

    void Shoot()
    {
        anim.SetTrigger("Shoot");
        GameObject beam = Instantiate(laserPrefab, new Vector3(cannonExit.transform.position.x, cannonExit.transform.position.y, cannonExit.transform.position.z), Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = (direction * Player.speedOfLaser);
        //AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void MoveCannon()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + (int)spriteRotation;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
