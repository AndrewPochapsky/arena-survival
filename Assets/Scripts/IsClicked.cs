using UnityEngine;
using System.Collections;

public class IsClicked : MonoBehaviour {
    public int timesClicked;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print(timesClicked);
        
	}
    
    public void IncreaseClicks(int _clicks)
    {
        timesClicked += _clicks;
    }
}
