
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RealTimeManager : MonoBehaviour
{

    private float saturation;
    private int year;
    public Slider slider;
    public Slider slider2;

    private CreateController CreateScript;
    private GameObject CreatedChar;

    private int current_;


    public void Start()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreateScript = CreatedChar.GetComponent<CreateController>();

        SceneManager scenes_ = GameObject.Find("Scenes").GetComponent<SceneManager>();
        current_ = scenes_.current;
    }


    public void FixedUpdate()
    {
            Debug.Log(saturation);
            Debug.Log(year);
            Debug.Log(current_);
        if(current_== 0)
        {
            slider.value = (float)0.5;
            slider2.value = 4;
            CreateScript.saturation = saturation;
            CreateScript.changeJacketColor();
        }
        if (current_ == 3)
        {
            saturation = (slider.value) / 100;
            CreateScript.saturation = saturation;
            CreateScript.changeJacketColor();
        }
        if (current_ == 4)
        {
            year = (int)slider2.value;
            CreateScript.year = this.year;
            CreateScript.createAcc(year);
        }
    }
}
