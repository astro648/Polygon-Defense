using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;

    public Text waveCountdownText;

    private int waveIndex = 1;

    void Update(){
        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; // deltaTime is amount of time passed from the last frame drawn

        waveCountdownText.text = Mathf.Round(countdown).ToString(); // set countdown time to 5.5 instead of 5 to not have "jumping" between 5 and 4
    }

    IEnumerator SpawnWave(){ // turns this piece of code into a coroutine

        for(int i=0; i<waveIndex; i++){
            SpawnEnemy();
            Debug.Log("SpawnEnemy() invoked");
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
