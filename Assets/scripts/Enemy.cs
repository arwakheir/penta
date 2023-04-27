using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public int maxRespawns = 3;
    public int health = 100;
    public GameObject deathEffect;
    public GameObject respawnPrefab;
    public float lowerXBound = -8f;
    public float upperXBound = 8;
    public float lowerYBound = -3f;
    public float upperYBound = 3f;

    private int numRespawns = 0;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (numRespawns < maxRespawns) {
            numRespawns++;

            Vector2 randomPos = new Vector2(Random.Range(lowerXBound, upperXBound), Random.Range(lowerYBound, upperYBound));
            Instantiate(respawnPrefab, randomPos, Quaternion.identity);
        } else {
            SceneManager.LoadScene("AngerInfo");
        }
    }

}
