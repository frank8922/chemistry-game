using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 originalPosition,otherPosition;
    private bool col, cond;
    public Transform originalParent, copyOfOtherParent, DropPanel;


    private static int count = 0;
    
    void Start()
    {
        Physics2D.gravity = new Vector2(0, 0);
        originalParent = transform.parent;
        Physics2D.IgnoreLayerCollision(10, 10);
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.MovePosition(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen)));
    }

    void OnMouseUp()
    {
        
        if (col)
        {
            if(DropPanel.childCount >= 2 && gameObject.transform.parent == DropPanel){
                Debug.Log("User is rearranging the elements in the droppanel");
                transform.position = originalParent.position;
                transform.parent = originalParent;
                
            }else{
                transform.position = new Vector3(otherPosition.x, otherPosition.y, otherPosition.z);
                transform.parent = copyOfOtherParent.transform;
                
            }
        }
        else
        {
            if (cond)
            {
                FindObjectOfType<AudioManager>().Play("falsenoise");
                cond = false;
            }
            transform.position = originalParent.position;
            transform.parent = originalParent;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == gameObject.tag)
        {
            col = true;
            otherPosition = other.transform.position;
            copyOfOtherParent = other.transform;
            if (gameObject.transform.position == other.transform.position)
            {
                other.enabled = false;
            }
        }
        else
        {
            col = false;
            other.enabled = true;
            cond = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        col = false;
    }
}
