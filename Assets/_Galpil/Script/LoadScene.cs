using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

	public void GoToScene(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}
}
