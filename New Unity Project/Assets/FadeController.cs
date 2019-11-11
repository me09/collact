using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    public Animator anim;
    public bool faded;

    // Start is called before the first frame update
    void Start()
    {
        anim  = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            faded = false;
        }
        if(Input.GetKeyDown("2"))
        {
            faded = true;
        }  
        if(faded == true)
        {
            anim.Play("meshfade");
        }
        else
        {
            anim.Rebind();
        }
    }
    // public void ff()
    // {
    //     if(faded == true)
    //     {
    //         anim.enabled = false;
    //     }
    // }
}
