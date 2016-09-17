using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class IsInteractable : MonoBehaviour {

    private Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("isInteractable") == 1)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
      
	}
}
