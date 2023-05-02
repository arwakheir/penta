using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    
    public Slider slider;

    public void SetMaxAnger (int anger)
    {
        slider.maxValue = anger;
        slider.value = anger;
    }
    public void SetAnger(int anger)
    {
        slider.value = anger;
    }
}
