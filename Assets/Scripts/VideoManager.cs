using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour {

    public Dropdown resDropDown;

	// Use this for initialization
	void Start () {
        SetResolution();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("height", Screen.currentResolution.height);
        PlayerPrefs.SetInt("width", Screen.currentResolution.width);

        PlayerPrefs.SetInt("ddv", resDropDown.value);

        if (resDropDown.value == 0)
        {
            Screen.SetResolution(1920, 1200, true);           
        }
        if (resDropDown.value == 1)
        {
            Screen.SetResolution(1920, 1080, true);           
        }
        if (resDropDown.value == 2)
        {
            Screen.SetResolution(1680, 1050, true);          
        }
        if (resDropDown.value == 3)
        {
            Screen.SetResolution(1600, 1200, true);           
        }
        if (resDropDown.value == 4)
        {
            Screen.SetResolution(1600, 1024, true);
        }
        if (resDropDown.value == 5)
        {
            Screen.SetResolution(1600, 900, true);
        }
        if (resDropDown.value == 6)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resDropDown.value == 7)
        {
            Screen.SetResolution(1280, 1024, true);
        }
        if (resDropDown.value == 8)
        {
            Screen.SetResolution(1280, 960, true);
        }
        if (resDropDown.value == 9)
        {
            Screen.SetResolution(1280, 800, true);
        }
        if (resDropDown.value == 10)
        {
            Screen.SetResolution(1280, 768, true);
        }
        if (resDropDown.value == 11)
        {
            Screen.SetResolution(1280, 720, true);
        }
        if (resDropDown.value == 12)
        {
            Screen.SetResolution(1152, 864, true);
        }
        if (resDropDown.value == 13)
        {
            Screen.SetResolution(1024, 768, true);
        }
        if (resDropDown.value == 14)
        {
            Screen.SetResolution(800, 600, true);
        }
    }

    public void SetResolution()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("width"), PlayerPrefs.GetInt("height"), true);

        resDropDown.value = PlayerPrefs.GetInt("ddv");
    }

}
