using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRespawn : MonoBehaviour
{
    public GameObject wallPrefab;
    public Vector3 respawnPosition;
    public float respawnTime = 5.0f; // Time in seconds before the wall respawns

    private GameObject currentWall; // Reference to the currently spawned wall

    void Start()
    {
        SpawnWall();
    }

    void SpawnWall()
    {
        // Instantiate the wall at the respawn position
        currentWall = Instantiate(wallPrefab, respawnPosition, Quaternion.identity);
        // Set the wall as a child of the WallDestroyer object
        currentWall.transform.SetParent(transform);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == currentWall)
                {
                    // Call DestroyWall() after respawnTime seconds
                    StartCoroutine(DestroyWall());
                }
            }
        }
    }

    IEnumerator DestroyWall()
    {
        yield return new WaitForSeconds(respawnTime);
        // Destroy the wall game object
        Destroy(currentWall);
    }
}
