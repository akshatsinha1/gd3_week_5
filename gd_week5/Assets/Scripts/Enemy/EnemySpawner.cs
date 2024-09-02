using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy,boss, powerup;
    public float spawnRangeX, spawnRangeZ;
    public int waveNumber = 3;
    int enemyCount, bossCount = 1;

    public TMP_Text waveText;

    // Start is called before the first frame update
    void Start()
    {

        spawn(enemy,waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<EnemyScript>().Length;
        
        if(enemyCount == 0)
        {
            spawn(enemy, waveNumber);

            int powerUpProbability = Random.Range(0, 3);
            if(powerUpProbability % 2 == 0) spawn(powerup, 1);

            waveNumber++;
            
            if(waveNumber % 5 == 0)
            {
                spawn(boss, bossCount);
                bossCount++;
            }
        }

        waveText.text = "Wave : " + (waveNumber - 2).ToString();

    }

    void spawn(GameObject spawnObject, int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(spawnObject, generateRandomPosition(), spawnObject.transform.rotation);
        }
    }


    Vector3 generateRandomPosition()
    {
        float spawnXPos = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnZPos = Random.Range(-spawnRangeZ, spawnRangeZ);

        return new Vector3(spawnXPos, 0, spawnZPos);
    }
}
