using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableImage : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{

	private Image image;
	private Vector2 startPos;
	private Vector2 targetPos;
	public bool matching;

	public GameObject dropItem;
	public bool dragging = false;
	public bool collision = false;

	private void Awake(){
		image = GetComponent<Image>();
		startPos = this.gameObject.transform.position;
	}

	public void OnDrag(PointerEventData eventData){
		if(dragging)
			transform.position = eventData.position; 
	}
	
	public void OnBeginDrag(PointerEventData eventData){
		image.color = Color.green;
		dragging = true;
	}
	
	public void OnEndDrag(PointerEventData eventData){
		image.color = Color.white;
		dragging = false;
		if(!collision){
			gameObject.transform.position = startPos;
			matching = false;
		}else{
			gameObject.transform.position = targetPos;
			matching = true;
			GameDragMatch.instance.CountingScore();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == dropItem.name){
			targetPos = col.transform.position;
			collision = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		collision = false;		
	}
}
