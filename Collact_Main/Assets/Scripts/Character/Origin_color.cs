using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin_color : MonoBehaviour
{   
     public Color altColor;
     public Renderer rend; 
     private Color hsvColor;
     private float hue = 0, saturation = 1, value = 1;
     public int field;
 
     void Start ()
     {   
         switch (field)
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
                break;
         }
         altColor =  Color.HSVToRGB(hue, saturation, value);


         //Call Example to set all color values to zero.
         //Get the renderer of the object so we can access the color
         
         rend = GetComponent<Renderer>();
         //Set the initial color (0f,0f,0f,0f)
         rend.material.color = altColor;
         }       
 }
