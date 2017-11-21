using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    public Transform Player;
    public Transform Ground;
    public float HeightfromBottom;
    public float speed;
    public float MaxZoomOut;

    void Update()
    {
        HeightfromBottom = (Player.position.y - Ground.position.y)/10;


        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, MaxZoomOut, speed* Time.deltaTime/HeightfromBottom);

    }

}

