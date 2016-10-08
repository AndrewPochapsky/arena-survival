using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Transform main, options;
    private SoundController soundController;
    // Use this for initialization
    void Start () {
        soundController = GameObject.FindObjectOfType<SoundController>();
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
            soundController.SaveVolume();
        }
    }

    public void SetActive(bool _active)
    {
        FadeIn.isActive = _active;
        
    }


}
