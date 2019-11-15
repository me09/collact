﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Touch_EventHandler();
public delegate void SetField_EventHandler(int field);
public delegate void SetSaturation_EventHandler(float saturation);
public delegate void SetYear_EventHandler(int year);
public delegate void Animate_EventHandler(string trigger);


public class EventManager : MonoBehaviour
{
    public event Touch_EventHandler startEvent;
    public event Touch_EventHandler cancelToCreateEvent;
    public event Touch_EventHandler backToSetFieldEvent;
    public event Touch_EventHandler backToSetSaturationEvent;
    public event SetField_EventHandler fieldEvent;
    public event SetSaturation_EventHandler saturationEvent;
    public event SetYear_EventHandler yearEvent;
    public event Animate_EventHandler animateEvent;

    public void touchedToStart() {
        startEvent();
    }

    public void touchedToCancel() {
        cancelToCreateEvent();
    }

    public void touchedBackToSetField() {
        backToSetFieldEvent();
    }
    
    public void touchedBackToSetSaturation() {
        backToSetSaturationEvent();
    }

    public void touchedToSetField(int field) {
        fieldEvent(field);
    }

    public void touchedToSetSaturation(float saturation) {
        saturationEvent(saturation);
    }

    public void touchedToSetYear(int year) {
        yearEvent(year);
        
    }

    public void animate(string trigger) {
        animateEvent(trigger);
    }
}
