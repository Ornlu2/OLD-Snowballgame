using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowBallController : MonoBehaviour {


    public float SnowBallSize;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Transform Snowball = gameObject.GetComponentInChildren<Transform>().Find("SnowBall");


        if (col.gameObject.tag == "Snow")
        {
            SnowBallSize+=0.01f;
            Destroy(col.gameObject);
            Snowball.transform.localScale = new Vector3(SnowBallSize,SnowBallSize,0);
        }
    }


}
