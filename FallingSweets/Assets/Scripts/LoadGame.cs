using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

	public void StartGameEasy () {
		

		SceneManager.LoadScene (1);
		Time.timeScale = 1;
	}
	public void StartGameMedium () {


		SceneManager.LoadScene (2);
		Time.timeScale = 1;
	}
	public void StartGameHard () {


		SceneManager.LoadScene (3);
		Time.timeScale = 1;
	}
		
	public void QuitGame () {
		Application.Quit();
	}


}
