using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public GameSettings settings;
    public event Action OnCollectedCoin;
    public event Action OnHitObstacle;

    private Rigidbody rb;
    private Animator anim;
    private float strafeInput;
    private bool jumpRequested;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        strafeInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
        anim.SetBool("isRunning", true);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(strafeInput * settings.strafeSpeed, rb.linearVelocity.y, settings.forwardSpeed);
        rb.linearVelocity = velocity;

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * settings.jumpForce, ForceMode.VelocityChange);
            jumpRequested = false;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnHitObstacle?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            OnCollectedCoin?.Invoke();
            Destroy(other.gameObject);
            anim.SetTrigger("isCollecting");
        }
    }

}
