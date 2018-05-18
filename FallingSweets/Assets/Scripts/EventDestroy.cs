using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventDestroy : MonoBehaviour
{

    public int num;
	private AudioSource sourceAudio;
	private AudioSource sourceAudio2;
	public AudioClip BGaudio;
	public AudioClip BGaudio1;
    public int nb = 0;
	public Text Score;
	public Text GMOver;
	public Text Score3;
	public static float CurrentScore;
	//public static float score { get; set;}
    public static int score1 = 0;
	public GameObject popanimation;
    public int magicIndex;

    public static bool Gover { get; set;}


	
    void OnMouseDown()
    {
        nb++;
		sourceAudio = GetComponent<AudioSource>();
		sourceAudio.PlayOneShot(BGaudio);
        
		if (nb==num && !Gover)
		{
            if (magicIndex == 1)
            {
				//GameController.vitesse = GameController.vitesse * 1.3f;
                //Debug.Log("Event Destroy");
                var instance = new GameController();
                instance.setWait();
				score1 = score1 + 100;
            }
            score1 = score1 + nb;

			//score.text = score1.ToString;
			Debug.Log(score1+"score"+nb+"nbclick");

			//Destroy(gameObject,BGaudio1.length);
			Instantiate(popanimation,transform.position,transform.rotation);
			Destroy(gameObject,BGaudio1.length);
			sourceAudio2 = GetComponent<AudioSource>();
			sourceAudio2.PlayOneShot(BGaudio1);
		}
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Limite")
		{
			Debug.Log("kkkkkkkkkk");
			Gover = true;
			//Score3.text = (score1 + "");
			//GMOver.text = "GameOver";
		//	VarGlobal.Gover = true;
			//Destroy(gameObject);
			//GameObject.Find("GameOver").SetActive(true);
			//GameOver.SetActive(true);
		//	Time.timeScale = 0;
			//GameOver.SetActive (true);
		}

		if (collision.gameObject.tag == "magic")
		{
			Debug.Log("magic");
			//Wait();
			Destroy (collision.gameObject,3f);
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(10);

	}
	void OnApplicationQuit()
	{
		Debug.Log( "Destroying ");
		Destroy( gameObject );
		Caching.CleanCache();
	}

	void Update(){
		CurrentScore = score1;
		//score.text = (score1+"");
		//Score3.text = (score1+"");
	}
}
