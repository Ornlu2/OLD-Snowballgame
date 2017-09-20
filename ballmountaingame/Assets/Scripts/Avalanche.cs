using UnityEngine;
using System.Collections;

public class Avalanche : MonoBehaviour {

	public float Timer;
	public GameObject SnowBall;
	public GameObject Player;
	public Transform AvaPlayer;
	public Transform AvalancheGen;
	public bool Avalanchestarter;
	// Use this for initialization
	void Start (){ 
	}
	
	// Update is called once per frame
	void Update () {




	if (Avalanchestarter == true) {
		Invoke ("AvalancheStart",0);
	}


	}
	void AvalancheStart()
	{

		int avalanchechance = Random.Range(1,10);

		if (avalanchechance >=7)
		{
			Debug.Log("Avalanche  starting");

			GameObject instance = Instantiate (SnowBall,AvaPlayer) as GameObject;


		}
		else
		{
		Debug.Log("Avalanche Not starting");

		}

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			Avalanchestarter = true;
		}
	}
}
