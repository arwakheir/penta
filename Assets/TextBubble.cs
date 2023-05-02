using UnityEngine;

public class TextBubble : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float appearTime = 2.0f;
    public float disappearTime = 2.0f;

    private float currentTimer = 0.0f;
    private bool isVisible = false;

    void Start()
    {
        // Make sure sprite is not visible at start
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        currentTimer += Time.deltaTime;

        // If sprite is not visible and enough time has passed, make it visible
        if (!isVisible && currentTimer >= appearTime)
        {
            spriteRenderer.enabled = true;
            isVisible = true;
            currentTimer = 0.0f;
        }

        // If sprite is visible and enough time has passed, make it invisible
        if (isVisible && currentTimer >= disappearTime)
        {
            spriteRenderer.enabled = false;
            isVisible = false;
            currentTimer = 0.0f;
        }
    }
}