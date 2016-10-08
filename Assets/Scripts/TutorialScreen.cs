using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TutorialScreen : MonoBehaviour {
    public static bool done = false;
    private PauseGame pauseGame;
    private int ppv;
    public Toggle toggle;
    public static bool wantTutorial;
	// Use this for initialization
	void Start () {
        
        ppv = PlayerPrefs.GetInt("wantTutorial", 1);
        if(ppv==1)
        {
            wantTutorial = true;
        }
        else if (ppv == 0)
        {
            wantTutorial = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (wantTutorial && PauseGame.readyToPause)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!wantTutorial)
        {
            done = true;
            gameObject.SetActive(false);
            
        }   
    }

    public void StartGame()
    {
        Player.canMove = true;
        PauseGame.readyToPause = false;
        done = true;
        gameObject.SetActive(false);
        Time.timeScale = 1;
        print("no");
        //pauseGame.menuScreen.gameObject.SetActive(false);

    }

    public void SetWTValue()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("wantTutorial", 1);
            print("changing value");
        }
        else
        {
            PlayerPrefs.SetInt("wantTutorial", 0);
            print("changing value");
        }
        
    }



}
