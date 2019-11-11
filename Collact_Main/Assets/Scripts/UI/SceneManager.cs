
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject blackScreenView;
    public GameObject[] canvases;
    private CanvasGroup fadeInCanvas;
    private CanvasGroup fadeOutCanvas;
    public Button[] buttons = new Button[7];

    public GameObject[] background = new GameObject[3];

    public GameObject backgroundTmp;
    private Image backgroundImgTmp;
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

        backgroundImgTmp = backgroundTmp.GetComponent<Image>();


        canvases[0].SetActive(true);

        for (int i = 1; i < 6; i++)
            canvases[i].SetActive(false);
    }

    public void forward()
    {
        canvases[current + 1].SetActive(true);
        fadeInCanvas = canvases[current + 1].GetComponent<CanvasGroup>();
        fadeOutCanvas = canvases[current].GetComponent<CanvasGroup>();
        StartCoroutine(FadeEffect.FadeCanvas(fadeInCanvas, 0f, 1f, 1f));


        canvases[current].SetActive(false);
        current += 1;
        if(current == 1){
            blackScreenView.SetActive(true);
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),0f,1f,1f));
        }
        if(current == 2){
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),1f,0f,1f));
        }

        if(current == 3){
            blackScreenView.SetActive(false);
            backgroundImgTmp.sprite = backgroundImage_scene4[field-1];
        }
        if (current == 4)
        {   
            backgroundImgTmp.sprite = backgroundImage_scene5[field-1];
        }

        if (current >= canvases.Length - 1) {
            StartCoroutine(stay10Seconds());
            backgroundImgTmp.sprite = default;
            backgroundImgTmp.color = Color.HSVToRGB(hue[field - 1], 1, 1);;
        }
    
    }

    IEnumerator stay10Seconds()
    {
        
        yield return new WaitForSeconds(10);
        canvases[current].SetActive(false);
        current = 0;
        canvases[0].SetActive(true);

        ChangeImage(field-1);
        field = 1;
        backgroundImgTmp.sprite = default;
        backgroundImgTmp.color = Color.white; 
        ChangeImage(0);

    }

    public void backward()
    {
        canvases[current].SetActive(false);
        // StartCoroutine(FadeEffect.FadeCanvas(canvas[current], 1f, 0f, 2f));
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

public class FadeEffect : MonoBehaviour {
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
    {
         // keep track of when the fading started, when it should finish, and how long it has been running&lt;/p&gt; &lt;p&gt;&a
         var startTime = Time.time;
         var endTime = Time.time + duration;
         var elapsedTime = 0f;
 
         // set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
         canvas.alpha = startAlpha;
         // loop repeatedly until the previously calculated end time
         while (Time.time <= endTime)
         {
             elapsedTime = Time.time - startTime; // update the elapsed time
             var percentage = 1/(duration/elapsedTime); // calculate how far along the timeline we are
             if (startAlpha > endAlpha) // if we are fading out/down 
             {
                  canvas.alpha = startAlpha - percentage; // calculate the new alpha
             }
             else // if we are fading in/up
             {
                 canvas.alpha = startAlpha + percentage; // calculate the new alpha
             }
 
             yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
        }
        canvas.alpha = endAlpha; // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
    }
}
