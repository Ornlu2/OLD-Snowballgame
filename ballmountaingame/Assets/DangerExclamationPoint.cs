using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerExclamationPoint : MonoBehaviour {

    private Transform parent;

    void Awake()
    {
        parent = GetComponentInParent<Transform>();
    }
    void LateUpdate()
    {
        transform.Rotate(parent.transform.position, parent.transform.rotation.z*0);
    }
}

