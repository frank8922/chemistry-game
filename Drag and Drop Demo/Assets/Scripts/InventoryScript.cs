using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class InventoryScript : MonoBehaviour, IHasChanged {
	[SerializeField] Transform DropPanel,DragPanel;

	
	[SerializeField] Text inventoryText;

	[SerializeField] string[] questions;

	// Use this for initialization
	void Start () {
		//TODO: RANDOMIZE THE ORDER OF PANELS FOR THE DROPPANEL AND POSSIBLY DRAG PANEL
/* 		Debug.Log(slots.GetChild(0).name);	
		Debug.Log(slots.GetChild(1).name);
		Debug.Log(slots.GetChild(2).name);
		Debug.Log(slots.GetChild(3).name);
		Debug.Log(slots.GetChild(4).name); */

/* 		int randomNumber = UnityEngine.Random.Range(0,questions.Length);
//		inventoryText.text = questions[randomNumber];

		Debug.Log("The amount of children in the drop panel is " + DropPanel.childCount);


		if(inventoryText.text.ToString() == "+1 Elements go above."){
		for(int i = 0; i < DropPanel.childCount;i++){
			DropPanel.GetChild(i).name = "+1";
		}
		}else if(inventoryText.text.ToString() == "+2 Elements go above."){
		for(int i = 0; i < DropPanel.childCount;i++){
			DropPanel.GetChild(i).name = "+2";
		}
		} */


	}
	void Update(){
		
	}

	#region IHasChanged implementation
	public void HasChanged ()
	{
		//Debug.Log("HasChanged");

/* 		if(DragPanel.GetChild(0).childCount == 0 && DragPanel.GetChild(1).childCount == 0 && DragPanel.GetChild(2).childCount == 0 && DragPanel.GetChild(3).childCount == 0 && DragPanel.GetChild(4).childCount == 0){
			Debug.Log("It is empty");
			if(slots.GetChild(0).name.ToLower() == slots.GetChild(0).GetChild(0).name.ToLower()){
				Debug.Log("Correct");
			}else{
				Debug.Log("Wrong");
			}
			if(slots.GetChild(1).name.ToLower() == slots.GetChild(1).GetChild(0).name.ToLower()){
				Debug.Log("Correct");
			}else{
				Debug.Log("Wrong");
			}
			if(slots.GetChild(2).name.ToLower() == slots.GetChild(2).GetChild(0).name.ToLower()){
				Debug.Log("Correct");
			}else{
				Debug.Log("Wrong");
			}
			if(slots.GetChild(3).name.ToLower() == slots.GetChild(3).GetChild(0).name.ToLower()){
				Debug.Log("Correct");
			}else{
				Debug.Log("Wrong");
			}
			if(slots.GetChild(4).name.ToLower() == slots.GetChild(4).GetChild(0).name.ToLower()){
				Debug.Log("Correct");
			}else{
				Debug.Log("Wrong");
			}
			
		} */
		
		
/* 		System.Text.StringBuilder builder = new System.Text.StringBuilder();
		builder.Append (" - ");
		foreach (Transform slotTransform in slots){
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item){
				builder.Append (item.name);
				builder.Append (" - ");
			}
			
		}
		inventoryText.text = builder.ToString (); */

	}
	#endregion
}

	

/* 
namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged();
	}
} */