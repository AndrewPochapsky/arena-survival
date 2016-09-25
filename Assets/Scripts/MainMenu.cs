using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Transform main, options;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Options()
    {
        if (!options.gameObject.activeInHierarchy)
        {
            options.gameObject.SetActive(true);
            main.gameObject.SetActive(false);
        }
        else
        {
            options.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
        }
    }


}
