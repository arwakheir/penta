using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterWall : MonoBehaviour
{
    public GameObject wall; // The wall object that will be shattered
    public float shatterForce = 20f; // The force applied to the wall when shattered

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the position of the mouse click
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;

            // Cast a ray to detect the wall
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            // If the ray hits the wall
            if (hit.collider != null && hit.collider.gameObject == wall)
            {
                // Shatter the wall
                Shatter();
            }
        }
    }

    void Shatter()
    {
        // Get all of the wall's child objects
        Transform[] wallPieces = wall.GetComponentsInChildren<Transform>();

        // Apply a force to each child object to shatter it
        foreach (Transform piece in wallPieces)
        {
            if (piece.gameObject != wall)
            {
                Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
                rb.isKinematic = false;
                rb.AddForce(Random.insideUnitCircle * shatterForce, ForceMode2D.Impulse);
            }
        }

        // Disable the collider of the wall object
        wall.GetComponent<Collider2D>().enabled = false;

        // Destroy the wall object after a short delay to give time for the wall pieces to settle
        Destroy(wall, 2f);
    }
}
