
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float[] hue = {352f / 360f, 26f / 360f, 50f / 360f, 97f / 360f, 188f / 360f, 224f / 360f, 265f / 360f};
    private int field = 1;


    private Image scene4Image, scene5Image, scene6Image;


    void Awake()
    {
        buttons[0].image.sprite = onButton[0];

        scene4Image = background[0].GetComponent<Image>();
        scene5Image = background[1].GetComponent<Image>();
        scene6Image = background[2].GetComponent<Image>();

        canvases[0].SetActive(true);

        for (int i = 1; i < 6; i++)
            canvases[i].SetActive(false);
    }

    public void forward()
    {
        canvases[current + 1].SetActive(true);
        canvases[current].SetActive(false);
        current += 1;

        if (current >= canvases.Length - 1) {
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

        ChangeImage(0);
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

        ChangeImage(btnNum-1);
    }
     public void ChangeImage(int index){
     if (buttons[index].image.sprite == onButton[index])
         buttons[index].image.sprite = offButton[index];
     else {
         buttons[index].image.sprite = onButton[index];
     }
     scene4Image.sprite = backgroundImage_scene4[index];
     scene5Image.sprite = backgroundImage_scene5[index];
     scene6Image.color = Color.HSVToRGB(hue[field - 1], 1, 1);
     }
}
