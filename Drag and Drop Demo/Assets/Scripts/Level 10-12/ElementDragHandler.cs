using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementDragHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 originalPosition;
    public bool col, cond;

    public Transform originalParent, copyOfOtherParent;
    public Vector3 otherPosition;

    public Transform DropPanel;
    



    void Start()
    {
        Physics2D.gravity = new Vector2(0, 0);
        originalParent = gameObject.transform.parent;
        Physics2D.IgnoreLayerCollision(10, 10);
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
       
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Other object is " + other.name + " gameObject is " + gameObject.name);
        //This should be true 
        if (other.tag == "DropPanel" && gameObject.tag == "Elements")
        {
            Debug.Log("The object should snap into the slot");
            //collision has taken place
            col = true;
            //save the position of what we collided with
            otherPosition = other.transform.position;
            //save the other objects
            copyOfOtherParent = other.transform;   
        }
        else
        {
            col = false;
            cond = true;
        }
    }

    void OnMouseUp()
    {
        originalPosition = transform.position;

        if (col)
        {

            
            if(DropPanel.childCount >= 2 && gameObject.transform.parent == DropPanel){
                Debug.Log("User is rearranging the elements in the droppanel");
                transform.position = originalParent.position;
                transform.parent = originalParent;
                
            }else{
                FindObjectOfType<AudioManager>().Play("buttonnoise");
                transform.position = new Vector3(otherPosition.x, otherPosition.y, otherPosition.z);
                transform.parent = copyOfOtherParent.transform;
                
            }

            
        }
        else
        {
            if (cond)
            {
                cond = false;
            }

            transform.position = originalParent.position;
            transform.parent = originalParent;

        }
    }




    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ExitIsCalled");
        col = false;
    }


}
