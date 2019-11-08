
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

    private Text yearText;

    public int current_;


    public void Start()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreateScript = CreatedChar.GetComponent<CreateController>();

        SceneManager scenes_ = GameObject.Find("Scenes").GetComponent<SceneManager>();
        current_ = scenes_.current;
    }


    public void FixedUpdate()
    {
            // Debug.Log(saturation);
            // Debug.Log(year);
            // Debug.Log(current_);
            
        if (current_ == 3)
        {
            saturation = (slider.value) / 100;
            CreateScript.saturation = saturation;
            CreateScript.changeJacketColor();
        }
        if (current_ == 4)
        {
            if(!yearText){
                yearText = GameObject.Find("IdelYear").GetComponent<Text>();
            }
            year = (int)slider2.value;
            yearText.text = (year+1).ToString();
            CreateScript.year = this.year;
            CreateScript.createAcc(year);
        }
    }
}
