using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectdoublepress : MonoBehaviour {
 void OnGUI()
 {
     if(Event.current.isMouse && Event.current.button == 0 && Event.current.clickCount > 1)
     {
         Debug.Log(Event.current.clickCount);
		 Debug.Log("Double Click");
     }
 }
}
