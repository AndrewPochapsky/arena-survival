using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SoundController : MonoBehaviour {
    public Slider musicSlider, sfxSlider;
    private MusicPlayer musicPlayer;
	// Use this for initialization
	void Start () {
        //musicSlider = GetComponent<Slider>();
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1);
	}
	
	// Update is called once per frame
	void Update () {
        musicPlayer.ChangeVolume(musicSlider.value);
	}

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
       
    }
}
