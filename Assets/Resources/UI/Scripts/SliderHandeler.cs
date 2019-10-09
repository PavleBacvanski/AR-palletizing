using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandeler : MonoBehaviour
{

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        this.slider = GameObject.FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSliderValue(int newValue)
    {
        this.slider.value = newValue;
    }
    public void addToSliderValue(int newValue)
    {
        this.slider.value += newValue;
    }

}
