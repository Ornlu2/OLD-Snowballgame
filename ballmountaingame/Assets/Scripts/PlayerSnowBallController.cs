using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowBallController : MonoBehaviour {


    public float InititalSnowBallSize;
    public float SnowAmountIncrease;
    public float SnowAmountDecrease;
    public float AvalancheMultiplier;
    public float MaxSnowBallSize;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (InititalSnowBallSize > 1.5f && rb.velocity.magnitude >0.5) 
        {
            InititalSnowBallSize -= SnowAmountDecrease;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Transform Snowball = gameObject.GetComponentInChildren<Transform>().Find("SnowBall");

        if (InititalSnowBallSize <= MaxSnowBallSize)
        {


            if (col.gameObject.tag == "Snow")
            {
                InititalSnowBallSize += SnowAmountIncrease;
                Destroy(col.gameObject);
                Snowball.transform.localScale = new Vector3(InititalSnowBallSize, InititalSnowBallSize, 1);
            }
            if (col.gameObject.tag == "AvalancheSnow")
            {
                InititalSnowBallSize += AvalancheMultiplier;
                Destroy(col.gameObject);
                Snowball.transform.localScale = new Vector3(InititalSnowBallSize, InititalSnowBallSize, 1);
            }
        }
    }
    
}
