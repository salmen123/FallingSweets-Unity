using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Include Facebook namespace
using Facebook.Unity;

public class FBHandler : MonoBehaviour {
	//public Text tstStatus;
	public GameObject/* Loginbtn, Logoutbtn,*/Sharebtn;
	//public Image profileImg;
	//public Sprite logoutImage;
	List<string> perms = new List<string>(){"public_profile", "email", "user_friends"};
	// Use this for initialization
	FacebookDelegate <IShareResult> FeedCallback;

	//twitter
	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en"; 
	
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
			//tstStatus.text = "Failed to Initialize the Facebook SDK";
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			//setting parameters
			FB.API("/me?fields=name",HttpMethod.GET,DispName);
		
			FB.API("me/picture?type=large&height=128&widh=128", HttpMethod.GET, GetPicture);

			//Loginbtn.SetActive (false); Logoutbtn.SetActive (true);
			Sharebtn.SetActive (true);
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
		//	tstStatus.text = "Your user Id is" +aToken.UserId ;
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
		} else {
		//	Loginbtn.SetActive (true); Logoutbtn.SetActive (false);
			Sharebtn.SetActive (false);
			Debug.Log("User cancelled login");
		//	tstStatus.text = "User cancelled login";
		}
	}
	public void Lougout(){
		FB.LogOut ();
	//	Logoutbtn.SetActive (false);
	//	Loginbtn.SetActive (true);
		Sharebtn.SetActive (false);
	//	tstStatus.text = "Press the login button to login into you facebook account";
	//	profileImg.GetComponent<Image> ().sprite = logoutImage;
	}

	public void FBLogin(){

		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	void DispName(IResult result){
		if (result.Error != null) {
		//	tstStatus.text = result.Error;
		} else {
			//tstStatus.text = "Hi there: " + result.ResultDictionary ["name"];
		}
	}

	private void GetPicture(IGraphResult result)
	{
		if (result.Error == null && result.Texture != null)
		{       


		//	Image ProfilePic = profileImg.GetComponent<Image> ();

		//	ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128,128), new Vector2 ());

		}
	}

	/*	public void ShareWithFriends()
	{
		//need real device to be tested

		FB.FeedShare(
			link:new System.Uri("https://www.esprit.tn/"),
			linkName: "Hey Guys! Check out my score:2335 ",
			linkCaption: "FacebookShareWithUnity",
			linkDescription: "description",
			picture:new System.Uri("https://example.com/myapp/assets/bgimage.jpg"),
			callback: FeedCallback
		);

	}*/

	/*public void inviteFriends()
	{
		//need real device to be tested
		FB.AppRequest(
			message: "Challenge message", 
			title:"Invitation For Friends"
		);
	}*/

	public void ShareLinkOnFB(){
		float scoreff = EventDestroy.score1;
		Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+FB.AppId+ "&link="+
			new System.Uri("https://www.esprit.tn/")+  "&name=&caption="+
			"I just got"+(scoreff)+"score in Falling Sweets Game! Can you beat it?"+"&picture="+"https://develop.backendless.com/3.x/console/CE7CF743-7642-3635-FF75-B9F8637D0700/appversion/ABCB3E98-C5AB-6E89-FF73-53366A455C00/uawcmdixxdlmalxcmppxypxxtlsxzntwmmwy/files/view/bgimage.jpg"+ "&description="+("Join those delicious Jelly sweets and enjoy the most entertaining tapping game around with simple game-play but extremely attractive to players,a lot of people love and passionate to this. Pop the most quantitie of falling Jellys you can, and the more you do the higher score you get. Don’t hesitate")+
			"&redirect_uri=https://facebook.com/");
	}

	public void ShareToTwitter (string textToDisplay)
	{
		float scoreff = EventDestroy.score1;
		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL("I just got "+(scoreff)+" score in Falling Sweets ! Can you beat it? "+"  #FallingSweets #EspritMobile") +
			"&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE)+"&picture="+"https://develop.backendless.com/3.x/console/CE7CF743-7642-3635-FF75-B9F8637D0700/appversion/ABCB3E98-C5AB-6E89-FF73-53366A455C00/uawcmdixxdlmalxcmppxypxxtlsxzntwmmwy/files/view/bgimage.jpg");
	}
}

