using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowBallController : MonoBehaviour {


    public float SnowBallSize;
    public float SnowAmountIncrease;
    public float SnowAmountDecrease;
    public float AvalancheMultiplier;
    public float MaxSnowBallSize;
    bool Grounded = true;
    private Rigidbody2D rb;
    List<Collider2D> collidedObjects = new List<Collider2D>(2);

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        ChangeSize();
        collidedObjects.ToString();
    }


    void ChangeSize()
    {
        Transform Snowball = gameObject.GetComponentInChildren<Transform>().Find("SnowBall");

        if (SnowBallSize>0f && rb.velocity.magnitude > 35f && Grounded == false)
        {
            SnowBallSize = SnowBallSize - SnowAmountDecrease;
            Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
            //Debug.Log(rb.velocity.magnitude);

        }
       


        if (SnowBallSize <= 0f)
        {

            Debug.Log("GAME LOSS");
        }

        if (Input.GetMouseButtonDown(0) && SnowBallSize > 0f)
        {
            SnowBallSize = SnowBallSize * 0.8f;
            Debug.Log("Shrink");

        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Transform Snowball = gameObject.GetComponentInChildren<Transform>().Find("SnowBall");
        if(col.gameObject.tag =="Platform")
        {
            Grounded = true;

        }

        if (SnowBallSize <= MaxSnowBallSize)
        {


            if (col.gameObject.tag == "Snow")
            {
                SnowBallSize = SnowBallSize + SnowAmountIncrease;
                Destroy(col.gameObject);
                Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
            }
            if (col.gameObject.tag == "AvalancheSnow")
            {
                SnowBallSize = SnowBallSize + AvalancheMultiplier;
                Destroy(col.gameObject);
                Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
            }
            
        }
        if (!collidedObjects.Contains(col.collider) && col.collider.tag == "Platform")
        {
            collidedObjects.Add(col.collider);
        }

        

        if (SnowBallSize>=MaxSnowBallSize)
        {
            if(col.gameObject.tag=="Snow")
            {
                Destroy(col.gameObject);
            }
        }
        
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Grounded = false;
    }

    private void FixedUpdate()
    {
       /* foreach(var collider in collidedObjects)
        {
            Debug.Log(collider);
        }
        if (collidedObjects.Count == 2)
        {
            Debug.Log("hitting two platforms- shrinking");
            SnowBallSize = SnowBallSize * 0.5f;
            collidedObjects.Clear(); //clear the list of all tracked objects.

        }
        collidedObjects.Clear(); //clear the list of all tracked objects.
        */
    }


}
