using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Treebreak : MonoBehaviour {

	
	Rigidbody2D childrb;
	public float delay;
	public bool TreeGoingToBreak =false;
	public  bool Treetop;
	public bool treeisstanding = true;
	float Rad2Deg;
	float deg;
	public bool TreeVisible;
	private GameObject CameraCollider;
	public Collider2D stump;



	// Use this for initialization
	void Start () {
		childrb = GetComponentInChildren<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float rad = transform.rotation.z;
	
		deg = rad *Mathf.Rad2Deg;

		if (treeisstanding == true) 
		{
			TreeRotation ();
		}

		RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down);

		if ( hit.collider.name == "CameraCollider") 
		{
			
			//Debug.Log ("I'm hitting THE CAMERA");
			TreeVisible = true;

		}
		

	}



	void TreeRotation()
	{
		
			
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

	 public void TreeBreak()
	{
        //Debug.Log ("tree breaking");

        if(treeisstanding ==true && childrb.isKinematic ==true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
        
        treeisstanding = false;
        childrb.isKinematic = false;
		TreeGoingToBreak = false;

	}
	

}

