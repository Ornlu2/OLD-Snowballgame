using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDestruction : MonoBehaviour {

	[SerializeField] float timeleft = 5f;

	[SerializeField] bool canDie = false;
    private Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canDie = false;
        timeleft = 5f;
	}
    void Update()
    {
		timeleft = timeleft-Time.deltaTime ;
        if(timeleft<=0  )
        {
            canDie = true;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
       // Debug.Log(col.rigidbody.velocity.magnitude);
        if (rb.velocity.magnitude < 1f && canDie ==true)
        {
            gameObject.SetActive(false);
        }
    }

}
