using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class gameeventsystem 
{
    

   

    public static event Action onrockettriggerenter;
    public static void rockettriggerenter()
    {
        if(onrockettriggerenter != null)
        {
            onrockettriggerenter();
        }
    }
  
    // Start is called before the first frame update
   
}
