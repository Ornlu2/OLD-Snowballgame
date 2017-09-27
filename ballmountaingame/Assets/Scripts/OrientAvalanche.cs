using UnityEngine;
using System.Collections;

public class OrientAvalanche : MonoBehaviour {


    public Transform player;
    public float YOffset;
    private int MoveTowardsSpeed = 10;


	
	// Update is called once per frame
	void Update () {

        float step = MoveTowardsSpeed * Time.deltaTime;
        Vector3 pos = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x,player.transform.position.y+YOffset,player.transform.position.z), step);

        gameObject.transform.position = pos;
            
            
            
    }
}
