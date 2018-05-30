using UnityEngine;
using System.Collections;

public class DraggingObjectsAlkaline : MonoBehaviour
{
	Rigidbody2D rb;

	void Start()
	{
		// Store reference to attached Rigidbody
		rb = GetComponent<Rigidbody2D>();
	}



	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		// Move by Rigidbody rather than transform directly
		rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Alkaline"))
		{
			Destroy(this.gameObject);

		}


	}
}