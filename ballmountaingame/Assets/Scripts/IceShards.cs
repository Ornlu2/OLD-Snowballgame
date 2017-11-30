using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceShards : MonoBehaviour {

    public UnityEvent IceShard;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.rigidbody.tag == "Player")
        {

           // var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>();
            //SnowballSize.SnowBallSize -= SnowballSize.SnowAmountDecrease * 4;
            Debug.Log("ice hit player");
            IceShard.Invoke();
            

        }
        
    }
}
