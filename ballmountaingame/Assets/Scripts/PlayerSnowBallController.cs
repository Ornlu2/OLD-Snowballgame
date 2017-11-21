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
    bool Grounded = true;
    private Rigidbody2D rb;
    List<Collider2D> collidedObjects = new List<Collider2D>(2);
    private MountainRot enablecontrols;
    public Transform Snowball;
    public Transform Respawn;


    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enablecontrols = GameObject.Find("Mountain").GetComponent<MountainRot>();
        Snowball = GameObject.Find("SnowBall").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update () {
        ChangeSize();
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

            Debug.Log("GAME LOSS");
           // enablecontrols.isLeftkeyEnabled = false;
           // enablecontrols.isRightkeyEnabled = false;
            SnowBallSize = 1.5f;

            gameObject.transform.position = Respawn.transform.position;


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

        if (SnowBallSize <= MaxSnowBallSize)
        {


            if (col.gameObject.tag == "Snow")
            {
                SnowBallSize = Mathf.Lerp(SnowBallSize, SnowBallSize + SnowAmountIncrease,100* Time.fixedDeltaTime );
                Destroy(col.gameObject);
                Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);
            }
            if (col.gameObject.tag == "AvalancheSnow")
            {
                SnowBallSize = Mathf.Lerp(SnowBallSize, SnowBallSize + AvalancheMultiplier,100* Time.fixedDeltaTime);
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
        


        if(col.gameObject.name == "KillVolume")
        {
            gameObject.transform.position = Respawn.transform.position;
            SnowBallSize = 1.5f;
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
