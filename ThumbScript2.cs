using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class ThumbScript2 : MonoBehaviour
{
	
	public delegate void Thumb2 ();
	public static event Thumb2 Th2Down;
	public static event Thumb2 Th2Up;

	void Start()
	{
		EasyTouch.On_TouchDown += On_TouchDown;
		EasyTouch.On_TouchUp += On_TouchUp;
	}

	void On_TouchDown (Gesture gesture)
	{

		if (gesture.pickedObject == gameObject)
			{
			Th2Down();
		}
	}

	void On_TouchUp (Gesture gesture)
	{
		if (gesture.pickedObject == gameObject)
			{
			Th2Up();
			}
	}



	public void ThumbDisappear () // Thumbprint needs to disappear when it is touched
	{
		GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
	}

	public void ThumbAppear ()
	{
		GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
	}

}
