using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour {

    public Dropdown resDropDown;

    // Use this for initialization
    void Start() {

        //SetResolution();
        if (resDropDown != null)
        {
            resDropDown.interactable = true;
            resDropDown.value = PlayerPrefs.GetInt("ddv", 1);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
       

    }

    public void SetResolution()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("width", 1920), PlayerPrefs.GetInt("height", 1080), true);
        if(resDropDown != null)
        {
            resDropDown.value = PlayerPrefs.GetInt("ddv", 1);
        }
        
    }

    public void ChangeRes()
    {
        

       

        if (resDropDown.value == 0)
        {
            Screen.SetResolution(1920, 1200, true);
            PlayerPrefs.SetInt("height", 1200);
            PlayerPrefs.SetInt("width", 1920);
            PlayerPrefs.SetInt("ddv", 0);
        }
        if (resDropDown.value == 1)
        {
            Screen.SetResolution(1920, 1080, true);
            PlayerPrefs.SetInt("height", 1080);
            PlayerPrefs.SetInt("width", 1920);
            PlayerPrefs.SetInt("ddv", 1);
        }
        if (resDropDown.value == 2)
        {
            Screen.SetResolution(1366, 768, true);
            PlayerPrefs.SetInt("height",768);
            PlayerPrefs.SetInt("width", 1366);
            PlayerPrefs.SetInt("ddv", 2);
        }
        if (resDropDown.value == 3)
        {
            Screen.SetResolution(1280, 1024, true);
            PlayerPrefs.SetInt("height", 1024);
            PlayerPrefs.SetInt("width", 1280);
            PlayerPrefs.SetInt("ddv", 3);
        }
        if (resDropDown.value == 4)
        {
            Screen.SetResolution(1280, 800, true);
            PlayerPrefs.SetInt("height", 800);
            PlayerPrefs.SetInt("width", 1280);
            PlayerPrefs.SetInt("ddv", 4);
        }
        if (resDropDown.value == 5)
        {
            Screen.SetResolution(1024, 768, true);
            PlayerPrefs.SetInt("height", 768);
            PlayerPrefs.SetInt("width", 1024);
            PlayerPrefs.SetInt("ddv", 5);
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
