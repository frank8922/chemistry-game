using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IHasChanged {
	[SerializeField] Transform DropPanel,DragPanel;
	public static GameObject itemBeingDragged;
	public Vector3 startPosition;
	public Transform startParent;


	void Start(){

		

	}



	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == startParent){
			transform.position = startPosition;
		}

		
	}

    public void HasChanged()
    {
	
    }
    #endregion
}

#region IHasChanged implementation
namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged();
	}
}
#endregion