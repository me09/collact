﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Display.displays.Length>1)
        {
            Display.displays[1].Activate(834, 1194, 60);
        }
    }
    // void mapCameraToDisplay()
    // {
    //     //Loop over Connected Displays
    //     for (int i = 0; i < Display.displays.Length; i++)
    //     {
    //         MultiDisplay[i].targetDisplay = i; //Set the Display in which to render the camera to
    //         Display.displays[i].Activate(); //Enable the display
    //     }
    // }

}
