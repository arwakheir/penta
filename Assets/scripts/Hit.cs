using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    
    Vector2 startPos;
     private void Start() {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Hit"))
        {
            Die();
       } 
    }
void Die()
{
    Respawn();
}

void Respawn()
{
    transform.position = startPos;
}
}
