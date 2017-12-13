using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerExclamationPoint : MonoBehaviour {

    public Transform player;
    public float YOffset;
    private int MoveTowardsSpeed = 50;
    private bool ShouldBlink;
    SpriteRenderer image;

    void Start()
    {
        image =GetComponent<SpriteRenderer>();
        image.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float step = MoveTowardsSpeed * Time.deltaTime;
        Vector3 pos = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + YOffset, player.transform.position.z), step);

        gameObject.transform.position = pos;

        


    }
    IEnumerator Blink()
    {
        while (ShouldBlink == true)
        {
            image.enabled = true;
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

    public void StartBlinking()
    {
        image.enabled = true;
        ShouldBlink = true;
        StartCoroutine("Blink");
    }
    public void StopBlinking()
    {
        image.enabled = false;
        ShouldBlink = false;
        StopAllCoroutines();
    }
}

