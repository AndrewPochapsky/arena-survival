using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

   
    public float amountOfHealing = 2;
    public bool canHeal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (HealthController.currentHealth + amountOfHealing > HealthController.maxHealth)
        {
            canHeal = false;
        }
        else
        {
            canHeal = true;
        }
	}

    

}
