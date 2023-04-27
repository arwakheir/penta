using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxRespawn : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    
    [Tooltip("The lower X limit of spawning walls")]
    [SerializeField] private float lowerHorizontalBound;
    [Tooltip("The upper X limit of spawning walls")]
    [SerializeField] private float upperHorizontalBound;
   // [Tooltip("Time between wall generation (needs to be higher than the time of fragments destruction)")]
    //[SerializeField] private float boxGenerationCoolDown = 3f;
    [Tooltip("Maximum number of walls that can be respawned")]
    [SerializeField] private int maxRespawns = 5;

    //check if there is a wall in scene
    public bool isBoxInScene { get; set; }

    //counter for the number of walls created
    private int boxCount = 0;

    void Start()
    {
        //start spawning initial wall
        SpawnRandomBox();
        isBoxInScene = true;
    }

    private void Update()
    {
        //check if there is no wall in scene and begin generating a new one if true
        if (isBoxInScene is false)
        {
            //check if maximum number of respawns has been reached
            if (boxCount >= maxRespawns)
            {
                //move to next scene
                SceneManager.LoadScene("AngerInfo");
            }
            else
            {
                isBoxInScene = true;
                StartCoroutine(BeginBoxSpawning());
            }
        }
    }

    private void SpawnRandomBox()
    {
        //Generate random X position for the wall (make sure the wall spawner on the correct Y level)
        Vector3 newHorizontalPosition = GenerateRandomPosition();
        
        //Generate a new wall at the new position
        SpawnBox(newHorizontalPosition);

        //increment the wall counter
        boxCount++;
    }

    public IEnumerator BeginBoxSpawning()
    {
        //wait for the wallGeneration cooldown
        yield return new WaitForSeconds(0.02f);
        //then start Generating the new wall
        SpawnRandomBox();
     
    }
    
    private Vector3 GenerateRandomPosition()
    {
        //Get random X in the scene bounds
        float randomX = Random.Range(lowerHorizontalBound, upperHorizontalBound);
        //generate a new wall in the random X, use the Y position of the wallSpawner object
        return new Vector3(randomX, transform.position.y, 0f);
        
    }

    private void SpawnBox(Vector3 spawnLocation)
    {
        Instantiate(boxPrefab, spawnLocation, Quaternion.identity);
        
    }
}
