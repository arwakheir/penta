using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppear : MonoBehaviour
{
    public float delay = 3f; // The delay in seconds before the TextMeshPro object appears
    public TextMeshProUGUI textObject; // Reference to the TextMeshPro object

    void Start()
    {
        // Set the TextMeshPro object to be invisible initially
        textObject.alpha = 0f;
    }

    void Update()
    {
        // Check if the delay time has passed
        if (Time.time >= delay)
        {
            // Set the alpha of the TextMeshPro object to 1 to make it visible
            textObject.alpha = 1f;
        }
    }
}
