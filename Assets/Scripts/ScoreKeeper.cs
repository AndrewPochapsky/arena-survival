using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public Text scoreText;
    public static int score;


    void Start()
    {
        scoreText = GetComponent<Text>();
        Reset();
    }

    void Update()
    {

    }

    public void Score(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }


    public static void Reset()
    {
        score = 0;
    }


}
