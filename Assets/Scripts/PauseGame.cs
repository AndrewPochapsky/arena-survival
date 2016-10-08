using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public Transform menuScreen, pauseMenu, controlsMenu;
    public static bool readyToPause = true;
    private bool hasDoneAlready = false;
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update () {

        if (!hasDoneAlready)
        {
            if (TutorialScreen.done)
            {
                menuScreen.gameObject.SetActive(false);
                readyToPause = false;
                print("Is Done");
                hasDoneAlready = true;
            }
        }
        print("readyToPause: " + readyToPause);

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

  

}
