using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
        
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Start ()
    {
        music = GetComponent<AudioSource>();
        Debug.Log("Music Player Awake " + GetInstanceID());
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicated music player destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (music == null)
        {
            music = GetComponent<AudioSource>();
        }
        else {
            music.Stop();
        }
        if (level == 0)
        {
            music.clip = startClip;
           
        }

        if (level == 1)
        {
            music.clip = gameClip;
        }

        if (level == 3)
        {
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();
    }

}
