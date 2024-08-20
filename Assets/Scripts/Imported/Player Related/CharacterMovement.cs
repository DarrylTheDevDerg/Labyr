using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Main Movement")]
    public float moveSpeed = 7.5f;
    public float jumpForce = 7f;
    private bool isGrounded;
    private bool canJump = true;
    private Rigidbody rb;
    Coroutine jumpFreeC = null;

    [Header("Connections")]
    [SerializeField] AnimationControl playerAnim;

    [Header("Ground settings")]
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float raycastDistanceToGround = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float realspeed;

        realspeed = moveSpeed;

        MovePlayer();
        Shoot();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed + 2.75f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed - 2.75f;
        }
    }

    void MovePlayer() 
    {
        // Check if the character is grounded.
        isGrounded = Physics.Raycast(groundCheckPosition.position, Vector3.down, raycastDistanceToGround, groundLayer);

        // Handle character movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0 || horizontalInput != 0)
        {
            if (verticalInput < 0 || horizontalInput != 0)
            {
                horizontalInput*= 0.5f;
                verticalInput *= 0.5f;
            }
        }

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        if (isGrounded && canJump == false && jumpFreeC == null)
        {
            FinishedJump();
        }

        // Handle jumping.
        if (isGrounded && Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&
            playerAnim.IsInFreeAnimation() &&
            playerAnim.CanShoot()) 
        {
            playerAnim.ShootAnimation();
        }
    }

    public void FinishedJump()
    {
        jumpFreeC = StartCoroutine(waitAndFreeJump());
    }

    IEnumerator waitAndFreeJump()
    {
        yield return new WaitForSeconds(0.02f);
        canJump = true;
        jumpFreeC = null;
    }
}
