using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

    public Transform main, options, difficultyScreen;
    private SoundController soundController;
    public Text savedWaves, savedLoops, header;
    // Use this for initialization
    void Start () {
        soundController = GameObject.FindObjectOfType<SoundController>();
	}
	
	// Update is called once per frame
	void Update () {
        DisplaySavedScore();
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
    public void StartGame()
    {
        if (!difficultyScreen.gameObject.activeInHierarchy)
        {
            difficultyScreen.gameObject.SetActive(true);
            main.gameObject.SetActive(false);
        }
        else
        {
            difficultyScreen.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
        }
    }

    private void DisplaySavedScore()
    {
        

        if (PlayerPrefs.GetInt("isInteractable") == 0)
        {
            header.text = "No Current Game";
            savedWaves.gameObject.SetActive(false);
            savedLoops.gameObject.SetActive(false);
        }
        else
        {
            savedWaves.gameObject.SetActive(true);
            savedLoops.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("SavedDifficulty")==0)
            {
                header.text = "Difficulty: EASY" ;
            }
            else if (PlayerPrefs.GetInt("SavedDifficulty") == 1)
            {
                header.text = "Difficulty: NORMAL";
            }

            savedWaves.text = "Wave Number: " + PlayerPrefs.GetInt("SavedWaveNumber", 0);
            savedLoops.text = "Loops: " + PlayerPrefs.GetInt("SavedLoopNumber", 0);
        }

    }



}
