using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;
    
	void Update ()
	{
	    if (HasInput)
	    {
	        DragOrPickUp();
	    }
	    else
	    {
	        if (draggingItem)
	            DropItem();
	    }
	}
    Vector2 CurrentTouchPosition
    {
        get
        {
           return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;
        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    //draggedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }
            }
        }
    }
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }
    void DropItem()
    {
        draggingItem = false;
        draggedObject.transform.localScale = new Vector3(1, 1, 1);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("AlkaliElement")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

		}
		

	}
}
