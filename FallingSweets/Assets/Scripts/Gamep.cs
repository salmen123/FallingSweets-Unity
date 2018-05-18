using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamep : MonoBehaviour {

	public static bool isPaused;
	public static bool SoundOfff;
	//GamePaused Items
	public  GameObject GamePausedimage;
	public  GameObject GamePausedText;
	public  GameObject Homebtn;
	public  GameObject Replaybtn;

	//GameGUI
	public GameObject ScoreText;
	public GameObject ScoreBGImage;
	public GameObject buttonSoundOn;
	public GameObject buttonSoundOff;
	public GameObject buttonPause;

	// Use this for initialization
	void Start () {
		PauseScreen (false);
		buttonSoundOn.SetActive (true);
		if (isPaused) {
			//PauseScreen (true);
			Pause (true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			//PauseScreen (true);
			Pause (true);
		}
		if (SoundOfff) {
			AudioListener.pause = true;
			AudioListener.volume = 0; 
			buttonSoundOff.SetActive(true);
			buttonSoundOn.SetActive(false);

		}
	}

	//set up pause screen
	void PauseScreen(bool pause)
	{
		GamePausedimage.SetActive (pause);
		GamePausedText.SetActive (pause);
		Homebtn.SetActive (pause);
		Replaybtn.SetActive (pause);
		ScoreText.SetActive (!pause);
		ScoreBGImage.SetActive (!pause);
		buttonSoundOn.SetActive (!pause);
		buttonSoundOff.SetActive (!pause);
		buttonPause.SetActive (!pause);
	}

	// Pause clicked
	public void ButtonPause(){

		isPaused = true;
		PauseScreen (true);
		AudioListener.pause = true;
		AudioListener.volume = 0;
		Time.timeScale = 0;


	}
	// Pause
	void Pause(bool pause){

		isPaused = pause;
		PauseScreen (pause);
		AudioListener.pause = pause;
		AudioListener.volume = 0;
		Time.timeScale = 0;


	}

	//Replay
	public void Replay(){

		isPaused = false;
		PauseScreen(false);
		AudioListener.pause = false;
		AudioListener.volume = 1; 
		Time.timeScale = 1;



	}

	//SoundOff
	public void SoundOff(){
		buttonSoundOff.SetActive(true);
		buttonSoundOn.SetActive(false);
		if (AudioListener.volume == 0) {
			SoundOfff = false;
			AudioListener.pause = false;
			AudioListener.volume = 1; 
			buttonSoundOff.SetActive(false);
			buttonSoundOn.SetActive(true);

		} else {
			SoundOfff = true;
			AudioListener.pause = true;
			AudioListener.volume = 0; 
			buttonSoundOff.SetActive(true);
			buttonSoundOn.SetActive(false);

		}

	}

	public void GoHome(){
		isPaused = false;
		EventDestroy.score1 = 0;
		SceneManager.LoadScene (0);
	}

	void OnApplicationFocus(bool hasFocus)
	{
		isPaused = !hasFocus;
		//Pause (!hasFocus);
	}

	void OnApplicationPause(bool pauseStatus)
	{
		isPaused = pauseStatus;
		//Pause (pauseStatus);
	}
}
