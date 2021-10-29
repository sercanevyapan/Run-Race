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

        }

        move.Normalize();
        move *= speed;
      
        charController.Move(move * Time.deltaTime);
    }
}
