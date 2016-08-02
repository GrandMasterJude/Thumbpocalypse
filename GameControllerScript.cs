using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour 
{
	public GameObject plane;
	Canvas canvas;
	[SerializeField]
	bool p1Thumb = false;    // true when the players thumb is down
	[SerializeField]
	bool p2Thumb = false;
	bool started;   // true when the bomb is active in the scene

	void Start ()
	{
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
		//canvas = FindObjectOfType<Canvas>();
		yield return new WaitForSeconds (0.6F);
		//canvas.isRootCanvas

		//GetComponent<CanvasGroup>().alpha = 255;

		//GetComponentInChildren<Text>().CrossFadeAlpha (255f, 0f, true);
		 
		//3,2,1
		Instantiate(plane, new Vector3 (5,0,0), Quaternion.Euler(0,0,90));

		yield return null;
	}


	public void ThumbDown1 ()   
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
		
}
