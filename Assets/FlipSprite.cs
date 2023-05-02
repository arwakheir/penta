using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float previousPositionX;

    void Start()
    {
        previousPositionX = transform.position.x;
    }

    void Update()
    {
        float currentPositionX = transform.position.x;

        // Flip sprite if moving left
        if (currentPositionX < previousPositionX)
        {
            spriteRenderer.flipX = true;
        }
        // Unflip sprite if moving right
        else if (currentPositionX > previousPositionX)
        {
            spriteRenderer.flipX = false;
        }

        previousPositionX = currentPositionX;
    }
}

