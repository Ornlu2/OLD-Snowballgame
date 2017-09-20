using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoseState : MonoBehaviour {

	public float health ;
	public GameObject Health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Health.GetComponent<Text> ().text = "Health: " + health.ToString ();

		if (health<=0)
		{
			SceneManager.LoadScene (5);
		}


	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag ==("Respawn"))
			{
				SceneManager.LoadScene(5);
			}

		if (col.tag ==("WinPlatform"))
			{
				SceneManager.LoadScene(4);
			}

	}
	void OnCollisionEnter2D(Collision2D coll)
	{	
		if (coll.gameObject.tag == "Tree") {
			health -= 10f;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}

	}
}
