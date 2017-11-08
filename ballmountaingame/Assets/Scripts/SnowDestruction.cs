using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDestruction : MonoBehaviour {

    float timeleft = 5f;

    bool canDie = false;

	// Use this for initialization
	void Start () {
		
	}
    void Update()
    {
        timeleft -= Time.deltaTime;
        if(timeleft<=0  )
        {
            canDie = true;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
       // Debug.Log(col.rigidbody.velocity.magnitude);
        if (col.rigidbody.velocity.magnitude <= 0.0f && canDie ==true)
        {
            Destroy(this.gameObject);
        }
    }

}
