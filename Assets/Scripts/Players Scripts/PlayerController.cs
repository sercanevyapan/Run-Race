using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;
    public float speed, jumpForce, gravity, verticalVelocity;

    private CharacterController charController;

    // Start is called before the first frame update
    void Awake()
    {
        charController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        move = transform.forward;

        if (charController.isGrounded)
        {
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            gravity = 30;
            verticalVelocity -= gravity * Time.deltaTime; 
        }

        move.Normalize();
        move *= speed;
        move.y = verticalVelocity;
        charController.Move(move * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!charController.isGrounded)
        {
            if (hit.collider.tag == "Wall")
            {       
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    verticalVelocity = jumpForce;

                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
                }
            }
        }
    }
}
