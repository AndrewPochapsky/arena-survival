using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public Transform menuScreen, pauseMenu, controlsMenu, toggle, tutorialScreen;
    public static bool readyToPause = false;
    //void Awake()
    //{
    //    Time.timeScale = 0;
    //}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (readyToPause)
        {
            Time.timeScale = 0;
        }
        else if (!readyToPause)
        {
            Time.timeScale = 1;
        }
	}   

    public void Pause()
    {
        if (!menuScreen.gameObject.activeInHierarchy)
        {
            menuScreen.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            readyToPause = true;
        }
        else
        {
            menuScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            readyToPause = false;
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

    public void StartGame()
    {
        Player.canMove = true;
        readyToPause = false;
        tutorialScreen.gameObject.SetActive(false);
        menuScreen.gameObject.SetActive(false);
        
    }

}
