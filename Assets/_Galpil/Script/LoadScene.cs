using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

	public static LoadScene instance;
	public GameObject panelLoading;

	void Start(){
		instance = this;
	}

	public void GoToScene(int sceneIndex) {
		panelLoading.SetActive(true);
		SceneManager.LoadScene(sceneIndex);
	}

	public void RestartScene() {
		Invoke("Restart",3f);
	}

	void Restart(){
		panelLoading.SetActive(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
