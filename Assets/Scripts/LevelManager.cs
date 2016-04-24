using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void  loadLevel(string name){
		UnityEngine.SceneManagement.SceneManager.LoadScene (name);
	}
	public void quitGame(){
		Application.Quit();
	}

	public void LoadNextLevel(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

	}
		
}
