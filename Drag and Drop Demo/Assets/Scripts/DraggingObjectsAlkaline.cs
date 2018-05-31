using UnityEngine;
using System.Collections;

public class DraggingObjectsAlkaline : MonoBehaviour
{
	Rigidbody2D rb;

	//use to as init function
	void Start()
	{
		Debug.Log("Start() for " + this.gameObject + " was called");
		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		Physics2D.gravity = new Vector2(0,-9.8f);

		//ignore 2Dphysics on certain layers when they collide
		Physics2D.IgnoreLayerCollision(10,10);
		//Physics2D.IgnoreLayerCollision(8,9);
		//Physics2D.IgnoreLayerCollision(8,8);
		//Physics2D.IgnoreLayerCollision(9,9);
		//Physics2D.IgnoreLayerCollision(9,8);
	}


	//can be thought of as when user stops touching
	//TODO: Use touch instead of Mouse
	void OnMouseDrag()
	{
		Debug.Log("OnMouseDrag() for " + this.gameObject + " was called");
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		// Move by Rigidbody rather than transform directly
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
		gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
	}


	//can be thought of as when user stops touching
	//TODO: Use touch instead of Mouse
	void OnMouseExit()
	{
		Debug.Log("OnMouseExit() for " + this.gameObject + " was called");
		gameObject.transform.localScale = new Vector3(1, 1, 1);	
	}



	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("The OnTriggerEnter2D() for "  + other.gameObject.name + " was called");

		//Check the provided Collider2D parameter other to see if it is tagged "foo", if it is...
		if (other.gameObject.CompareTag("Alkali"))
		{

			Destroy(this.gameObject);
			Score.scoreValue += 10;
			Debug.Log(this.gameObject.name + " destroyed by correct group");
		}
		else if (other.gameObject.CompareTag("BottomBoxCollider")) 
		{ 
        	Destroy(this.gameObject);
			Score.scoreValue -= 10;
			Debug.Log(this.gameObject.name + " destroyed by bottom box collider");
		}
		else
		{
			//TODO: make some type of feedback
			//this.gameObject.transform.position = new Vector3(0,0);
			Debug.Log("else statement is ran");

		}

	}
}