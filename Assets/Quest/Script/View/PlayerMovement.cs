using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _CharacterController;
    Vector3 MoveDirection;
    float speed = 5f;
    float gravity = 10f;
    float jumpForce = 10f;
    float verticalVelocity;
    void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();

    }
    
    void MoveThePlayer()
    {
        MoveDirection = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
        MoveDirection = transform.TransformDirection(MoveDirection);
        MoveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        _CharacterController.Move(MoveDirection);
    }
    void ApplyGravity()
    {
        if (_CharacterController.isGrounded)
        {
            verticalVelocity-= gravity* Time.deltaTime;

            // jump
            PlayerJump();
        } else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
      MoveDirection.y = verticalVelocity * Time.deltaTime;
         // MoveDirection.y = verticalVelocity;
    }
    void PlayerJump() {
            if (_CharacterController.isGrounded&&Input.GetKeyDown(KeyCode.Space))
            {
            verticalVelocity = jumpForce;
            }
        }
}
