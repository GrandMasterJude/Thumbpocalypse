using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{
	
	Vector2 bombPostion = new Vector2 (0,0);
	bool facingUp = false;
	[SerializeField]
	bool p1Thumb = false;    // These are true when the thumb is down
	[SerializeField]
	bool p2Thumb = false;



	void OnEnable()

	{
		ThumbScript.Th1Down += ThumbDown11; // Subscriptions to the events for when the thumbs are touched
		ThumbScript.Th1Up += ThumbUp11;
		ThumbScript2.Th2Down += ThumbDown22;
		ThumbScript2.Th2Up += ThumbUp22;
	}



	void Update ()
	{
		if (p1Thumb == true && p2Thumb == true)   // When both thumbs are down the bomb moves toward the lowest side of the device
		{

			if (0.5f > Input.acceleration.y & Input.acceleration.y > 0f)
			{
				bombPostion.y = bombPostion.y + 0.01f * Time.timeSinceLevelLoad;    // So the bomb will slowly increase speed the longer the game has been running.
			}
			if (1f > Input.acceleration.y & Input.acceleration.y > 0.5f)
			{
				bombPostion.y = bombPostion.y + 0.02f * Time.timeSinceLevelLoad;
			}
			if (1.5f > Input.acceleration.y & Input.acceleration.y > 1f)
			{
				bombPostion.y = bombPostion.y + 0.03f * Time.timeSinceLevelLoad;
			}
			

			if (-0.5f < Input.acceleration.y & Input.acceleration.y < 0f)
			{
				bombPostion.y = bombPostion.y - 0.01f * Time.timeSinceLevelLoad;
			}

			if (-1f < Input.acceleration.y & Input.acceleration.y < -0.5f)
			{
				bombPostion.y = bombPostion.y - 0.02f * Time.timeSinceLevelLoad;
			}

			if (-1.5f < Input.acceleration.y & Input.acceleration.y < -1f)
			{
				bombPostion.y = bombPostion.y - 0.03f * Time.timeSinceLevelLoad;
			}


			if (Input.acceleration.y > 0 &&!facingUp)
				Flip();
			else if (Input.acceleration.y < 0 && facingUp)
				Flip();

		}

		transform.position = bombPostion;  // Stops the bomb from leaving the screen

		if (bombPostion.y > 4)
		{
			bombPostion.y = 4;
		}

		if (bombPostion.y < -4)
		{
			bombPostion.y = -4;
		}

	}


	void Flip()      //Flips the bomb sprite when it changes direction
	{
		facingUp = !facingUp;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		

	void OnTriggerEnter2D (Collider2D other)  //When the bomb hits a city makes it do everything
	{
		if (other.gameObject.tag == "City")
		{
			ThumbScript.Th1Down -= ThumbDown11; // Unsubscribe from events
			ThumbScript.Th1Up -= ThumbUp11;
			ThumbScript2.Th2Down -= ThumbDown22;
			ThumbScript2.Th2Up -= ThumbUp22;
			other.gameObject.GetComponentInChildren<CityAnimate>().hitByBomb = true;

			// Add in explosion animation and sound effect

			Destroy (gameObject);
		}
	}






	public void ThumbDown11 () // Methods called by events to keep track of the thumbs state
	{
		p1Thumb = true;
	}

	public void ThumbDown22 ()    
	{							
		p2Thumb = true;
	}

	public void ThumbUp11 ()
	{
		p1Thumb = false;
	}

	public void ThumbUp22 ()
	{
		p2Thumb = false;
	}
}
