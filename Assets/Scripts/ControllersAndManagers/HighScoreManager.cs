using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScoreManager : MonoBehaviour {

    public Text highLoops, highWaves, curLoops, curWaves;

    public static int localNormalHighScore = 0;
    public static int localEasyHighScore = 0;

    // Update is called once per frame
    void Update () {
        if (DifficultyManager.difficulty == DifficultyManager.Difficulty.EASY)
        {
            highLoops.text = "Times Looped: " + PlayerPrefs.GetInt("EasyHighScoreLoopNum");
            highWaves.text = "Wave Number: " + PlayerPrefs.GetInt("EasyHighScoreWaveNum");            
        }
        else if (DifficultyManager.difficulty == DifficultyManager.Difficulty.NORMAL)
        {
            highLoops.text = "Times Looped: " + PlayerPrefs.GetInt("NormalHighScoreLoopNum");
            highWaves.text = "Wave Number: " + PlayerPrefs.GetInt("NormalHighScoreWaveNum");
        }
        curLoops.text = "Times Looped: " + WaveSpawner.timesLooped;
        curWaves.text = "Wave Number: " + WaveSpawner.currentWave;

    }

    public static void StoreEasyHighScore()
    {
        int oldEasyHighScore = PlayerPrefs.GetInt("easyHighscore", 0);

        if (localEasyHighScore > oldEasyHighScore)
        {

            PlayerPrefs.SetInt("easyHighscore", localEasyHighScore);

            SceneManager.LoadScene("Win");

        }
        else
        {

            SceneManager.LoadScene("Lose");
        }
    }

    public static void StoreNormalHighScore()
    {
        int oldNormalHighScore = PlayerPrefs.GetInt("normalHighscore", 0);

        if(localNormalHighScore> oldNormalHighScore)
        {
            
            PlayerPrefs.SetInt("normalHighscore", localNormalHighScore);
            
            SceneManager.LoadScene("Win");

        }
        else
        {
            
            SceneManager.LoadScene("Lose");
        }
    }

}
