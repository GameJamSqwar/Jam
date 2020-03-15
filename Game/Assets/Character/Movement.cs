using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float stopper;
    public float damageTaken = 10f;
    bool dead = false;
    public AudioClip oofSoundEffect;
    public AudioClip haaSoundEffect;
    public AudioClip eughSoundEffect;
    public AudioSource audioSource;
    public Slider healthBar;

    public CapsuleCollider swordCollider;

    GameObject scoreText; 

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score");
    }

    void Update()
    {
        if (!dead)
        {
            Move();
            slider.value = health;
            if (rb.velocity.x < stopper && rb.velocity.x > -stopper && rb.velocity.z < stopper && rb.velocity.z > -stopper)
            {
                if (!attacking)
                {
                    anim.SetBool("isWalking", false);
                    anim.Play("idle");
                }
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
        if (!attacking && !dead)
        {
            anim.SetBool("isWalking", true);
            anim.Play("walk");
        }
    }

    private void OnAttack()
    {
        if (!attacking && !dead)
        {
            Attack("attack", 2f);
        }
    }

    private void OnSlash()
    {
        if (!attacking && !dead)
        {
            Attack("slash", 1f);
        }
    }

    void Attack(string an, float time)
    {
        audioSource.PlayOneShot(haaSoundEffect);
        attacking = true;
        anim.Play(an);
        swordCollider.enabled = true;
        InvokeRepeating("StopAttacking", time, 0);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemySword") || collision.collider.CompareTag("Sword"))
        {
            scoreText.GetComponent<Score>().ResetCombo();
            audioSource.PlayOneShot(oofSoundEffect);
            GetComponentInParent<PlayerStats>().TakeDamage(damageTaken);
        } 
    }

    public void Die()
    {
        if (!dead)
        {
            audioSource.PlayOneShot(eughSoundEffect);
            anim.Play("death");
            Invoke("DieFully", 3.5f);
            dead = true;
        }
    }

    void DieFully()
    {
        DestroyObject(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
