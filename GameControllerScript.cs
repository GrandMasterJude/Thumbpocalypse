using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour 
{
	public GameObject plane;
	[SerializeField]
	bool p1Thumb = false;    // true when the players thumb is down
	[SerializeField]
	bool p2Thumb = false;
	bool started;   // true when the bomb is active in the scene
	public Button retryButton;
	public CanvasGroup clr;
	public Text countDown;
	public ThumbScript th;
	public ThumbScript2 th2;

	void Start ()
	 
	{
		retryButton.enabled = false;
		clr.alpha = 0;
		ThumbScript.Th1Down += ThumbDown1; //Subscription to events for when thumbs are touched
		ThumbScript.Th1Up += ThumbUp1;
		ThumbScript2.Th2Down += ThumbDown2;
		ThumbScript2.Th2Up += ThumbUp2;
	}
	
	void Update()
	{
		if ( p1Thumb == true && p2Thumb == true && started == false) // When both thumbs are down start the game.
		{
				StartCoroutine (Gamestart());
				started = true;	
		}
	}

	IEnumerator Gamestart ()
	{
		yield return new WaitForSeconds (0.3F);
		countDown.text = "3";
		yield return new WaitForSeconds (1.0F);
		countDown.text = "2";
		yield return new WaitForSeconds (1.0F);
		countDown.text = "1";

		Instantiate(plane, new Vector3 (5,0,0), Quaternion.Euler(0,0,90));
		yield return new WaitForSeconds (1.0F);
		countDown.text = "THUMBPOCALYPSE!";
		countDown.fontSize = 36;
		yield return new WaitForSeconds (0.8F);
		countDown.text = "";
		yield return null;
	}


	public void ThumbDown1 ()   // Methods called by events to keep track of the thumbs state
	{
		p1Thumb = true;
	}

	public void ThumbDown2 ()
	{
		p2Thumb = true;
	}

	public void ThumbUp1 ()
	{
		p1Thumb = false;
	}

	public void ThumbUp2 ()
	{
		p2Thumb = false;
	}
		

	public void Retry()
	{
		retryButton.enabled = true;
		clr.alpha = 255;
	}

	public void RetryClicked()
	{
		th.Unsubscribe();
		th2.Unsubscribe();
		SceneManager.LoadScene("ThumbMain");
	}

	public void QuitCLicked()
	{
		
		Application.Quit();
	}
}
