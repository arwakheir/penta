using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 100;

    public GameObject deathEffect;
    public BoxRespawn boxRespawn;
    public BoxCounter angerSlider;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    private void IncreaseAngerSlider()
    {
        angerSlider.UpdateAnger();
    }

    void Die ()
    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        boxRespawn.isBoxInScene = false;
        Destroy(gameObject);
    }
}