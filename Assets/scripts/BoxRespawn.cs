using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoxRespawn : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] private GameObject boxPrefab;
    
   // [Tooltip("The lower X limit of spawning boxes”)]
    [SerializeField] private float lowerHorizontalBound;
    //[Tooltip("The upper X limit of spawning boxes”)]
    [SerializeField] private float upperHorizontalBound;
    //[Tooltip("Time between box generation (needs to be higher than the time of fragments destruction)")]
    //[SerializeField] private float boxGeerationCoolDown = 3f;
    [Tooltip("Maximum number of boxes that can be respawned")]
    [SerializeField] public int maxRespawns = 5;

    //check if there is a box in scene
    public bool isBoxInScene { get; set; }

    //counter for the number of boxes created
    private int boxCount = 0;

    void Start()
    {
        //start spawning initial box
        SpawnRandomBox();
        isBoxInScene = true;
        // Set the slider's maximum value to the maximum number of respawns
        healthSlider.maxValue = maxRespawns;
    }

    private void Update()
    {
        //check if there is no box in scene and begin generating a new one if true
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
        //Generate random X position for the box (make sure the box spawner on the correct Y level)
        Vector3 newHorizontalPosition = GenerateRandomPosition();
        
        //Generate a new box at the new position
        SpawnBox(newHorizontalPosition);

        //increment the box counter
        boxCount++;

        
        // Decrement the slider value and update the health bar
        healthSlider.value++;
    }

    public IEnumerator BeginBoxSpawning()
    {
        //wait for the boxGeneration cooldown
        yield return new WaitForSeconds(1f);
        //then start Generating the new box
        SpawnRandomBox();
     
    }
    
    private Vector3 GenerateRandomPosition()
    {
        //Get random X in the scene bounds
        float randomX = Random.Range(lowerHorizontalBound, upperHorizontalBound);
        //generate a new box in the random X, use the Y position of the boxSpawner object
        return new Vector3(randomX, transform.position.y, 0f);
        
    }

    private void SpawnBox(Vector3 spawnLocation)
    {
        GameObject box = Instantiate(boxPrefab, spawnLocation, Quaternion.identity);
        Enemy enemy = box.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.boxRespawn = this;
        }
    }
}
