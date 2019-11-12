using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{

    public InputField TextField;
    public InputField subTextField;
    public GameObject EngLayoutSml;

    void OnEnable() {
        TextField.text = "";
        subTextField.text = "";
    }


    public void alphabetFunction(string alphabet)
    {


        TextField.text=TextField.text + alphabet;
        subTextField.text =TextField.text;

    }

    public void BackSpace()
    {

        if(TextField.text.Length>0) {
            TextField.text= TextField.text.Remove(TextField.text.Length-1);
            subTextField.text =TextField.text;
        }
        
        

    }

    public void CloseAllLayouts()
    {

     
        EngLayoutSml.SetActive(false);


    }

    public void ShowLayout(GameObject SetLayout)
    {

        CloseAllLayouts();
        SetLayout.SetActive(true);

    }

}
