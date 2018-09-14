using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetFPS : MonoBehaviour
{

    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Application.targetFrameRate = 60;    
        
    }
}
