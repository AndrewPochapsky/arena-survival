using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

    private HealthController healthController;
   
    public int amountOfHealing = 2;
    public bool canHeal;
	// Use this for initialization
	void Start () {
        healthController = GameObject.FindObjectOfType<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (healthController.currentHealth + amountOfHealing > healthController.maxHealth)
        {
            canHeal = false;
        }
        else
        {
            canHeal = true;
        }
	}

    

}
