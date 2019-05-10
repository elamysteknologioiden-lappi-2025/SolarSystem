using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pLab_TimeScale : MonoBehaviour
{

    public static float timeScale = 1;
    public Slider slider;

    public void ChangeValue() {
        timeScale = slider.value;

        if (timeScale < 0.1f) {
            timeScale = 0.1f;
        }
    }

    public void TimeScaleDown() {
        timeScale /= 2f;
        if (timeScale < 0.25f) {
            timeScale = 0.25f;
        }
    }


    public void TimeScaleUp() {
        timeScale *= 2f;

        if(timeScale > 4) {
            timeScale = 4;
        }
    }
}
