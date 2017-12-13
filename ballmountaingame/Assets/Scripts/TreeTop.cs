using UnityEngine;
using System.Collections;
using UnityEngine.Events;



public class TreeTop : MonoBehaviour {
	Rigidbody2D rb;
	public float TreeTopKillDelay ;
	SpriteRenderer sp;
    public float fadespeed;
    public float threshold = float.Epsilon;
    public UnityEvent Treehit;
    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rb.isKinematic != true) 
        {

            StartCoroutine(KillTreeTimer());
        }
	}


	void OnCollisionEnter2D(Collision2D col)
	{
        if(col.gameObject.tag == "Player")
        {
            if(col.rigidbody.velocity.magnitude > 0.5f)
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>();
                SnowballSize.SnowBallSize -= SnowballSize.SnowAmountDecrease*4;
                //Treehit.Invoke();
                gameObject.GetComponentInParent<Treebreak>().TreeBreak();
                Debug.Log("tree hit player hard");
            }
            else
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>();
                SnowballSize.SnowBallSize -= SnowballSize.SnowAmountDecrease *2;
                //Treehit.Invoke();

                gameObject.GetComponentInParent<Treebreak>().TreeBreak();
                Debug.Log("tree hit player soft");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Treehit.Invoke();

        }
    }


    IEnumerator KillTreeTimer () {
        // Do something
       // Debug.Log("thing working");
		
		yield return new WaitForSeconds(TreeTopKillDelay);
        sp.color = new Color(1f, 1f, 1f, Mathf.Lerp(sp.color.a, 0.0f, fadespeed));
        yield return new WaitForSeconds(TreeTopKillDelay);

        if (Mathf.Abs(sp.color.a) <= 0.3)
        {
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
        }

        else if (Mathf.Abs(sp.color.a) <= 0.1)
        {
            Destroy(gameObject);
        }
        
		
		StopCoroutine ("KillTreeTimer");
	}
}
