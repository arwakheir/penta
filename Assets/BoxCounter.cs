using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoxCounter : MonoBehaviour
{
    public Slider healthSlider;
    public BoxRespawn boxRespawn;

    void Start()
    {
        // Set the slider's maximum value to the maximum number of respawns
        healthSlider.maxValue = boxRespawn.maxRespawns;
    }

    public void UpdateAnger()
    {
        // Decrement the slider value and update the health bar
        healthSlider.value--;
    }
}

