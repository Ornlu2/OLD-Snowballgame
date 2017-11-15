using UnityEngine;
using System.Collections;

public class TreeTop : MonoBehaviour {
	Rigidbody2D rb;
	public float TreeTopKillDelay ;
	SpriteRenderer sp;
    public float fadespeed;
    public float threshold = float.Epsilon;

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
        if(col.rigidbody.tag == "Player")
        {
            if(col.rigidbody.velocity.magnitude > 0.5f)
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>();
                SnowballSize.SnowBallSize -= SnowballSize.SnowAmountDecrease*4;
                gameObject.GetComponentInParent<Treebreak>().TreeBreak();
                Debug.Log("tree hit player hard");
            }
            else
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>();
                SnowballSize.SnowBallSize -= SnowballSize.SnowAmountDecrease *2;
                gameObject.GetComponentInParent<Treebreak>().TreeBreak();
                Debug.Log("tree hit player soft");
            }
        }
    }



	IEnumerator KillTreeTimer () {
        // Do something
       // Debug.Log("thing working");
		
			yield return new WaitForSeconds(TreeTopKillDelay);
        sp.color = new Color(1f, 1f, 1f, Mathf.Lerp(sp.color.a, 0.0f, fadespeed));
        yield return new WaitForSeconds(TreeTopKillDelay);

        if (Mathf.Abs(sp.color.a) <= 0.5)
        {
            Destroy(gameObject);
        }
        
		
		StopCoroutine ("KillTreeTimer");
	}
}
