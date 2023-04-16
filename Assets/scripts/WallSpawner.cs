using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    
    public GameObject wallPrefab;

    public Transform[] spawnPositions;

    int spawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWall()
    {
        Instantiate(wallPrefab, spawnPositions[spawnIndex].position, Quaternion.identity);
        spawnIndex++;
    }
}
