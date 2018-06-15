using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingObjects : MonoBehaviour {
	private Rigidbody2D rb;
	private float gravity = -1.0f;
	private float maxSpeed = 1.5f;


	void FixedUpdate()
	{
		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}

	}


	//use Start() as init function
	void Start()
	{
		//Debug.Log("Start() for " + gameObject + " was called");
		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
		//set the rigid body not to rotate
		rb.freezeRotation = true;
		//Set gravity to default 9.8f down on y axis
		Physics2D.gravity = new Vector2(0,gravity);
		//ignore 2Dphysics on certain layers when they collide
		Physics2D.IgnoreLayerCollision(10,10);
	}


	
	//can be thought of as a touch drag
	//TODO: Use touch instead of Mouse
	void OnMouseDrag()
	{
		//Debug.Log("OnMouseDrag() for " + this.gameObject + " was called");
		//gets the distance from the gameObject to the camera which is the z axis 
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		// Move by Rigidbody rather than transform directly moves
		// MovePosition allows for the clean effect of dragging instead of teleporting
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
		//when dragging the object around it gets a little bit bigger
		rb.velocity = new Vector3(0,0,0);
		//gameObject.transform.localScale = new Vector3(.65f, .65f, .65f);

	}


	//can be thought of as when user stops touching
	//TODO: Use touch instead of Mouse
	void OnMouseExit()
	{
		//Debug.Log("OnMouseExit() for " + this.gameObject + " was called");
		//when the user stops dragging go back to normal
		//gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}


	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("The OnTriggerEnter2D() for "  + other.gameObject.tag + " was called");
		
		//Check the provided Collider2D parameter other to see if it is tagged "foo", if it is...
		if (other.gameObject.tag == "Alkali" && gameObject.tag == "AlkaliElement" )
		{
			Destroy(gameObject);
			Score.scoreValue += 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);
			FindObjectOfType<AudioManager>().Play("correctnoise");


		}
		else if (other.gameObject.tag == "Alkaline" && gameObject.tag == "AlkalineElement" )
		{
			Destroy(gameObject);
			Score.scoreValue += 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);
			FindObjectOfType<AudioManager>().Play("correctnoise");


		}
		else if (other.gameObject.CompareTag("BottomBoxCollider")) 
		{ 
            Destroy(gameObject);
			Score.scoreValue -= 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);
			FindObjectOfType<AudioManager>().Play("destroy");

		}
		else
		{
			FindObjectOfType<AudioManager>().Play("wrongnoise");
			Handheld.Vibrate();
			Debug.Log("else statement is ran");

		}

	}
}
