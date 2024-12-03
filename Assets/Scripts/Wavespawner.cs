using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{
    public static int enemysAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float countdown = 2f;

    public Text waveCountdownText;
    public GameManager manager;

    int waveIndex = 0;

    void Update()
    {
        
        if (enemysAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length && enemysAlive == 0)
        {
            manager.WinLevel();
            this.enabled = false;
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        Wave wave = waves[waveIndex];

                   
        for (int j = 0; j < wave.totalCount; j++)
        {
            GameObject enemy = wave.Randomizer();
            SpawnEnemy(enemy);
            enemysAlive++;
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
