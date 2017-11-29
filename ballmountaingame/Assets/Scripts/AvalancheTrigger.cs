using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheTrigger : MonoBehaviour {
    private Avalanche AvalancheSpawner;

    // Use this for initialization
    void Start () {
        AvalancheSpawner = GameObject.Find("AvalancheSpawner").GetComponent<Avalanche>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {

        if (col.gameObject.tag == "Player")
        {
            AvalancheSpawner.StartAvalancheSequence();
            Debug.Log("Avalanche Sequence Started");
        }

	}
}
