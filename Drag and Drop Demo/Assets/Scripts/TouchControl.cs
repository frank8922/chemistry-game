using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

	// touch offset allows ball not to shake when it starts moving
	float deltaX, deltaY;

	// reference to Rigidbody2D component
	private Rigidbody2D rb;
	// gravity
	private float gravity = -1.0f;



	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		Physics2D.gravity = new Vector2(0,gravity);
		Physics2D.IgnoreLayerCollision(10, 10);
	}

	// Update is called once per frame
	void Update()
	{

		// Initiating touch event
		// if touch event takes place
		if (Input.touchCount > 0)
		{

			// get touch to take a deal with
			Touch touch = Input.GetTouch(0);

			// obtain touch position
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			// processing touch phases
			switch (touch.phase)
			{

				// if you touches the screen
				case TouchPhase.Began:

					// if you touch the ball
					if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						// get the offset between position you touhes
						// and the center of the game object
						deltaX = touchPos.x - transform.position.x;
						deltaY = touchPos.y - transform.position.y;

						// restrict some rigidbody properties so it moves
						// more smoothly and correctly 									
						rb.velocity = new Vector2(0, 0);
						//rb.gravityScale =1;
						//GetComponent<CircleCollider2D>().sharedMaterial = null;
					}
					break;

				// you move your finger
				case TouchPhase.Moved:

					// if you thouches the ball and movement is allowed then move
					if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
					{
						rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
						gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
					}

					break;

				// you release your finger
				case TouchPhase.Ended:
					// restore initial parameters
					// when thouch is ended
					gameObject.transform.localScale = new Vector3(1, 1, 1);
					rb.freezeRotation = true;
					Physics2D.gravity = new Vector2(0, gravity);
					rb.gravityScale = 1;
				break;
			}
		}


	}
//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("The OnTriggerEnter2D() for "  + other.gameObject.tag + " was called");

		//Check the provided Collider2D parameter other to see if it is tagged "foo", if it is...
		if (other.gameObject.tag == "Alkali" && gameObject.tag == "AlkaliElement" )
		{
			Destroy(gameObject);
			//Score.scoreValue += 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);


		}
		else if (other.gameObject.tag == "Alkaline" && gameObject.tag == "AlkalineElement" )
		{
			Destroy(gameObject);
			//Score.scoreValue += 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);


		}
		else if (other.gameObject.CompareTag("BottomBoxCollider")) 
		{ 
            Destroy(gameObject);
			//Score.scoreValue -= 10;
			Debug.Log(gameObject.name + " destroyed by " + other.name);

		}
		else
		{
			//TODO: implement some kind of feedback this statement will run when user gets wrong answer
			Debug.Log("else statement is ran");

		}

	}
}
