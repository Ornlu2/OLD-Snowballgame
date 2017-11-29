using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class Avalanche : MonoBehaviour
{

    public GameObject SnowBall;
    public GameObject Player;
    public Transform AvalancheGenLeft;
    public Transform AvalancheGenRight;

    public int repeatTime;
    public int DurationTime;
    public int StartTimeDelay;

    public bool Avalanchestarter = false;
    private bool AvalancheCanActivate = false;
    private int Avalanchechance;

    public UnityEvent ParticleEffect;

    [HideInInspector]
    public Vector3 AvalancheSpawnLeft { get; private set; }
    public Vector3 AvalancheSpawnRight { get; private set; }

    public void StartAvalancheSequence()
    {
        StartCoroutine(AvalancheStartWait());
    }
    private IEnumerator AvalancheStartWait()
    {
        Debug.Log("Delaying avalanche start");
        yield return new WaitForSeconds(StartTimeDelay);
        Avalanchestarter = true;
        AvalancheStart();
        yield break;
    }
    private IEnumerator AvalancheRepeatWait()
    {
        yield return new WaitForSeconds(repeatTime);
        AvalancheStart();

        Debug.Log("repeat Delay timer has ended");
        yield break;
    }
    private IEnumerator AvalancheDuration()
    {

        yield return new WaitForSeconds(DurationTime);
        Debug.Log("Avalanche Ending");

        AvalancheCanActivate = false;
        StartCoroutine(AvalancheRepeatWait());
        yield break;

    }
    // Update is called once per frame
    void Update()
    {
        if ( Avalanchestarter == true && AvalancheCanActivate == true)
        {
            AvalancheDo();
            Debug.Log("Avalanche  happening");

        }
       
        
    }
    void AvalancheStart()
    {

        Avalanchechance = UnityEngine.Random.Range(1, 10);
        Debug.Log(Avalanchechance);
       if(Avalanchechance>=7)
        {
            AvalancheCanActivate = true;
            StartCoroutine(AvalancheDuration());

        }
        else
        {
            AvalancheCanActivate = false;
            StartCoroutine(AvalancheRepeatWait());

        }

    }
    void AvalancheDo()
    {
        Handheld.Vibrate();
        ParticleEffect.Invoke();
        AvalancheSpawnLeft = AvalancheGenLeft.transform.position;
        AvalancheSpawnRight = AvalancheGenRight.transform.position;
        Vector3 pos = Vector3.Lerp(AvalancheSpawnLeft, AvalancheSpawnRight, UnityEngine.Random.value);
        Instantiate(SnowBall, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        
    }

}