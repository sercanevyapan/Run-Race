using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;
    public float speed, jumpForce, gravity, verticalVelocity;

    private bool wallSlide, turn;

    private CharacterController charController;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        move = transform.forward;

        if (charController.isGrounded)
        {
            wallSlide = false;
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Jump();
           
              
            }

            if (turn)
            {
                turn = false;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            }
        }
        if(!wallSlide)
        {
            gravity = 30;
            verticalVelocity -= gravity * Time.deltaTime;
          
        }
        else
        {
            gravity = 15;
            verticalVelocity -= gravity * .5f* Time.deltaTime;
          
        }

        anim.SetBool("WallSlide", wallSlide);
        anim.SetBool("Grounded", charController.isGrounded);

        move.Normalize();
        move *= speed;
        move.y = verticalVelocity;
        charController.Move(move * Time.deltaTime);

    }

    void Jump()
    {
        verticalVelocity = jumpForce;
        anim.SetTrigger("Jump");
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!charController.isGrounded)
        {
            if (hit.collider.tag == "Wall")
            {
                if (verticalVelocity < -.6f)
                    wallSlide = true;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Jump();

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);

                    wallSlide = false;
                }
            }
        }
        else
        {
            if(transform.forward !=hit.collider.transform.up && hit.collider.tag == "Ground" && !turn)
            {
                turn = true;
                
            }
        }
    }
}
