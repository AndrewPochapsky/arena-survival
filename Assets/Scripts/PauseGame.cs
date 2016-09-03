using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public Transform menuScreen;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}   

    public void Pause()
    {
        if (!menuScreen.gameObject.activeInHierarchy)
        {
            menuScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
