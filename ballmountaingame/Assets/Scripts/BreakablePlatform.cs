using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour {


    public bool isBreakable;
    public float SnowballSizeToBreakAt;

 
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if (isBreakable == true)
        {
            //Debug.Log(col.otherRigidbody.mass);

            if (col.relativeVelocity.magnitude >= 80f)
            {
               // Debug.Log(col.relativeVelocity.magnitude);
                Destroy(this.gameObject);
            }
            
            if (col.gameObject.tag == "Player")
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>().InititalSnowBallSize;
                if (SnowballSize >= SnowballSizeToBreakAt)
                {
                    Destroy(this.gameObject);
                }
            }
            if(col.gameObject.tag =="AvalancheSnow")
            {
                Destroy(this.gameObject);
            }
        }
    }
  
}
