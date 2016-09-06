using UnityEngine;
using System.Collections;

public class DoubleCannon : MonoBehaviour
{
    private Player player;
    private Animator anim;
    
    public GameObject enemyLaserPrefab, cannonExit;
    public float speedOfLaser;
    public float firingRate = 0.5f;
    public float nextFire = 0.5f;
    private ShooterEnemyBehaviour shooter;
    public float shootingRange = 5f;
    // Use this for initialization
    void Start()
    {
        //shooter = GameObject.FindObjectOfType<ShooterEnemyBehaviour>();
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            ShootLaser();
        }
    }


    void ShootLaser()
    {
        if (ShooterEnemyBehaviour.distance < shootingRange)
        {
            
            anim.SetTrigger("ShootV2");
            GameObject beam = Instantiate(enemyLaserPrefab, new Vector3(cannonExit.transform.position.x, cannonExit.transform.position.y, cannonExit.transform.position.z), Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = (CannonRotation.dir * speedOfLaser);
            print("Shoot");
            //AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }

    }

}
