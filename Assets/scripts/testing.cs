using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public GameObject objectPrefab;
    public float throwForce = 500f;
    public Transform wall;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            Vector2 direction = wall.position - obj.transform.position;
            rb.AddForce(direction.normalized * throwForce);
        }
    }
}
