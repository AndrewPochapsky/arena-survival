using UnityEngine;
using System.Collections;

public class PlayerPrefsReset : MonoBehaviour {

    public bool resetPlayerPrefs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (resetPlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
	}
}
