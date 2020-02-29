using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFollowPlayer : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
