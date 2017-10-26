using UnityEngine;
using System.Collections;
using System;

public class Avalanche : MonoBehaviour {

	public GameObject SnowBall;
	public GameObject Player;
	public Transform AvalancheGenLeft;
    public Transform AvalancheGenRight;

    public int repeatTime;
    public int DurationTime;
    public int StartTimeDelay;

    public bool Avalanchestarter;
    [HideInInspector]
    public Vector3 AvalancheSpawnLeft { get; private set; }
    public Vector3 AvalancheSpawnRight { get; private set; }

    // Use this for initialization
    void Start (){


       StartCoroutine (AvalancheStartWait());

    }
 

    private IEnumerator AvalancheStartWait()
    {
        //Debug.Log("CoRoutine " + AvalancheStartWait() + " has started");
        yield return new WaitForSeconds(StartTimeDelay);
        Avalanchestarter = true;
        Debug.Log("CoRoutine " + AvalancheStartWait() + " has ended");

    }

    private IEnumerator AvalancheDuration()
    {
        yield return new WaitForSeconds(DurationTime);
        Avalanchestarter = false;
    }
    // Update is called once per frame
    void Update () {



	if (Avalanchestarter == true) {
		Invoke ("AvalancheStart",repeatTime);
	}


	}
	void AvalancheStart()
	{

		int Avalanchechance = UnityEngine.Random.Range(1,10);

		if (Avalanchechance >= 7)
		{
            AvalancheSpawnLeft = AvalancheGenLeft.transform.position;
            AvalancheSpawnRight = AvalancheGenRight.transform.position;



            Debug.Log("Avalanche  starting");

            Vector3 pos = Vector3.Lerp(AvalancheSpawnLeft, AvalancheSpawnRight, UnityEngine.Random.value);


            Instantiate(SnowBall, new Vector3(pos.x,pos.y,pos.z), Quaternion.identity);
            AvalancheDuration();

        }
        else
		{
		Debug.Log("Avalanche Not starting");

		}

	}
	


    void OnDrawGizmos()
    {
       // Gizmos.DrawWireCube(AvalancheSpawnLeft, new Vector3(AvalancheSpawnLeft.x, AvalancheSpawnLeft.y, AvalancheSpawnLeft.z));
        //Gizmos.DrawWireCube(AvalancheSpawnRight, new Vector3(AvalancheSpawnRight.x, AvalancheSpawnRight.y, AvalancheSpawnRight.z));
        Gizmos.DrawLine(AvalancheSpawnLeft, AvalancheSpawnRight);

    }

}
