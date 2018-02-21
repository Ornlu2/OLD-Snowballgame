using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
