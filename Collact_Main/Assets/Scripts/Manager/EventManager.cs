using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public delegate void Touch_EventHandler();


public class EventManager : MonoBehaviour
{
    public event Touch_EventHandler startEvent;
    public void touchedToStart() {
        Debug.Log("start To Create");
        startEvent();
    }
}
