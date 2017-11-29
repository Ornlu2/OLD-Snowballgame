using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSnowBallController : MonoBehaviour {


    public float SnowBallSize;
    public float SnowAmountIncrease;
    public float SnowAmountDecrease;
    public float AvalancheMultiplier;
    public float MaxSnowBallSize;
    public UnityEvent SnowLoss;
    public UnityEvent SnowGain;
    public UnityEvent Impact;

    bool Grounded = true;
    private Rigidbody2D rb;
    List<Collider2D> collidedObjects = new List<Collider2D>(2);
    public Transform Snowball;
    public Transform Respawn;
    private GameObject Gm;
    public bool CanChangeSize = true;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Snowball = GameObject.Find("SnowBall").GetComponent<Transform>();
        Gm = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update () {
        if(CanChangeSize)
        {
            ChangeSize();

        }

        collidedObjects.ToString();

    }


    void ChangeSize()
    {

        if (SnowBallSize>0f && rb.velocity.magnitude > 35f && Grounded == false)
        {
           SnowBallSize =  Mathf.Lerp(SnowBallSize, SnowBallSize - SnowAmountDecrease,   Time.deltaTime*rb.velocity.magnitude*4);
            SnowLoss.Invoke();
            
            Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
            //Debug.Log(rb.velocity.magnitude);

        }
       

        
        if (SnowBallSize <= 0f)
        {

            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerDeath());
            rb.isKinematic = true;

            //gameObject.transform.position = Respawn.transform.position;
            //gameObject.transform.rotation = Respawn.transform.rotation;
            //SnowBallSize = 1.5f;

            //rb.velocity= new Vector2(0,0);


        }

        else  if (Input.GetMouseButtonDown(0) && SnowBallSize > 0)
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
       

        if( rb.velocity.magnitude>= 4 && col.gameObject.tag=="Platform"&& rb.velocity.y >= 3)
        {
            Impact.Invoke();

        }
        if(CanChangeSize)
        {
            if (SnowBallSize <= MaxSnowBallSize)
            {


                if (col.gameObject.tag == "Snow")
                {
                    SnowBallSize = Mathf.Lerp(SnowBallSize, SnowBallSize + SnowAmountIncrease, 100 * Time.fixedDeltaTime);
                    Destroy(col.gameObject);
                    SnowGain.Invoke();
                    Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
                }
                if (col.gameObject.tag == "AvalancheSnow")
                {
                    SnowBallSize = Mathf.Lerp(SnowBallSize, SnowBallSize + AvalancheMultiplier, 100 * Time.fixedDeltaTime);
                    Destroy(col.gameObject);
                    Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
                    SnowGain.Invoke();

                }

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
        


        if(col.gameObject.name == "KillVolume")
        {
            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerDeath());
            rb.isKinematic = true;
        }



    }
    private void OnCollisionExit2D(Collision2D col)
    {
        Grounded = false;

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "SnowLossStopTrig")
        {
            CanChangeSize = false;
            Debug.Log("PlayerStoppedChangingSize");
       }
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
