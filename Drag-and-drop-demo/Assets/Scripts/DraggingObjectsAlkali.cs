using UnityEngine;
using System.Collections;

public class DraggingObjectsAlkali : MonoBehaviour
{
	Rigidbody2D rb;



	void Start()
	{

		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
		Physics2D.IgnoreLayerCollision(8,9);

	}



	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		// Move by Rigidbody rather than transform directly
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
		gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

	}





	void OnMouseExit()
	{
		gameObject.transform.localScale = new Vector3(1, 1, 1);
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("OnTriggerEnter2D was triggered");
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Alkali"))
		{
			Destroy(this.gameObject);
			Debug.Log("gameobject destroyed");

		}

		else
		{

			//this.gameObject.transform.position = new Vector3(0,0);
			Debug.Log("else statement is ran");


		}

	}
}
