using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectdoublepress : MonoBehaviour {
    private bool hasPressed = false;
 void OnGUI()
 {
     if(hasPressed){
         Debug.Log("game should pause");
         //FindObjectOfType<AudioManager>().Stop("levelselectnoise");
         Time.timeScale = 0;
     }else{
         Time.timeScale = 1;
     }

     if(Event.current.isMouse && Event.current.button == 0 && Event.current.clickCount > 1)
     {
         hasPressed = !hasPressed;
         Debug.Log(Event.current.clickCount);
		 Debug.Log("Double Click");    
     }
 }
}
