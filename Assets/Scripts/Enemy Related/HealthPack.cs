using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

    
    public float timeAlive = 8f;
    private float fadeDuration =0.75f;
    private float alpha = 0f;
    private SpriteRenderer renderer;

    private Color color;
    private HealthController healthController;
   
    public int amountOfHealing = 2;
    public bool canHeal;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.color;
        //so healthpacks dont remain for the entire game would be too op
        Destroy(gameObject, timeAlive);
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
        if(Time.time> (timeAlive / 2))
        {
            Fade();
        }
	}

    void Fade()
    {
        float lerp = Mathf.PingPong(Time.time, fadeDuration) / fadeDuration;

        alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
        color.a = alpha;
        renderer.color = color;
    }

}
