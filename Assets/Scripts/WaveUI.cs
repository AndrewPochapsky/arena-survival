using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour {

    public Text timesLooped;
    public Text waveText;
    public Text waveInfo;
    private int enemyCount;
	
	
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
            waveInfo.text = "Enemies spawning in: " + Mathf.Round(WaveSpawner.waveCountDown).ToString();
        }
        timesLooped.text = "Times Looped: " + WaveSpawner.timesLooped;
       
        
	}
}
