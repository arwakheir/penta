using System.Collections;
using UnityEngine;

public class WallRespawn1 : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    
    [Tooltip("The lower X limit of spawning walls")]
    [SerializeField] private float lowerHorizontalBound;
    [Tooltip("The Uppwe X limit of spawning walls")]
    [SerializeField] private float upperHorizontalBound;
    [Tooltip("The right Y limit of spawning walls")]
    [SerializeField] private float upperVerticalBound;
    [Tooltip("Time between wall generation(needs to be higher than the time of fragments destruction")]
    [SerializeField] private float wallGenerationCoolDown = 3f;

    //check if there is a wall in scene
    public bool isWallInScene { get; set; }


    void Start()
    {
        //start spawning initial wall
        SpawnRandomWall();
        isWallInScene = true;
    }

    private void Update()
    {
        //check if there is no wall in scene and begin generating a new one if true
        if (isWallInScene is false)
        {
            isWallInScene = true;
            StartCoroutine(BeginWallSpawning());
        }
    }

    private void SpawnRandomWall()
    {
        //Generate random X position for the wall (make sure the wall spawner on the correct Y level)
        Vector3 newHorizontalPosition = GenerateRandomPosition();
        
        //Generate a new wall at the new position
        SpawnWall(newHorizontalPosition);
        
    }

    public IEnumerator BeginWallSpawning()
    {
        //wait for the wallGeneration cooldown
        yield return new WaitForSeconds(wallGenerationCoolDown);
        //then start Generating the new wall
        SpawnRandomWall();
    }
    
    private Vector3 GenerateRandomPosition()
    {
        //Get random X in the scene bounds
        float randomX = Random.Range(lowerHorizontalBound, upperHorizontalBound);
        //generate a new wall in the random X, use the Y position of the wallSpawner object
        return new Vector3(randomX, transform.position.y, 0f);
    }

    private void SpawnWall(Vector3 spawnLocation)
    {
        Instantiate(wallPrefab, spawnLocation, Quaternion.identity);
    }
    
}
