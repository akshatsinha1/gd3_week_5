using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy, powerup;
    public float spawnRangeX, spawnRangeZ;

    // Start is called before the first frame update
    void Start()
    {
        
        spawn(powerup,2);
        spawn(enemy,5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
