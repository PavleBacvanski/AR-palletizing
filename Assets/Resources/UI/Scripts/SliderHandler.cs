using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public static int boxHeightLevel = 0;
    public void setBoxHeightLevel()
    {
        boxHeightLevel =  (int)this.GetComponent<Slider>().value;
        Debug.Log(boxHeightLevel);
    }
    private void Start()
    {
        this.GetComponent<Slider>().value = boxHeightLevel;
    }
}
