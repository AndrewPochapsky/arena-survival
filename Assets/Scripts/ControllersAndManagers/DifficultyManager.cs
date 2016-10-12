using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

    public enum Difficulty { EASY, NORMAL};

    public static Difficulty difficulty;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print("Current Difficulty: " + difficulty);
	}

    public void SetDifficultyToEasy()
    {
        difficulty = Difficulty.EASY;
    }

    public void SetDifficultyToNormal()
    {
        difficulty = Difficulty.NORMAL;
    }


}
