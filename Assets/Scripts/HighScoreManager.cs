﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScoreManager : MonoBehaviour {

    public Text highLoops, highWaves, curLoops, curWaves;

    public static int localHighScore = 0;
    public static bool newHighScore = false;
	// Use this for initialization
	void Start () {
        int resetValue = 0;
        //PlayerPrefs.SetInt("highscore", resetValue);
       
	}
	
	// Update is called once per frame
	void Update () {
        print("Highscore: "+ PlayerPrefs.GetInt("highscore"));
        print("Local highscore: " + localHighScore);
        highLoops.text = "Times Looped: " + PlayerPrefs.GetInt("HighScoreLoopNum");
        highWaves.text = "Wave Number: " + PlayerPrefs.GetInt("HighScoreWaveNum");

        curLoops.text = "Times Looped: " + WaveSpawner.timesLooped;
        curWaves.text = "Wave Number: " + WaveSpawner.currentWave;
	}

    public static void StoreHighScore()
    {
        int oldHighScore = PlayerPrefs.GetInt("highscore", 0);

        if(localHighScore> oldHighScore)
        {
            
            PlayerPrefs.SetInt("highscore", localHighScore);
            newHighScore = true;
            SceneManager.LoadScene("Win");

        }
        else
        {
            newHighScore = false;
            SceneManager.LoadScene("Lose");
        }
    }

}
