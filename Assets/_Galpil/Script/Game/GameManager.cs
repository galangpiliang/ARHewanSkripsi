using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] objGame;

	// Use this for initialization
	void Start () {
		RandomGame();
	}
	
	// Update is called once per frame
	void RandomGame () {
		int randomNumber = Random.Range(0,objGame.Length);
		if (randomNumber == PlayerPrefs.GetInt("randomNumber",0)){
			RandomGame();
		}else{
			PlayerPrefs.SetInt("randomNumber",randomNumber);
			for(int i=0;i<objGame.Length;i++){
				objGame[i].SetActive(false);
			}
			objGame[randomNumber].SetActive(true);
		}
	}
}
