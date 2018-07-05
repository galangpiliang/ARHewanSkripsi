using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToogleFlash : MonoBehaviour {

	bool flashon = false;
	
	public void OnTap() {
		if (!flashon)
			SetOn();
		else
			SetOff();
	}

	void SetOn(){
		CameraDevice.Instance.SetFlashTorchMode(true);
		flashon=true;
	}

	void SetOff(){
		CameraDevice.Instance.SetFlashTorchMode(false);
		flashon=false;
	}
}
