using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowandShatter : MonoBehaviour
{
    public GameObject objectToThrow; // The object that the player can throw
    public GameObject shatteredObject; // The shattered version of the object
    public float throwForce = 10f; // The force applied to the thrown object

    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main; // Get the reference to the main camera
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        // Create a new instance of the object to throw
        GameObject obj = Instantiate(objectToThrow, transform.position, Quaternion.identity);

        // Get the direction in which to throw the object
        Vector3 throwDirection = mainCamera.transform.forward;

        // Add force to the object in the direction of the throw
        obj.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the thrown object collides with another object
        if (collision.gameObject.tag == "Shatter")
        {
            // Replace the thrown object with the shattered version
            GameObject shattered = Instantiate(shatteredObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
