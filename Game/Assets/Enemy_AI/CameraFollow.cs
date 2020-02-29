using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The object that will be followed.")]
    public GameObject followTarget;

    [Tooltip("Offset from position of object being followed.")]
    public Vector3 PositionOffset;


    // Update is called once per frame
    void Update()
    {
        var pos = followTarget.transform.position + PositionOffset;

        transform.position = pos;
    }
}
