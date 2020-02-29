﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    bool triggerDown = false;

	public Rigidbody rb;
    Vector2 i_movement;
	Vector2 i_rotation;
    public float moveSpeed;
    public float turningSpeed;

    public Transform swordPos;

    void Start()
    {

    }

    void Update()
    {
		Move();
    }

    private void Move()
    {
		Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * moveSpeed * Time.deltaTime;
		rb.AddForce(movement.x, movement.y, movement.z, ForceMode.VelocityChange);

        // Applies rotation
        Vector3 NextDir = new Vector3(-i_rotation.x, 0, -i_rotation.y);
        if (NextDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(NextDir), turningSpeed * Time.deltaTime);
        }
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("Moving!");
		i_movement = value.Get<Vector2>();
    }

    private void OnRotate(InputValue value)
    {
        Debug.Log("Rotating");
        i_rotation = value.Get<Vector2>();
    }

    private void OnAttack()
    {
        if (!triggerDown)
        {
            triggerDown = true;
        }
    }

    private void OnReleaseAttack()
    {
        triggerDown = false;
    }
}
