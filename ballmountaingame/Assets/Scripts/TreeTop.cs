using UnityEngine;
using System.Collections;

public class TreeTop : MonoBehaviour {
	Rigidbody2D rb;
	public float TreeTopKillDelay ;
	SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.isKinematic == false)
		{
			StartCoroutine ("KillTreeTimer");
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			rb.isKinematic = false;
		}
	}



	IEnumerator KillTreeTimer () {
		// Do something

		if(sp.isVisible == false)
		{
			yield return new WaitForSecondsRealtime (TreeTopKillDelay); 

			DestroyObject (gameObject);
		}

		StopCoroutine ("KillTreeTimer");
	}
}
