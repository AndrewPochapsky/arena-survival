using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesText : MonoBehaviour {

    public Text livesText;
    
    public static int lives = 3;
  


    void Start()
    {
        livesText = GetComponent<Text>();
        
    }

    void Update()
    {
        livesText.text =  "Remaining Lives: " + lives.ToString();
        

    }

    public static void LoseLives()
    {
        lives--;
       
    }
    public static void ResetLives()
    {
        lives = 3;
    }


    
}
