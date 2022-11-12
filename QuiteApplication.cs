using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteApplication : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape)){
        Debug.Log("We pushed escape");
        Application.Quit();
      }
    }

    
}

