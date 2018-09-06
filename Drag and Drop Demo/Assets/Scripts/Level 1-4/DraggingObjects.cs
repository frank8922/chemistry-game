using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
This class represents the falling elements in the game mode. They are comprised of sprites,rigidbodies, and
box colliders. This class also sets certain fields

 */

public class DraggingObjects : MonoBehaviour {
	private Rigidbody2D rb;
	public static float gravity,maxSpeed;
	DateTime beginInteraction,endInteraction;
	SpriteRenderer spriteRender;

	public static String correctAnswers,incorrectAnswers;
	
	
	void FixedUpdate()
	{
		//causes the speed of the falling object to be constant once it hits a maxSpeed
		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}
	}	
	void Start()
	{
		spriteRender = GetComponent<SpriteRenderer>();
		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
		//set the rigid body not to rotate
		rb.freezeRotation = true;
		//Set gravity to default 9.8f down on y axis
		Physics2D.gravity = new Vector2(0,gravity);
		//ignore 2Dphysics on certain layers when they collide
		Physics2D.IgnoreLayerCollision(10,10);
	}
	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		// Move by Rigidbody rather than transform directly moves
		// MovePosition allows for the clean effect of dragging instead of teleporting
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
		

	}
	void OnMouseDown(){
		beginInteraction = DateTime.Now;
		rb.velocity = new Vector2(0,0);;
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{	
		//Check the provided Collider2D parameter other to see if it is tagged "foo", if it is...
		if (other.gameObject.tag == "LeftBox" && gameObject.tag == "LeftElement" )
		{
			correctAnswers += gameObject.name.Replace("(Clone)","").Trim() + ",";
			//Debug.Log(gameObject.name.Replace("(Clone)","").Trim());
			Destroy(gameObject);
			endInteraction = DateTime.Now; 
			TimeSpan duration = endInteraction.Subtract(beginInteraction);
			if(duration.Milliseconds <= 200)
			{
				Score.scoreValue += 20;
				FindObjectOfType<AudioManager>().Play("bonusnoise");
			}else{
				Score.scoreValue += 10;
				FindObjectOfType<AudioManager>().Play("correctnoise");
			}
		}
		else if (other.gameObject.tag == "RightBox" && gameObject.tag == "RightElement" )
		{
			correctAnswers += gameObject.name.Replace("(Clone)","").Trim() + ",";
			//Debug.Log(gameObject.name.Replace("(Clone)","").Trim());
			Destroy(gameObject);
			endInteraction = DateTime.Now; 
			TimeSpan duration = endInteraction.Subtract(beginInteraction);
			if(duration.Milliseconds <= 200){
				Score.scoreValue += 20;
				FindObjectOfType<AudioManager>().Play("bonusnoise");
			}else{
				Score.scoreValue += 10;
				FindObjectOfType<AudioManager>().Play("correctnoise");
			}
		}
		else if (other.gameObject.CompareTag("BottomBoxCollider")) 
		{ 
			//possibly make it take -5 points away
            Destroy(gameObject);
			//Debug.Log(gameObject.name + " destroyed by " + other.name);
			FindObjectOfType<AudioManager>().Play("destroy");
		}
		else
		{
			incorrectAnswers += gameObject.name.Replace("(Clone)","").Trim() + ",";
			FindObjectOfType<AudioManager>().Play("wrongnoise");
			//Handheld.Vibrate();
			//Debug.Log("else statement is ran");
			gameObject.GetComponent<Renderer>().material.color = Color.red;
			StartCoroutine("FadeOut");
			Score.scoreValue -= 10;
		}
	}

	IEnumerator FadeOut()
	{
		for(float f = 1f; f>=-0.05f; f -= 0.05f){
			Color c = spriteRender.material.color;
			c.a = f;
			spriteRender.material.color = c;
			yield return new WaitForSeconds(.05f);
		}
		Destroy(gameObject);
	}
}
