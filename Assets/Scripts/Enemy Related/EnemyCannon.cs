using UnityEngine;
using System.Collections;

public class EnemyCannon : MonoBehaviour {
    private Player player;
    private Animator anim;
    Vector3 dir;
    public GameObject enemyLaserPrefab, cannonExit;
    public float speedOfLaser;
    public float firingRate = 0.5f;
    public float nextFire = 0.5f;
    private ShooterEnemyBehaviour shooter;
    public float shootingRange = 5f;
    // Use this for initialization
    void Start () {
        //shooter = GameObject.FindObjectOfType<ShooterEnemyBehaviour>();
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        LookAtPlayer();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            ShootLaser();
        }
    }

    void LookAtPlayer()
    {
        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    void ShootLaser()
    {
        if(ShooterEnemyBehaviour.distance < shootingRange)
        {
            anim.SetTrigger("Shoot");
            GameObject beam = Instantiate(enemyLaserPrefab, new Vector3(cannonExit.transform.position.x, cannonExit.transform.position.y, cannonExit.transform.position.z), Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = (dir * speedOfLaser);
            //AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }

    }

}
