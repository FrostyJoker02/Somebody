using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintMultiplier = 1.5f;

    private bool facingRight = false;

    public Vector3 velocity;
    public Vector3 tempPos;

    public Transform extraJumpCheck;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public float extraJumpCheckDistance = 0.5f;
    public LayerMask groundMask;
    public LayerMask extraJumpMask;

    public float fallMultiplier = 2.5f;
    public float fastfallMultiplier = 3.5f;
    public float lowJumpMultiplier = 2f;
    public bool isFalling = false;
    private float moveInput;

    public bool velCheck = false;
    public bool isGrounded;
    public bool isExtraJump;
    public bool isSprinting;
    public static int extraJumps;

    public GameObject player;
    private LadderMovement ladder_script;

    public bool isUmbrella = false;
    public bool usingUmbrella = false;

    public float slopeForce;
    public float slopeForceRayLength;

    private Animator anim;

    
    void Start()
    {
        ladder_script = player.GetComponent<LadderMovement>();
        anim = GameObject.Find("gIRL RIG").GetComponent<Animator>();
    }

    void Update()
    {
        tempPos = transform.position;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isExtraJump = Physics.CheckSphere(extraJumpCheck.position, extraJumpCheckDistance, extraJumpMask);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, 0f);

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log( "Ground True." );
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if(Input.GetButtonDown("Jump") && extraJumps >= 1)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            extraJumps -= 1;
        }

        if(Input.GetButton("Horizontal") && !isSprinting)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(!Input.GetButton("Horizontal"))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        if(Input.GetButtonDown("Sprint"))
        {
            speed = speed * sprintMultiplier;
        }

        if(Input.GetButton("Sprint") && Input.GetButton("Horizontal"))
        {
            isSprinting = true;
            anim.SetBool("isRunning", true);
        }

        if(Input.GetButtonUp("Sprint"))
        {
            speed = speed / sprintMultiplier;
            isSprinting = false;
            anim.SetBool("isRunning", false);
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if(facingRight == false && moveInput > 0){
        Flip();
        } else if (facingRight == true && moveInput < 0){
        Flip();
        }

        
        void Flip()
        {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        }

        //if(Input.GetButtonDown("Jump") && isExtraJump)
        //{
        //    Debug.Log( "Extra Jump True." );
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(!isFalling)
        {
            if(velocity.y < 0){
                velocity += Vector3.up * gravity * (fallMultiplier - 1) * Time.deltaTime;
            } else if (velocity.y > 0 && !Input.GetButton ("Jump")){
                velocity += Vector3.up * gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        if(isFalling)
        {
            if(velocity.y < 0){
                velocity += Vector3.up * gravity * (fastfallMultiplier - 1) * Time.deltaTime;
            } else if (velocity.y > 0 && !Input.GetButton ("Jump")){
                velocity += Vector3.up * gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        

        if(velocity.y < -25 && !isFalling)
        {
            velocity.y = -25;
        }
        else if(isFalling && velocity.y < -35)
        {
            velocity.y = -35;
        }
        if(isGrounded)
        {
            controller.slopeLimit = 45;
            extraJumps = 0;
        } 
        else
        {
            controller.slopeLimit = 90;
        }
        
        if(Input.GetButton("Fall") && !isGrounded && !usingUmbrella)
        {
            isFalling = true;

            if(velocity.y > -3f)
                {
                velocity.y = -3f;
                }
        }

        if(Input.GetButtonUp("Fall"))
        {
            fallMultiplier = 2.5f;
            isFalling = false;
        }

        

        if(Input.GetButton("Up"))
        {
            if(ladder_script.isLadder)
            {
                //tempPos.x = 0;
                //transform.position = tempPos;
                velocity.y = 0;
                velCheck = true;
                
            }
            else
            {
            velCheck = false;
            }
        }
        
        if(Input.GetButton("Jump") && velCheck)
        {
            if(ladder_script.isLadder)
            {   
                
                velocity.y = -9.81f;
                velCheck = false;
            }
        }


        if(ladder_script.isLadder == false)
            {
                velCheck = false;
            }
        if(isGrounded)
            {
                velCheck = false;
            }

        if(Input.GetButtonDown("Item 1") && isUmbrella)
        {
            usingUmbrella =! usingUmbrella;
        }

        if(usingUmbrella && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if((x != 0) && OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime );
        }
    }

    private bool OnSlope()
        {
            if(isGrounded == false)
             {
                 return false;
             }

            RaycastHit hit;

            if(Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))
            {
                if(hit.normal != Vector3.up)
                {
                    return true;
                }
            }
            return false;
        }

    
}
