using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour {

    public Text waveText;
    public Text waveInfo;
    private WaveSpawner waveSpawner;
    private int enemyCount;
	// Use this for initialization
	void Start () {
        waveSpawner = GetComponent<WaveSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("ChargerEnemy").Length;
        waveText.text = "Wave " + (WaveSpawner.currentWave).ToString();
        if (WaveSpawner.waveCountDown <= 0)
        {
            waveInfo.text = "Remaining Enemies: " + enemyCount.ToString();
        }
        else
        {
            waveInfo.text = "Spawning in: " + Mathf.Round(WaveSpawner.waveCountDown).ToString();
        }
        
       
        
	}
}
