using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator anim;
    public bool lockedByAnimation;
    public bool canShoot;

    [Header("Ground settings")]
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float raycastDistanceToGround = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the character is grounded.
        bool isGrounded = Physics.Raycast(groundCheckPosition.position, Vector3.down, raycastDistanceToGround, groundLayer);

        anim.SetBool("Jump",!isGrounded);

        if (verticalInput != 0 || horizontalInput != 0) {
            if (verticalInput < 0 || horizontalInput != 0)
            {
                anim.SetFloat("Walk", 0.5f);
            }
            else
            {
                anim.SetFloat("Walk", 1);
            }
                
        }
        // verticalInput == 0 && horizontalInput == 0
        else
        {
            anim.SetFloat("Walk", 0);
        }
        
    }

    // Shoot 
    public void ShootAnimation()
    {
        anim.SetTrigger("Shoot");
    }

    // Death
    public void DeathAnimation()
    {
        anim.SetTrigger("Death");
    }

    public bool IsInFreeAnimation()
    {
        return lockedByAnimation == false;
    }

    public bool CanShoot()
    {
        return canShoot;
    }
}
