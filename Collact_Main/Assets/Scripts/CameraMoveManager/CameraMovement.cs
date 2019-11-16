using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public EventManager eventManager;

    private float x;
    private float y;
    private float z;

    private Vector3 transformvalue;
    private Vector3 extransformvalue;

    private bool isNeedToMove = false;
    public float speed = 2f;

    void OnEnable() {
        eventManager.changeSceneEvent += setCamera;
    }

    void OnDisable() {
        eventManager.changeSceneEvent -= setCamera;
    }

    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(7);
        extransformvalue = new Vector3((float)1.77,(float)1,(float)16.13);
        isNeedToMove = true;
    }

    private void FixedUpdate()
    {   
        if (isNeedToMove) {
            transform.position = Vector3.MoveTowards(transform.position,extransformvalue,Time.deltaTime*speed);
        }
    }

    private void setCamera(int currentScene) {
        if (currentScene == 2) {
            isNeedToMove = false;
            x = (float)1.368;
            y = (float)0.901;
            z = (float)22.55;
            transformvalue = new Vector3(x,y,z);
            Camera.main.transform.position = new Vector3(x,y,z);
        } else if (currentScene == 3 || currentScene == 4) {
            extransformvalue = new Vector3(x,(float)0.65,(float)23.15);
            isNeedToMove = true;
        } else if (currentScene == 5) {
            StartCoroutine(stay10Seconds());
        }
    }
}
