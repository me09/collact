
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
    public GameObject[] nxtButtons;
    public GameObject[] background = new GameObject[3];
    public Image backgroundImgTmp;
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
        fadeInCanvas = canvases[current + 1].GetComponent<CanvasGroup>();
        fadeOutCanvas = canvases[current].GetComponent<CanvasGroup>();
        if (current + 1 == 3 || current + 1 == 4) {
            StartCoroutine(FadeEffect.FadeCanvas(fadeInCanvas, 0f, 1f, (current + 1) % 5 * 1f, nxtButtons[current - 2]));
        } else {
            StartCoroutine(FadeEffect.FadeCanvas(fadeInCanvas, 0f, 1f, (current + 1) % 5 * 1f));
        }


        canvases[current].SetActive(false);
        current += 1;
        if(current == 1) {
            blackScreenView.SetActive(true);
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),0f,1f,1f));
        }
        if(current == 2) {
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),1f,0f,1f));
        }

        if(current == 3) {
            blackScreenView.SetActive(false);
            backgroundImgTmp.sprite = backgroundImage_scene4[field-1];
        }
        if (current == 4) {   
            backgroundImgTmp.sprite = backgroundImage_scene5[field-1];
        }

        if (current >= canvases.Length - 1) {
            StartCoroutine(stay10Seconds());
            backgroundImgTmp.sprite = null;
        }
    }

    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(7);
        canvases[current].SetActive(false);
        current = 0;
        canvases[0].SetActive(true);
        yield return new WaitForSeconds(3);

        setDefaultField();
    }

    IEnumerator staySeconds(int delay) {
        yield return new WaitForSeconds(delay);
    }

    public void backward()
    {
        canvases[current].SetActive(false);
        canvases[current - 1].SetActive(true);
        current -= 1;
        if (current == 0) {
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),1f,0f,1f));
        } else if (current == 1) {
            blackScreenView.SetActive(true);
            StartCoroutine(FadeEffect.FadeCanvas(blackScreenView.GetComponent<CanvasGroup>(),0f,1f,1f));
        } else if (current == 2 || current == 3) {
            nxtButtons[current - 2].SetActive(false);
        }
    }

    public void ChangeImage(int index) {
        setAllButtonOff();

        buttons[index - 1].image.sprite = onButton[index - 1];

        field = index;

        scene4Image.sprite = backgroundImage_scene4[index - 1];
        scene5Image.sprite = backgroundImage_scene5[index - 1];
        scene6Image.color = Color.HSVToRGB(hue[field - 1], 1, 1);
    }

    public void setDefaultField() {
        setAllButtonOff();

        foreach(GameObject nxtButton in nxtButtons) {
            nxtButton.SetActive(false);
        }
        
        ChangeImage(1);
        backgroundImgTmp.sprite = null;
    }

    private void setAllButtonOff() {
        int index = 0;
        foreach(Button fieldButton in buttons) {
            fieldButton.image.sprite = offButton[index];
            index += 1;
        }
    }
}

public class FadeEffect : MonoBehaviour {
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration, GameObject nxtButton = null)
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
            if (startAlpha > endAlpha) { // if we are fading out/down 
                canvas.alpha = startAlpha - percentage; // calculate the new alpha
            } else { // if we are fading in/up
                canvas.alpha = startAlpha + percentage; // calculate the new alpha
            }

            yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
        }
        if (nxtButton != null) {
            nxtButton.SetActive(true);
        }
        canvas.alpha = endAlpha; // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
    }
}
