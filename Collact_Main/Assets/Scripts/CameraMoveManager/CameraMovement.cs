using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    private float x;
    private float y;
    private float z;
    private Camera cam;
    private Vector3 transformvalue;
    private Vector3 extransformvalue;
    private int current_num;
    public float speed = 2f;
   
    private void call_scenes_current()
    {
        SceneManager scenes_ = GameObject.Find("Scenes").GetComponent<SceneManager>();
        current_num = scenes_.current;
    }
    IEnumerator stay10Seconds()
    {
        yield return new WaitForSeconds(10);
    }
    private void FixedUpdate()
    {   
        call_scenes_current();
        if(current_num==1)
        {
            Camera.main.transform.position = new Vector3((float)4.77,(float)0.81,(float)6.13);
        }
        if(current_num==2)
        {
            x = (float)1.368;
            y = (float)0.901;
            z = (float)26.55;
            transformvalue = new Vector3(x,y,z);
            Camera.main.transform.position = new Vector3(x,y,z);
        }
        if(current_num==3)
        {  
            extransformvalue = new Vector3(x,(float)0.80,(float)27.15);
            transform.position = Vector3.MoveTowards(transform.position,extransformvalue,Time.deltaTime*speed);
        }
        if(current_num ==5)
        { 
            stay10Seconds();
        }
        if(current_num == 0)
        {
            if(extransformvalue!= transformvalue)
            {
                extransformvalue = new Vector3((float)4.77,(float)1.11,(float)6.13);
                transform.position = Vector3.MoveTowards(transform.position,extransformvalue,Time.deltaTime*(float)1.5*speed);
            }
        }
    }
}
