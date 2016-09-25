﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour {

    private Dropdown resDropDown;

	// Use this for initialization
	void Start () {
        resDropDown = GetComponent<Dropdown>();
        resDropDown.interactable = true;
        SetResolution();
	}
	
	// Update is called once per frame
	void Update () {
       

    }

    public void SetResolution()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("width"), PlayerPrefs.GetInt("height"), true);

        resDropDown.value = PlayerPrefs.GetInt("ddv");
    }

    public void ChangeRes()
    {
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
            Screen.SetResolution(1366, 768, true);
        }
        if (resDropDown.value == 3)
        {
            Screen.SetResolution(1280, 1024, true);
        }
        if (resDropDown.value == 4)
        {
            Screen.SetResolution(1280, 800, true);
        }
        if (resDropDown.value == 5)
        {
            Screen.SetResolution(1024, 768, true);
        }
    }

    public void InitiateDisable()//For UI cause it cant use the IEnumerator directly
    {
        StartCoroutine(DisableDropDown());
    }

    public IEnumerator DisableDropDown()
    {
        Debug.Log("DropDown Disabled");
        resDropDown.interactable = false;
        yield return new WaitForSeconds(2);
        resDropDown.interactable= true;
        Debug.Log("DownDown Enabled");

    }

}
