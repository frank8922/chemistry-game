using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {
	private Rigidbody2D rb;
	private SpriteRenderer spriteRender;
	private DateTime beginInteraction,endInteraction;
	public static Vector3 originalPosition;

	public static int amountAttempted;

	void Start () 
	{
		//save the gameobjects position so when it dissapears we can spawn a new one
		//originalPosition = new Vector3(gameObject.GetComponent<RectTransform>().localPosition.x,gameObject.GetComponent<RectTransform>().localPosition.y,gameObject.GetComponent<RectTransform>().localPosition.z);
		//originalPosition = new Vector3(gameObject.GetComponent<RectTransform>().position.x,gameObject.GetComponent<RectTransform>().position.y,gameObject.GetComponent<RectTransform>().position.z);

		//Debug.Log("This is " + gameObject.name.ToString() + " position: " + originalPosition.x + "," + originalPosition.y + "," + originalPosition.z);

		spriteRender = GetComponent<SpriteRenderer>();
		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
		//set the rigid body not to rotate
		rb.freezeRotation = true;
		//Set gravity to default 9.8f down on y axis
		Physics2D.gravity = new Vector2(0,0);
		//ignore 2Dphysics on certain layers when they collide
		Physics2D.IgnoreLayerCollision(10,10);
	}
	
	void OnMouseDrag()
	{
		//rb = GetComponent<Rigidbody2D>();
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		// Move by Rigidbody rather than transform directly moves
		// MovePosition allows for the clean effect of dragging instead of teleporting
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
	}

	void onMouseDown(){
		rb.velocity = new Vector2(0,0);
		beginInteraction = DateTime.Now;
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.GetComponent<UnityEngine.UI.Text>().text.ToString() == "Which elements have a +1 charge?"){
			if(gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "lithium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "sodium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "potassium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "rubidium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "cesium"){
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				//play correct noise add point to amount of correct send data to database
				StartCoroutine(FadeOutRight());
				//Instantiate(gameObject,originalPosition, gameObject.transform.rotation);

			}else{
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				//play wrong noise add point to amount of wrong send data to database
				StartCoroutine(FadeOutWrong());
			}

		}else if(other.GetComponent<UnityEngine.UI.Text>().text.ToString() == "Which elements have a +2 charge?"){
			if(gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "beryllium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "magnesium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "calcium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "strontium" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "barium"){
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				//play correct noise add point to amount of correct send data to database
				StartCoroutine(FadeOutRight());
				
			}else{
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				//play wrong noise add point to amount of wrong send data to database
				StartCoroutine(FadeOutWrong());
			}
		}else if(other.GetComponent<UnityEngine.UI.Text>().text.ToString() == "Which elements have a -1 charge?"){
			if(gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "flourine" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "chlorine" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "bromine" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "iodine" ){
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				//play correct noise add point to amount of correct send data to database
				StartCoroutine(FadeOutRight());
			}else{
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				//play wrong noise add point to amount of wrong send data to database
				StartCoroutine(FadeOutWrong());
			}
			
		}else if(other.GetComponent<UnityEngine.UI.Text>().text.ToString() == "Which elements have a -2 charge?"){
			if(gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "oxygen" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "sulfur" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "selenium"){
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				//play correct noise add point to amount of correct send data to database
				StartCoroutine(FadeOutRight());
			}else{
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				//play wrong noise add point to amount of wrong send data to database
				StartCoroutine(FadeOutWrong());
			}
		}else if(other.GetComponent<UnityEngine.UI.Text>().text.ToString() == "Which elements have a -3 charge?"){
			if(gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "nitrogen" || gameObject.GetComponent<SpriteRenderer>().sprite.name.ToLower() == "phosphorous"){
				gameObject.GetComponent<Renderer>().material.color = Color.green;
				//play correct noise add point to amount of correct send data to database
				StartCoroutine(FadeOutRight());
			}else{
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				//play wrong noise add point to amount of wrong send data to database
				StartCoroutine(FadeOutWrong());
			}
		}
		//amountAttempted++;
		//Debug.Log("The user has attempted " + amountAttempted + " times");
	}

		IEnumerator FadeOutRight()
	{
		for(float f = 1f; f>=-0.05f; f -= 0.05f){
			Color c = spriteRender.material.color;
			c.a = f;
			spriteRender.material.color = c;
			yield return new WaitForSeconds(.05f);
		}
		Destroy(gameObject);
		//GameObject obj = new GameObject();
		//Instantiate(gameObject,originalPosition, gameObject.transform.rotation);
		//Debug.Log("Prefab should spawn");

	}

	IEnumerator FadeOutWrong()
	{
		for(float f = 1f; f>=-0.05f; f -= 0.05f){
			Color c = spriteRender.material.color;
			c.a = f;
			spriteRender.material.color = c;
			yield return new WaitForSeconds(.05f);
		}
		Destroy(gameObject);
		//Instantiate(gameObject,originalPosition, gameObject.transform.rotation);
		//Debug.Log("Prefab should spawn");
		
	}
}
