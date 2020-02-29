using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    PlayerControls controls;
    Vector2 move;
    Vector2 rotate;

    void Awake()
    {
        controls = new PlayerControls();

        // Gets input from controller
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
    }


    // Update is called once per frame
    void Update()
    {
        // Applies force
        rb.AddForce(move.x * 50 * Time.deltaTime, 0, move.y * 50 * Time.deltaTime, ForceMode.VelocityChange);

        // Applies rotation
        Vector2 r = new Vector2(0, rotate.x) * 200 * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }
  
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
