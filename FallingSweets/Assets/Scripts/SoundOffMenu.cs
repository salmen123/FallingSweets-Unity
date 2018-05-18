using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOffMenu : MonoBehaviour {



	//GameGUI
	public GameObject buttonSoundOnMenu;
	public GameObject buttonSoundOffMenu;

	// Use this for initialization
	void Start () {
		buttonSoundOffMenu.SetActive(false);
		buttonSoundOnMenu.SetActive(true);
		AudioListener.pause = false;
		AudioListener.volume = 1;
		checkSound ();
	}

	void checkSound(){
		
		if (Gamep.SoundOfff == true) {
			AudioListener.pause = true;
			AudioListener.volume = 0; 
			buttonSoundOffMenu.SetActive(true);
			buttonSoundOnMenu.SetActive(false);

		}
	
	
	}
	// Update is called once per frame
	void Update () {
		checkSound ();
	}


	//SoundOff
	public void SoundOff(){

		if (AudioListener.volume == 0) {
			Gamep.SoundOfff = false;
			AudioListener.pause = false;
			AudioListener.volume = 1; 
			buttonSoundOffMenu.SetActive(false);
			buttonSoundOnMenu.SetActive(true);

		} else {
			Gamep.SoundOfff = true;
			AudioListener.pause = true;
			AudioListener.volume = 0; 
			buttonSoundOffMenu.SetActive(true);
			buttonSoundOnMenu.SetActive(false);

		}

	}
}
