using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
   {
    public string tagToDestroy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tagToDestroy)
        {
            Destroy(gameObject);
        }
    }
}

