using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class detectbuttonpress : MonoBehaviour {

	public GameObject player;

	[SerializeField]
	public Sprite[] spriteArray;

	[SerializeField]
	public Button[] buttonArray;

	void Start () 
	{
		player = gameObject;

		int randomButtonNumber = 0;
		int randomSpriteNumber = 0;

		for(int i = 0; i < buttonArray.Length; i++){
			randomButtonNumber = Random.Range(0,buttonArray.Length);
			randomSpriteNumber = Random.Range(0,spriteArray.Length);
			Image buttonImage = buttonArray[i].GetComponent<Button>().GetComponent<Image>(); 
			buttonImage.sprite = spriteArray[randomSpriteNumber];  
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onClick()
	{
    	if(player != null)
    	{
        	string name = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponent<Image>().sprite.name;
			Debug.Log(name);
    	}
	}
}
