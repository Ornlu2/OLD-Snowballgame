using UnityEngine;
using System.Collections;

public class DynamicCamera : MonoBehaviour {


	public Transform player;
	Transform BottomofMountain;
	Camera Maincamera;
	float margin =  0.1f;

	public float minSizeY = 5f;


	// Use this for initialization
	void Start () {
		BottomofMountain = GameObject.Find ("Bottom Of Mountain").transform;
		Maincamera = Maincamera.GetComponent<Camera> ();
	}
	void SetCameraPosition(){
		Vector3 middle = (player.position + BottomofMountain.position) * 0.6f;
		Maincamera.transform.position = new Vector3 (middle.x, middle.y, Maincamera.transform.position.z);

	}

	void SetMaincameraSize(){
		float minSizeX = minSizeY * (Screen.width / Screen.height);

		float width = Mathf.Abs (player.position.x - BottomofMountain.position.x) *(0.5f+margin);
		float height = Mathf.Abs (player.position.y - BottomofMountain.position.y) * (0.5f+margin);

		float cameraSizeX = Mathf.Max (width, minSizeX);
		Maincamera.orthographicSize = Mathf.Max(height, cameraSizeX*Screen.height/Screen.width, minSizeY);



	}

	// Update is called once per frame
	void Update () {
		SetCameraPosition ();
		SetMaincameraSize ();
	}
}
