using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour {



    public GameObject hazard;
    public GameObject [] balls;
	public Vector3 spawnValues;
	public int hazardCount;
	public static float spawnWait=2;
	public float startWait;
	public static bool play;
    public GameObject bnbnMagic;

    //public float waveWait;

    // GameOver Items
    public GameObject GameOverimage;
	public GameObject GameOverText;
	public GameObject GameOverScoreText;
	public Text GameOverScoreTextt;
	public GameObject Facebookbtn;
	public GameObject Twitterbtn;
	public GameObject NewGameButton;
	//public GameObject PodiumButton;
	public GameObject HomeButton;

	//GameGUI
	public Text ScoreTextt;
	public GameObject ScoreText;
	public GameObject ScoreBGImage;
	public GameObject buttonSoundOn;
	public GameObject buttonSoundOff;
	public GameObject buttonPause;

	private float nextActionTime = 0.0f;
	public float period = 10f;
	public static float vitesse = 0.1f;
	// Use this for initialization
	void Start () {
        StartCoroutine (SpawnWaves());
		LoserScreen(false);
		AudioListener.pause = false;
		AudioListener.volume = 1;

    }




	//set up loser screen 
public	void LoserScreen(bool GameOver)
	{
		GameOverimage.SetActive (GameOver);
		GameOverText.SetActive (GameOver);
		GameOverScoreText.SetActive (GameOver);
		Facebookbtn.SetActive (GameOver);
		Twitterbtn.SetActive (GameOver);
		NewGameButton.SetActive (GameOver);
		//PodiumButton.SetActive (GameOver);
		HomeButton.SetActive (GameOver);
		ScoreText.SetActive (!GameOver);
		ScoreBGImage.SetActive (!GameOver);
		buttonSoundOn.SetActive (!GameOver);
		buttonSoundOff.SetActive (!GameOver);
		buttonPause.SetActive (!GameOver);
	}
	


	//generate prefabs
    IEnumerator SpawnWaves()
    {
        play = true;
        yield return new WaitForSeconds(startWait);
        while(play)
        {
			
           // spawnWait = spawnWait * 0.9f;
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject ball = balls[Random.Range(0, balls.Length)];
				//ball.GetComponent<Rigidbody> ().useGravity = true;
			//	ball.GetComponent<Rigidbody2D>().gravityScale = vitesse;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion();
                if (i == 5)
                {
                    Instantiate(bnbnMagic, spawnPosition, spawnRotation);
				//	bnbnMagic.GetComponent<Rigidbody2D>().gravityScale = vitesse;
                    yield return new WaitForSeconds(spawnWait);
                }

                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            //yield return new WaitForSeconds(waveWait);
        }

    }

    public void setWait()
    {

        spawnWait = 2;
        Debug.Log("magic tapped");

    }


    // Update is called once per frame
    void Update () {

		//spawn wait setup
	
		
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
				//spawnWait = 0.9f * spawnWait;

		}
		//****

		ScoreTextt.text = (EventDestroy.CurrentScore+"");
		if(EventDestroy.Gover == true)
		{
			Debug.Log ("GameOver");
			GameOverScoreTextt.text =  (EventDestroy.CurrentScore+"");
			LoserScreen(true);
			Time.timeScale = 0;
			AudioListener.pause = true;
			AudioListener.volume = 0;
		

		}



    }
	

	

}
