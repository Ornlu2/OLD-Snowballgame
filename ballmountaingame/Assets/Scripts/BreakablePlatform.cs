using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakablePlatform : MonoBehaviour {


    public bool isBreakable;
    public float SnowballSizeToBreakAt;

    public UnityEvent PlatformBreak;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isBreakable == true)
        {
            //Debug.Log(col.otherRigidbody.mass);

            if (col.relativeVelocity.magnitude >= 80f)
            {
                // Debug.Log(col.relativeVelocity.magnitude);
                PlatformBreak.Invoke();

            }
            
            else if (col.gameObject.tag == "Player")
            {
                var SnowballSize = col.gameObject.GetComponent<PlayerSnowBallController>().SnowBallSize;
                if (SnowballSize >= SnowballSizeToBreakAt)
                {
                    PlatformBreak.Invoke();
                }
            }
           else  if(col.gameObject.tag =="AvalancheSnow")
            {
                PlatformBreak.Invoke();
            }
        }
    }
   
}
