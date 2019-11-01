using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slideManager : MonoBehaviour
{
    public GameObject sceneBackground;

    public Slider slider;

    public void slideBackground(int slideWidth)
    {
        sceneBackground.GetComponent<RectTransform>().anchoredPosition = new Vector3(830 - (slider.value * slideWidth) * 1f, 0, 0);
    }
}
