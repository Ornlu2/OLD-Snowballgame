using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Treebreak : MonoBehaviour {

	public GameObject Mountain;
	Rigidbody2D childrb;
	public float delay;
	public bool TreeGoingToBreak =false;
	public  bool Treetop;
	public bool treeisstanding = true;
	float Rad2Deg;
	float deg;
	SpriteRenderer sp;
	public bool TreeVisible;
	private GameObject CameraCollider;
	public Collider2D stump;


	// Use this for initialization
	void Start () {
		childrb = GetComponentInChildren<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		float rad = transform.rotation.z;
		//stump = GameObject.FindWithTag ("TreeStump").GetComponent<Collider2D> ();
		//CameraCollider = GetComponent<Collider2D> ();

		deg = rad *Mathf.Rad2Deg;

		TreeDetect ();
		//Debug.Log(deg);


		if (treeisstanding == true) 
		{
			TreeRotation ();
		}



		 
		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down);

		if (hit != null && hit.collider.name == "CameraCollider") 
		{
			
			//Debug.Log ("I'm hitting THE CAMERA");
			TreeVisible = true;

		}
		else
		{
			//Debug.Log ("Im hitting" + hit.collider.name);
		}

	}



	void TreeRotation()
	{



		if ( deg <= -18 ) 
		{
			Debug.Log ("Tree Break Right");
			if (TreeVisible == true) {
				Invoke ("TreeBreak", delay);

				treeisstanding = false;
			}

		}
	

		else if ( deg >= 18)
		{
			Debug.Log ("Tree Break left");
			if (TreeVisible == true) {
				Invoke ("TreeBreak", delay);

				treeisstanding = false;
			}
		}
		else if(Application.loadedLevel==1)
		{
			
			//Debug.Log("level 1");
			if ( deg <= -10 ) 
			{
				Debug.Log ("Tree Break Right");
				if (TreeVisible == true) {
					Invoke ("TreeBreak", delay);

					treeisstanding = false;
				}

			}


			else if ( deg >= 10)
			{
				Debug.Log ("Tree Break left");
				if (TreeVisible == true) {
					Invoke ("TreeBreak", delay);

					treeisstanding = false;
				}
			}
		}

	}

	void TreeBreak()
	{
		
			//Debug.Log ("tree breaking");
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
		childrb.isKinematic = false;
		
			TreeGoingToBreak = false;
		

	}
	void TreeDetect()
	{
		

		/*else
		{
			Debug.Log("Tree NOT Detected");

			TreeVisible = false;
		}*/
	}

}

