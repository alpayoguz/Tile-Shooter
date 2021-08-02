using System.Collections;
using System.Collections.Generic;
using UnityEngine;





//Mono behaviour olunca yazılabilir şekilde scripti serialize edemezsin.
public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Wave[] waves;
    Wave currentWave;


    int remaningEnemyToSpawn;
    int aliveEnemyToSpawn;
    int waveNumber;
    float currentWaveTimeBetweenSpawns;
    float nextToSpawn;


    float percent = 0f;
    float attt = 3f;


    private void Start()
    {
        NextSpawn();   
    }



    void NextSpawn()
    {
        if(waveNumber < waves.Length)
        {
            currentWave = waves[waveNumber];
            remaningEnemyToSpawn = currentWave.enemyCount;
            aliveEnemyToSpawn = remaningEnemyToSpawn;
            currentWaveTimeBetweenSpawns = currentWave.timeBetweenSpawns;
        }
       
        waveNumber++;

    }


    void EnemySpawn()
    {

        if(remaningEnemyToSpawn > 0 && Time.time > nextToSpawn)
        {
            nextToSpawn = Time.time + currentWaveTimeBetweenSpawns;
            remaningEnemyToSpawn--;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }

    }

    private void Update()
    {
        EnemySpawn();
        
    }


    void OnEnemyDeath()
    {
        aliveEnemyToSpawn--;
        if(aliveEnemyToSpawn == 0)
        {
            NextSpawn();
        }
    }














}






[System.Serializable]
  class Wave
  {

    public int enemyCount;
    public int timeBetweenSpawns;


  }