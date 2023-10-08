using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 100;
    public float SpawnRadius;
    void Start()
    {
        SpawnCubes();
    }

    // Update is called once per frame
    void SpawnCubes()
    {
       for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = Random.insideUnitSphere * SpawnRadius;
            Vector3 spawnPosition = new Vector3(176, 246, 149);
            GameObject cube = Instantiate(cubePrefab, randomPosition+spawnPosition, Quaternion.identity);
        } 
    }
}
