using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Vector3 move;
    public float speed, jumpForce, gravity, verticalVelocity;

    private bool wallSlide, jump;

    private CharacterController charController;
    private Animator anim;
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
            jump = true;
            verticalVelocity = 0;
            RaycastHit();
        }

        if (!wallSlide)
        {
            gravity = 30;
            verticalVelocity -= gravity * Time.deltaTime;
        }
        else
        {
            gravity = 15;
            verticalVelocity -= gravity * Time.deltaTime;
        }

        anim.SetBool("Grounded", charController.isGrounded);
        anim.SetBool("WallSlide", wallSlide);


        move.Normalize();
        move *= speed;
        move.y = verticalVelocity;
        charController.Move(move * Time.deltaTime);
    }

    private void RaycastHit()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 8f))
        {
            Debug.DrawLine(transform.position , hit.point, Color.red);
            if(hit.collider.tag == "Wall")
            {
                verticalVelocity = jumpForce;
                anim.SetTrigger("Jump");
            }
        }
    }

    IEnumerator LateJump(float time)
    {
        jump = false;
        wallSlide = true;
        yield return new WaitForSeconds(time);

        if (!charController.isGrounded)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            verticalVelocity = jumpForce;
            anim.SetTrigger("Jump");
        }
        jump = true;
        wallSlide = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag=="Wall" || hit.collider.tag=="Slide")
        {
            if (jump)
                StartCoroutine(LateJump(UnityEngine.Random.Range(0.2f,.5f)));
            if (verticalVelocity <0)
                wallSlide = true;
        }
        if (hit.collider.tag=="Slide" && charController.isGrounded)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        }
        else if (hit.collider.tag == "Slide")
        {
            wallSlide = true;
        }
    }
}
 