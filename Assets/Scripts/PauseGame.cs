using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public Transform menuScreen, pauseMenu, controlsMenu, videoSettings;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}   

    public void Pause()
    {
        if (!menuScreen.gameObject.activeInHierarchy)
        {
            menuScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Controls()
    {
        if (!controlsMenu.gameObject.activeInHierarchy)
        {
            controlsMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        else
        {
            controlsMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void VideoSettings()
    {
        if (!videoSettings.gameObject.activeInHierarchy)
        {
            videoSettings.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        else
        {
            videoSettings.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

}
