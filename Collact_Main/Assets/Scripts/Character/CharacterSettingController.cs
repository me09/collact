using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettingController : MonoBehaviour
{
    public GameObject body;
    public GameObject clothJacket;
    public GameObject clothShadow;
    public GameObject[] item = new GameObject[10];
    public GameObject[] head = new GameObject[7];

    private float hue = 0, fixedSaturation = 1, flexibleSaturation = 0, value = 1;
    private Color mainColor;

    private int currentField = 1, currentSaturation, currentYear = 1;

    public void setCharacterAttribute(int field ,float saturation, int year) {
        setInitState();
        body.SetActive(true);
        
        setField(field);

        setSaturation(saturation);

        setAcc(year);
    }

    public void setInitState() {
        body.SetActive(false);

        foreach (GameObject eachHead in head) {
            eachHead.SetActive(false);
        }
        foreach (GameObject eachAcc in item) {
            eachAcc.SetActive(false);
        }

        clothJacket.GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, 0.5f, value);
    }

    public void setField(int field) {
        head[currentField - 1].SetActive(false);
        currentField = field;

        switch (currentField)
        {
            case 1 :
                hue = 352f / 360f;
                break;

            case 2 :
                hue = 26f / 360f;
                break;

            case 3 :
                hue = 50f / 360f;
                break;

            case 4 :
                hue = 97f / 360f;
                value = 0.902f;
                break;

            case 5 :
                hue = 188f / 360f;
                value = 0.902f;
                break;

            case 6 :
                hue = 224f / 360f;
                break;

            case 7 :
                hue = 265f / 360f;
                break;  

            default:
                hue = 352f / 360f;
                break;
        }

        mainColor =  Color.HSVToRGB(hue, fixedSaturation, value);
        head[currentField - 1].SetActive(true);
        head[currentField - 1].GetComponent<Renderer>().material.color = mainColor;

        clothShadow.GetComponent<Renderer>().material.color = mainColor;
    }

    public void setSaturation(float saturation) {
        appearBody();
        flexibleSaturation = saturation;
        clothJacket.GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, flexibleSaturation, value);
    }

    public void setAcc(int year) {
        item[currentYear - 1].SetActive(false);

        currentYear = year;

        item[currentYear - 1].SetActive(true);
        item[currentYear - 1].GetComponent<Renderer>().material.color = mainColor;
    }

    private void appearBody() {
        body.SetActive(true);
    }
}
