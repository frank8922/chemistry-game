using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour {

	public GameObject disableScreen;

	public void disableObj(){
		disableScreen.SetActive(false);
	}
}
