﻿using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    //allows me to change values of instances of this class in unity inspector
    [System.Serializable]
	public class Wave
    {
        //Only 100% requirements are enemy,count,spawnRate
        public string name;
        public Transform enemy1;
        public Transform enemy2;
        public Transform enemy3;
        public Transform boss;
        public int count;
        public float spawnRate;
    }
    public Transform[] spawnPoints;
    public Transform[] bossSpawnPoints;
    public Wave[] waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    private Player player;
    private float searchCountDown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        waveCountDown = timeBetweenWaves;
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No SpawnPoints Referenced");
        }
    }
    
    void Update()
    {
        Debug.Log("Skillpoints: " + Player.skillPoints);
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //begin new round
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    } 

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            if(_wave.enemy1 != null)
            {
                SpawnEnemy(_wave.enemy1);
            } 
            if(_wave.enemy2 != null)
            {
                SpawnEnemy(_wave.enemy2);
            }
            if (_wave.enemy3 != null)
            {
                SpawnEnemy(_wave.enemy3);
            }
            if (_wave.boss != null)
            {
                SpawnBoss(_wave.boss);
            }
           
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
       
        Debug.Log("Spawning enemy " + _enemy.name);
       
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
       
    }

    void SpawnBoss(Transform _boss)
    {
        Debug.Log("Spawning boss " + _boss.name);

        Transform _bsp = bossSpawnPoints[Random.Range(0, bossSpawnPoints.Length)];
        Instantiate(_boss, _bsp.position, _bsp.rotation);
    }

    bool EnemyIsAlive()
    {
        //searchCountDown is there so the program isnt counting enemies each frame, too taxing on hardware
        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }          
        }
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed!");   
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        if(nextWave % 2 != 0)
        {
            Player.skillPoints++;
        }
        
        Debug.Log("Skillpoints: " + Player.skillPoints);
        if(nextWave + 1> waves.Length-1)
        {
            Debug.Log("Completed all waves! Looping...");
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }
}
