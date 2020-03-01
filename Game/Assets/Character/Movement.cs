using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    float health = 1f;
	public Rigidbody rb;
    Vector2 i_movement;
	Vector2 i_rotation;
    public float moveSpeed;
    public float turningSpeed;
    public Slider slider;
    public Animator anim;
    bool attacking = false;

    public CapsuleCollider swordCollider;

    void Start()
    {
    }

    void Update()
    {
		Move();
        slider.value = health;
        if (rb.velocity.x < 0.3 && rb.velocity.x > -0.3 && rb.velocity.z < 0.3 && rb.velocity.z > -0.3)
        {
            if (!attacking)
            {
                anim.SetBool("isWalking", false);
                anim.Play("idle");
            }
        }
    }

    private void Move()
    {
        if (!attacking)
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
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("Moving!");
        i_movement = value.Get<Vector2>();
        i_rotation = value.Get<Vector2>();
        if (!attacking)
        {
            anim.SetBool("isWalking", true);
            anim.Play("walk");
        }
    }

    private void OnAttack()
    {
        if (!attacking)
        {
            attacking = true;
            anim.Play("attack");
            swordCollider.enabled = true;
            InvokeRepeating("StopAttacking", 1.7f, 0);
        }
    }

    private void StopAttacking()
    {
        attacking = false;
        swordCollider.enabled = false;
        CancelInvoke("StopAttacking");
    }

    public void OnPause()
    {
        GameObject.FindObjectOfType<PauseMenu>().TogglePause();
    }
}
