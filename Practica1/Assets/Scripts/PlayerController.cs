using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f; 
    public float gravity = 9.81f; 

    private CharacterController player;
    private Vector3 playerVelocity;
    private bool isGrounded;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = player.isGrounded; 

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalMove, 0, verticalMove);

        if (move.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (move.magnitude > 1)
            move.Normalize();

        player.Move(transform.forward * move.magnitude * playerSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = jumpForce; 
        }

        playerVelocity.y -= gravity * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);
    }
}






