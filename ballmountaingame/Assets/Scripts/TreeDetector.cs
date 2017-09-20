using UnityEngine;
using System.Collections;

public class TreeDetector : MonoBehaviour {

	public bool TreeDetected = false;
	private Collider2D Tree;
	public Collider2D CameraCollider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Tree = GameObject.FindGameObjectWithTag ("Tree").GetComponent<Collider2D> ();
		TreeDetect ();
	}

	void TreeDetect()
	{
		if (Physics2D.IsTouching (collider1: CameraCollider , collider2: Tree) == true)
		{
			Debug.Log("Tree Detected");

			TreeDetected = true;
		}
		else
		{
			TreeDetected = false;
		}
	}

}
