using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

    public enum Difficulty { EASY, NORMAL, HARD};

    public static Difficulty difficulty;
    public static int currentDifficulty;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print("Current Difficulty: " + difficulty);
        if (difficulty == Difficulty.EASY)
        {
            currentDifficulty = 0;
        }
        else if (difficulty == Difficulty.NORMAL)
        {
            currentDifficulty = 1;
        }
	}

    public void SetDifficultyToEasy()
    {
        difficulty = Difficulty.EASY;
    }

    public void SetDifficultyToNormal()
    {
        difficulty = Difficulty.NORMAL;
    }
    public void SetDifficultyToHard()
    {
        difficulty = Difficulty.HARD;
    }


}
