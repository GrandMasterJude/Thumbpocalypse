using UnityEngine;
using System.Collections;


public class CityAnimate : MonoBehaviour {

	float bombDirection;
	Animator anim;
	public bool hitByBomb;
	public GameControllerScript obj;

	void Start ()
	{
		hitByBomb = false;
	
		anim = GetComponent<Animator>();
	}
	

	void Update ()
	{
		bombDirection = Input.acceleration.y;

		anim.SetFloat("BombDirection", bombDirection);

		if (hitByBomb == true)
		{
			anim.SetBool("hitByBomb",true);
			//Play the animation and sound
			obj.Retry();
		
		}
	}
}
