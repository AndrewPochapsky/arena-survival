using UnityEngine;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

    public static int highScore = 0;
    public static bool newHighScore = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void StoreHighScore(int _highScore)
    {
        int oldHighScore = PlayerPrefs.GetInt("highscore");

        if(_highScore> oldHighScore)
        {
            newHighScore = true;
            PlayerPrefs.SetInt("highscore", _highScore);
        }
        else
        {
            newHighScore = false;
        }
    }

}
