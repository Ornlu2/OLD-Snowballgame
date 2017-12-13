using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class Avalanche : MonoBehaviour
{

    public GameObject SnowBall;
    public GameObject Player;
    public Transform AvalancheGenLeft;
    public Transform AvalancheGenRight;

    public int repeatTime;
    public int DurationTime;
    public int StartTimeDelay;

    Image image;

    public bool Avalanchestarter = false;
    public bool AvalancheCanActivate = false;
    private int Avalanchechance;
    public bool IsAvalancheActive = false;

    public UnityEvent AvalancheOnParticleEffect;
    public UnityEvent AvalancheOffParticleEffect;

    private OrientAvalanche Orienter;
    private bool ShouldBlink;

    [HideInInspector]
    public Vector3 AvalancheSpawnLeft { get; private set; }
    public Vector3 AvalancheSpawnRight { get; private set; }


    void Start()
    {
        image = GameObject.Find("AvalancheWarningSign").GetComponent<Image>();
        image.gameObject.SetActive(false);
        Orienter = gameObject.GetComponent<OrientAvalanche>();
    }


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
        StopCoroutine(Blink());
        IsAvalancheActive = false;
        AvalancheCanActivate = false;
        AvalancheOffParticleEffect.Invoke();
        StartCoroutine(AvalancheRepeatWait());
        yield break;

    }
    // Update is called once per frame
    void Update()
    {
        if ( Avalanchestarter == true && AvalancheCanActivate == true)
        {
            if(IsAvalancheActive == false)
            {
                StartCoroutine(AvalancheDo());

            }
            Orienter.enabled = false;
        }
        else
        {
            Orienter.enabled = true;
        }
        
    }
    void AvalancheStart()
    {

        Avalanchechance = UnityEngine.Random.Range(1, 10);
        Debug.Log(Avalanchechance);
       if(Avalanchechance>=6)
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
    IEnumerator AvalancheDo()
    {
        IsAvalancheActive = true;
        


            #if UNITY_IOS
            {
            for  (int i = 0; i <DurationTime; i++)
            {
                Handheld.Vibrate();

            }
        }
            #endif

            StartBlinking();
            AvalancheOnParticleEffect.Invoke();
            AvalancheSpawnLeft = AvalancheGenLeft.transform.position;
            AvalancheSpawnRight = AvalancheGenRight.transform.position;
        for (int i = 0; i <100;)
        {
            Debug.Log("Avalanche happening");
            float pos = UnityEngine.Random.Range(AvalancheGenLeft.transform.position.x, AvalancheGenRight.transform.position.x);

            Instantiate(SnowBall, new Vector3(pos, transform.position.y, transform.position.z), Quaternion.identity);

            yield return new WaitForSeconds(0.001f);
            i++;
        }
       
        StartCoroutine(AvalancheDuration());
        
        
        yield break;

        
    }



    

  


    IEnumerator Blink()
    {
        while (ShouldBlink == true)
        {
            switch (image.color.a.ToString())
            {
                case "0":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    //Play sound
                    yield return new WaitForSecondsRealtime(0.1f);
                    break;
                case "1":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    //Play sound
                    yield return new WaitForSecondsRealtime(0.1f);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        image.gameObject.SetActive(true);
        ShouldBlink = true;
        StartCoroutine("Blink");
    }
    public void StopBlinking()
    {
        image.gameObject.SetActive(false);
        ShouldBlink = false;
        StopCoroutine("Bink");
    }

   

}

