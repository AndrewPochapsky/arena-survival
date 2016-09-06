using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour {

    public static Vector3 dir;
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        LookAtPlayer();
	}

    void LookAtPlayer()
    {
        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

}
