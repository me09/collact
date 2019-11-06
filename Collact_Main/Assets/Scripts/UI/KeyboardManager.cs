
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class KeyboardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField pname;  
     public string player_name;

     public InputField intputfield;

      public void input_name()
    {
        player_name = pname.text;
        Debug.Log(player_name);
    }
}
