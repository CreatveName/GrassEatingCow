using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float FillSpeed;
    private float targetProgress;
    public int sliderMax; //changes in player ability script which already has access to CharStats scriptable object

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.maxValue = sliderMax;
        FillSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
            slider.value += FillSpeed * Time.deltaTime;
    }
    // Adds Progress to the bar
    public void IncrementProgress(int newProgress)
    {
        slider.value = newProgress;
    }
}
