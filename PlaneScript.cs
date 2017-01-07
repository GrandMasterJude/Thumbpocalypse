using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	public GameObject Bomb;

	void Start ()
	{
		StartCoroutine(BombDrop());
	}

	void Update ()

	{
		transform.Translate(0f, 6f *Time.deltaTime,0f);
	}

	IEnumerator BombDrop()
	{
		yield return new WaitForSeconds (1F);
		Instantiate(Bomb, new Vector3 (0,0,0), Quaternion.Euler(0,0,90));
	
		yield return new WaitForSeconds (1F);
		Destroy (gameObject);
	}

}

