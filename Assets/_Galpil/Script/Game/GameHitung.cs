using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHitung : MonoBehaviour {

	public Button[] objPilihan;
	public GameObject panelBenar;
	public GameObject panelSalah;


	// Use this for initialization
	void Start () {
		objPilihan[0].onClick.AddListener(Benar);		
		objPilihan[1].onClick.AddListener(Salah);		
		objPilihan[2].onClick.AddListener(Salah);		
		objPilihan[3].onClick.AddListener(Salah);		
	}

	public void Benar(){
		for (int i=1;i<objPilihan.Length;i++){
			objPilihan[i].gameObject.SetActive(false);
		}
		Invoke("EnablePanelBenar",2f);
		
	}

	public void Salah(){
		panelSalah.SetActive(true);
		Invoke("DisableOBJ",3f);
	}

	void DisableOBJ(){
		panelBenar.SetActive(false);
		panelSalah.SetActive(false);
	}

	void EnablePanelBenar(){
		panelBenar.SetActive(true);
		LoadScene.instance.RestartScene();	
	}

}
