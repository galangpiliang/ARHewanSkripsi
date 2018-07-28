using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLengkapKata : MonoBehaviour {

	public Text textJawaban;
	public Button[] objPilihan;
	public GameObject panelBenar;
	public GameObject panelSalah;


	// Use this for initialization
	void Start () {
		textJawaban.enabled = false;
		objPilihan[0].onClick.AddListener(Benar);		
		objPilihan[1].onClick.AddListener(Salah);		
		objPilihan[2].onClick.AddListener(Salah);		
		objPilihan[3].onClick.AddListener(Salah);		
	}

	public void Benar(){
		textJawaban.enabled = true;
		for (int i=0;i<objPilihan.Length;i++){
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
