using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tree" && col.gameObject.GetComponentInParent<Treebreak>().treeisstanding == true)
        {
            //col.gameObject.GetComponentInParent<Treebreak>().treeisstanding = false;

            col.gameObject.GetComponentInParent<Treebreak>().TreeBreak() ;

        }
       if(col.gameObject.tag =="Snow")
        {
            Destroy(col.gameObject);
        }
       
    }

}
