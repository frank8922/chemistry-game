using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderListener : MonoBehaviour
 {

	 Vector3 TopMiddleElementPosition,TopLeftElementPosition,TopRightElementPosition,BottomLeftElementPosition,BottomRightElementPosition,BottomMiddleElementPosition;
     void Awake()
     {
         // Check if Colider is in another GameObject
         Collider2D collider = GetComponentInChildren<Collider2D>();
         if (collider.gameObject != gameObject)
         {
             ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
             cb.Initialize(this);
         }
     }

	 void Start(){
		Vector3 TopLeftElementPosition = new Vector3(GameObject.Find("TopLeftElement").GetComponent<RectTransform>().position.x,GameObject.Find("TopLeftElement").GetComponent<RectTransform>().position.y,GameObject.Find("TopLeftElement").GetComponent<RectTransform>().position.z);
		Vector3 TopMiddleElementPosition = new Vector3(GameObject.Find("TopMiddleElement").GetComponent<RectTransform>().position.x,GameObject.Find("TopMiddleElement").GetComponent<RectTransform>().position.y,GameObject.Find("TopMiddleElement").GetComponent<RectTransform>().position.z);
		Vector3 TopRightElementPosition = new Vector3(GameObject.Find("TopRightElement").GetComponent<RectTransform>().position.x,GameObject.Find("TopRightElementElement").GetComponent<RectTransform>().position.y,GameObject.Find("TopRightElementElement").GetComponent<RectTransform>().position.z);
		Vector3 BottomRightElementPosition = new Vector3(GameObject.Find("BottomRightElement").GetComponent<RectTransform>().position.x,GameObject.Find("BottomRightElement").GetComponent<RectTransform>().position.y,GameObject.Find("BottomRightElement").GetComponent<RectTransform>().position.z);
		Vector3 BottomMiddleElementPosition = new Vector3(GameObject.Find("BottomMiddleElement").GetComponent<RectTransform>().position.x,GameObject.Find("BottomMiddleElement").GetComponent<RectTransform>().position.y,GameObject.Find("BottomMiddleElement").GetComponent<RectTransform>().position.z);
		Vector3 BottomLeftElementPosition = new Vector3(GameObject.Find("BottomLeftElement").GetComponent<RectTransform>().position.x,GameObject.Find("BottomLeftElement").GetComponent<RectTransform>().position.y,GameObject.Find("TopLeftElement").GetComponent<RectTransform>().position.z);
	 }
     public void OnCollisionEnter2D(Collision2D collision)
     {
        Debug.Log("OnCollisionEnter2D was called");
     }
     public void OnTriggerEnter2D(Collider2D other)
     {
         Debug.Log("OnTriggerEnter2D was called " + other.GetComponent<SpriteRenderer>().sprite.name.ToString() + " has collided with something");

		 if(other.name == "TopLeftElement" || other.name.Replace("(Clone)","").Trim() == "TopLeftElement"){

			 Instantiate(gameObject,TopLeftElementPosition, gameObject.transform.rotation);

		 }else if(other.name == "TopMiddleElement" || other.name.Replace("(Clone)","").Trim() == "TopMiddleElement"){
			 Instantiate(gameObject,TopMiddleElementPosition, gameObject.transform.rotation);

		 }else if(other.name == "TopRightElement" || other.name.Replace("(Clone)","").Trim() == "TopRightElement"){
			 Instantiate(gameObject,TopRightElementPosition, gameObject.transform.rotation);

		 }else if(other.name == "BottomRightElement" || other.name.Replace("(Clone)","").Trim() == "BottomRightElement"){
			 Instantiate(gameObject,BottomRightElementPosition, gameObject.transform.rotation);

		 }else if(other.name == "BottomMiddleElement" || other.name.Replace("(Clone)","").Trim() == "BottomMiddleElement"){
			 Instantiate(gameObject,BottomMiddleElementPosition, gameObject.transform.rotation);

		 }else{
			 Instantiate(gameObject,BottomLeftElementPosition, gameObject.transform.rotation);

		 }
		 
		 
     }
 }
