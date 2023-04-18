using UnityEngine;
using TMPro;

public class ShowTMPAfterDelay : MonoBehaviour
{
    public float delayTime = 2f; // The delay time before the TextMeshPro UI appears
    public float displayTime = 5f; // The amount of time the TextMeshPro UI stays on the screen
    public TextMeshProUGUI textMeshProUI; // Reference to the TextMeshPro UI component

    private float timer = 0f; // Timer to keep track of time
    private bool isShown = false; // Flag to indicate if the TextMeshPro UI has been shown

    private void Start()
    {
        // Hide the TextMeshPro UI initially
        textMeshProUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // If the TextMeshPro UI has not been shown yet
        if (!isShown)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // If the delay time has elapsed, show the TextMeshPro UI
            if (timer >= delayTime)
            {
                textMeshProUI.gameObject.SetActive(true);
                isShown = true;
            }
        }
        // If the TextMeshPro UI has been shown and the display time has elapsed
        else if (timer >= displayTime)
        {
            textMeshProUI.gameObject.SetActive(false);
            isShown = false;
            timer = 0f;
        }
        else
        {
            // Increment the timer
            timer += Time.deltaTime;
        }
    }
}
