using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slideManager : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject sceneBackground;

    public Slider slider;

    void OnEnable() {
        slider.value = slider.maxValue / 2;
    }

    public void slideBackground(int slideWidth)
    {
        sceneBackground.GetComponent<RectTransform>().anchoredPosition = new Vector3(830 - (slider.value * slideWidth) * 1f, 0, 0);
    }

    public void slideForSaturation() {
        eventManager.touchedToSetSaturation(slider.value / 100);
    }

    public void slideForYear() {
        eventManager.touchedToSetYear((int)slider.value);
    }
}
