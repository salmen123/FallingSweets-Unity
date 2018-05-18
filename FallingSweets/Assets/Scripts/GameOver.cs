using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour {

	// GameOver Items
	public GameObject GameOverimage;
	public GameObject GameOverText;
	public GameObject GameOverScoreText;
	public Text GameOverScoreTextt;
	public GameObject Facebookbtn;
	public GameObject Twitterbtn;
	public GameObject NewGameButton;
	public GameObject PodiumButton;
	public GameObject HomeButton;

	//GameGUI
	public Text ScoreTextt;
	public GameObject ScoreText;
	public GameObject ScoreBGImage;
	public GameObject buttonSoundOn;
	public GameObject buttonSoundOff;
	public GameObject buttonPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//set up loser screen 
	void LoserScreen(bool GameOver)
	{
		GameOverimage.SetActive (GameOver);
		GameOverText.SetActive (GameOver);
		GameOverScoreText.SetActive (GameOver);
		Facebookbtn.SetActive (GameOver);
		Twitterbtn.SetActive (GameOver);
		NewGameButton.SetActive (GameOver);
		PodiumButton.SetActive (GameOver);
		HomeButton.SetActive (GameOver);
		ScoreText.SetActive (!GameOver);
		ScoreBGImage.SetActive (!GameOver);
		buttonSoundOn.SetActive (!GameOver);
		buttonSoundOff.SetActive (!GameOver);
		buttonPause.SetActive (!GameOver);
	}
	public void FacebookShare(){
	}


	public void TwitterShare(){
	}

	public void GoHome(){
		EventDestroy.Gover = false;
		Gamep.isPaused = false;
		EventDestroy.score1 = 0;
		SceneManager.LoadScene (0);
	}

	public void NewGame(){
        ShowAd();

		var instance = new GameController();
		instance.setWait();

        Time.timeScale = 1;
		EventDestroy.Gover = false;
		Gamep.isPaused = false;
		EventDestroy.score1 = 0;
		SceneManager.LoadScene (1);
    }


	public void NewGame2(){
		ShowAd();

		var instance = new GameController();
		instance.setWait();

		Time.timeScale = 1;
		EventDestroy.Gover = false;
		Gamep.isPaused = false;
		EventDestroy.score1 = 0;
		SceneManager.LoadScene (2);
	}

	public void NewGame3(){
		ShowAd();

		var instance = new GameController();
		instance.setWait();

		Time.timeScale = 1;
		EventDestroy.Gover = false;
		Gamep.isPaused = false;
		EventDestroy.score1 = 0;
		SceneManager.LoadScene (3);
	}




    public void ShowAd()
    {

        Advertisement.Initialize("1409167", true);
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
        }

    }

    private void HandleAdResult(ShowResult result)
    {
  switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("player gain +10 gold");
                break;
            case ShowResult.Skipped:
                Debug.Log("Player did not fully watch the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("player failed to lunch the ad?internet?");
                break;
        }
    }

}
