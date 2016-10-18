using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScoreManager : MonoBehaviour {
    //Text for win/lose scenes
    public Text highLoops, highWaves, curLoops, curWaves;
    //Text for mainMenu display
    public Text easyHighLoops, easyHighWaves, normalHighLoops, normalHighWaves, hardHighLoops, hardHighWaves;

    public static int localNormalHighScore = 1;
    public static int localEasyHighScore = 1;
    public static int localHardHighScore = 1;
    // Update is called once per frame
    void Update () {
        
        if (SceneManager.GetActiveScene().name == "Start")
        {
            easyHighLoops.text = "Loops: " + PlayerPrefs.GetInt("EasyHighScoreLoopNum", 0);
            easyHighWaves.text = "Waves: " + PlayerPrefs.GetInt("EasyHighScoreWaveNum", 0);

            normalHighLoops.text = "Loops: " + PlayerPrefs.GetInt("NormalHighScoreLoopNum", 0);
            normalHighWaves.text = "Waves: " + PlayerPrefs.GetInt("NormalHighScoreWaveNum", 0);

            hardHighLoops.text = "Loops: " + PlayerPrefs.GetInt("HardHighScoreLoopNum", 0);
            hardHighWaves.text = "Waves: " + PlayerPrefs.GetInt("HardHighScoreWaveNum", 0);
        }
        
        if(SceneManager.GetActiveScene().name == "Lose")
        {
            curLoops.text = "Times Looped: " + WaveSpawner.timesLooped;
            curWaves.text = "Wave Number: " + WaveSpawner.currentWave;
        }
       

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
        else if (DifficultyManager.difficulty == DifficultyManager.Difficulty.HARD)
        {
            highLoops.text = "Times Looped: " + PlayerPrefs.GetInt("HardHighScoreLoopNum");
            highWaves.text = "Wave Number: " + PlayerPrefs.GetInt("HardHighScoreWaveNum");
        }



    }

    public static void StoreEasyHighScore()
    {
        int oldEasyHighScore = PlayerPrefs.GetInt("easyHighscore", 0);

        if (localEasyHighScore > oldEasyHighScore)
        {

            PlayerPrefs.SetInt("easyHighscore", localEasyHighScore);

            SceneManager.LoadScene("Win");

        }
        else if (localEasyHighScore <= oldEasyHighScore)
        {

            SceneManager.LoadScene("Lose");
        }
    }

    public static void StoreNormalHighScore()
    {

        int oldNormalHighScore = PlayerPrefs.GetInt("normalHighscore", 0);

        if(localNormalHighScore > oldNormalHighScore)
        {
            
            PlayerPrefs.SetInt("normalHighscore", localNormalHighScore);
            
            SceneManager.LoadScene("Win");

        }
        else if (localNormalHighScore < oldNormalHighScore)
        {
            
            SceneManager.LoadScene("Lose");
        }
    }

    public static void StoreHardHighScore()
    {

        int oldHardHighScore = PlayerPrefs.GetInt("hardHighscore", 0);

        if (localHardHighScore > oldHardHighScore)
        {

            PlayerPrefs.SetInt("hardHighscore", localHardHighScore);

            SceneManager.LoadScene("Win");

        }
        else if (localHardHighScore < oldHardHighScore)
        {

            SceneManager.LoadScene("Lose");
        }
    }

    public static void DetermineHighScore()
    {
        int _oldEasyLoops = PlayerPrefs.GetInt("EasyHighScoreLoopNum", 0);
        int _oldEasyWaves = PlayerPrefs.GetInt("EasyHighScoreWaveNum", 0);
        int _oldNormalLoops = PlayerPrefs.GetInt("NormalScoreLoopNum", 0);
        int _oldNormalWaves = PlayerPrefs.GetInt("NormalHighScoreWaveNum", 0);
        int _oldHardLoops = PlayerPrefs.GetInt("HardScoreLoopNum", 0);
        int _oldHardWaves = PlayerPrefs.GetInt("HardHighScoreWaveNum", 0);
        if (DifficultyManager.difficulty == DifficultyManager.Difficulty.EASY)
        {
            if (WaveSpawner.timesLooped > _oldEasyLoops)
            {
                PlayerPrefs.SetInt("EasyHighScoreLoopNum", WaveSpawner.timesLooped);
            }
            if (WaveSpawner.currentWave > _oldEasyWaves && WaveSpawner.timesLooped >= _oldEasyLoops)
            {
                PlayerPrefs.SetInt("EasyHighScoreWaveNum", WaveSpawner.currentWave);
            }
        }
        else if (DifficultyManager.difficulty == DifficultyManager.Difficulty.NORMAL)
        {
            if (WaveSpawner.timesLooped > _oldNormalLoops)
            {
                PlayerPrefs.SetInt("NormalHighScoreLoopNum", WaveSpawner.timesLooped);
            }
            if (WaveSpawner.currentWave > _oldNormalWaves && WaveSpawner.timesLooped >= _oldNormalLoops)
            {
                PlayerPrefs.SetInt("NormalHighScoreWaveNum", WaveSpawner.currentWave);
            }
        }
        else if (DifficultyManager.difficulty == DifficultyManager.Difficulty.HARD)
        {
            if (WaveSpawner.timesLooped > _oldHardLoops)
            {
                PlayerPrefs.SetInt("HardHighScoreLoopNum", WaveSpawner.timesLooped);
            }
            if (WaveSpawner.currentWave > _oldHardWaves && WaveSpawner.timesLooped >= _oldHardLoops)
            {
                PlayerPrefs.SetInt("HardHighScoreWaveNum", WaveSpawner.currentWave);
            }
        }
    }

}
