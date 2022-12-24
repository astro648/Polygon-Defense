using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Update(){
        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; // deltaTime is amount of time passed from the last frame drawn
    }

    IEnumerator SpawnWave(){ // turns this piece of code into a coroutine

        for(int i=0; i<waveIndex; i++){
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
