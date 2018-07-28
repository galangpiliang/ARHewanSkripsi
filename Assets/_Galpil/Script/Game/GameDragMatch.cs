using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDragMatch : MonoBehaviour {

	public DraggableImage[] draggableImage;
	public static GameDragMatch instance;
	public GameObject panelBenar;

	public void Start(){
		instance = this;
	}
		
	// Update is called once per frame
	public void CountingScore () {
		int score = 0;
		for(int i=0;i<draggableImage.Length;i++){
			if(draggableImage[i].matching){
				score += 1;
			}
		}
		if (score == 4){
			Debug.Log("Win");
			panelBenar.SetActive(true);
			LoadScene.instance.RestartScene();
		}
	}
}
