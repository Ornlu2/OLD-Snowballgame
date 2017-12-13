using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerSnowBallController : MonoBehaviour {
    [SerializeField]


    public float SnowBallSize;
    public float SnowAmountIncrease;
    public float SnowAmountDecrease;
    public float AvalancheMultiplier;
    public float MaxSnowBallSize;
    public float SizeToBlinkAt  = 0.75f;
      float PlayerScore;
    public UnityEvent SnowLoss;
    public UnityEvent SnowGain;
    public UnityEvent Impact;
    public UnityEvent PlayerWonExplosion;

    bool Grounded = true;
    private Rigidbody2D rb;
    List<Collider2D> collidedObjects = new List<Collider2D>(2);
    public Transform Snowball;
    public Transform Respawn;
    public GameManager Gm;
    public bool CanChangeSize = true;
    
    public DangerExclamationPoint Danger;


    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Snowball = GameObject.Find("SnowBall").GetComponent<Transform>();
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
       

        
        else if (SnowBallSize <= 0f)
        {

            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerDeath());
            Danger.StopCoroutine("Blink");

        }
        else if (SnowBallSize < SizeToBlinkAt)
        {
            Danger.StartBlinking();
            Debug.Log("Blinking");
        }
        else if (SnowBallSize > SizeToBlinkAt)
        {
            Danger.StopBlinking();
        }

         if (Input.GetMouseButtonDown(0) && SnowBallSize > 0.5)
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

        if (col.gameObject.tag == "Ground")
        {
            rb.simulated = false;
            SnowBallSize = 0;
            Snowball.transform.localScale = new Vector3(SnowBallSize, SnowBallSize, 1);

            CanChangeSize = false;
            PlayerWonExplosion.Invoke();


            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerWin());


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
            Gm.PlayerScore = SnowBallSize;
            Gm.StartCoroutine("StopSnowing");
            Danger.StopBlinking();



            Debug.Log("PlayerStoppedChangingSize");
       }
        
        else if (col.gameObject.tag == "Respawn")
        {

            Camera.main.GetComponent<CameraNoRoll>().enabled = false;


            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerDeath());
        }
        if (col.gameObject.name == "KillVolume" && SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.position = Respawn.transform.position;
            SnowBallSize = 1.0f;
            rb.velocity = new Vector2(0, 0);
        }
        else if (col.gameObject.name == "KillVolume")
        {
           // rb.isKinematic = true;
            rb.simulated = false;

            StartCoroutine(Gm.gameObject.GetComponent<GameManager>().PlayerDeath());
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
