
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject[] canvases;
    public Button[] buttons = new Button[7];

    public GameObject[] background = new GameObject[3];
    public Sprite[] backgroundImage_scene4 = new Sprite[7];

    public Sprite[] backgroundImage_scene5 = new Sprite[7];

    public Sprite[] offButton = new Sprite[7];
    public Sprite[] onButton = new Sprite[7];

    public int current = 0;

    public InputField pname;

    private float saturation;
    public int year = 0;

    private int field = 1;
    private string player_name;
    private CreatController CreatScript;
    private GameObject CreatedChar;

    private Image scene4Image, scene5Image, scene6Image;


    void Awake()
    {
        CreatedChar = GameObject.FindGameObjectWithTag("createdChar");
        CreatScript = CreatedChar.GetComponent<CreatController>();
        buttons[0].image.sprite = onButton[0];

        scene4Image = background[0].GetComponent<Image>();
        scene5Image = background[1].GetComponent<Image>();
        scene6Image = background[2].GetComponent<Image>();
        year = -1;

        canvases[0].SetActive(true);

        for (int i = 1; i < 6; i++)
            canvases[i].SetActive(false);
    }

    public void forward()
    {
        canvases[current + 1].SetActive(true);
        canvases[current].SetActive(false);
        current += 1;
        if(current == 3){
            CreatScript.creatMotion.SetTrigger("Hello");
        }
        if (current == 4)
        {   
            CreatScript.createAcc(0);
            CreatScript.creatMotion.SetTrigger("Suprise");
        }
        if (current == 5)
        {
            CreatScript.creatMotion.SetTrigger("Dancing");
            StartCoroutine(stay10Seconds());
        }
    }

    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(10);
        canvases[current].SetActive(false);
        current = 0;
        canvases[0].SetActive(true);
        field = 1;
        saturation = (float)0.5;

        ChangeImage(0);
        CreatScript.createAcc(11);
        CreatScript.field = this.field;
        CreatScript.create(field);
        CreatScript.saturation = saturation;
        CreatScript.changeJacketColor();
        
    }

    public void backward()
    {
        canvases[current].SetActive(false);
        canvases[current - 1].SetActive(true);
        current -= 1;
    }

    public void head_color_button(int btnNum)
    {
        if(btnNum != field){
            buttons[field-1].image.sprite = offButton[field-1];
        }
        field = btnNum;
        CreatScript.field = this.field;
        CreatScript.create(field);
        Debug.Log(field);
        ChangeImage(btnNum-1);
    }

    public void input_name()
    {
        player_name = pname.text;
        Debug.Log(player_name);
    }

     public void ChangeImage(int index){
     if (buttons[index].image.sprite == onButton[index])
         buttons[index].image.sprite = offButton[index];
     else {
         buttons[index].image.sprite = onButton[index];
     }
     scene4Image.sprite = backgroundImage_scene4[index];
     scene5Image.sprite = backgroundImage_scene5[index];
     scene6Image.color = CreatScript.altColor;
     
     }
}
