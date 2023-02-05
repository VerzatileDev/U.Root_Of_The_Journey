using System;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [System.Serializable]
    public class Properties // move these to a global properties late on!
    {
        public CharacterController controller;
        public Transform groundCheck;
        public LayerMask groundLayer;
        public Vector3 direction;
        // properties
        public float playerSpeed = 5;
        public float jumpForce = 10;
        public float gravityForce = -9.8f;

        //Debug stuff
        public bool enableDebug = true;

    }
    public Properties properties = new Properties();

    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float left_right_input = Input.GetAxis("Horizontal"); // Left right arrows / A & D Default
        properties.direction.x = left_right_input * properties.playerSpeed;
        playerDirection();
        playerGrounded();
        properties.controller.Move(properties.direction * Time.deltaTime);
    }

    void playerDirection() // Rotates the player
    {
        if (properties.direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (properties.direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void playerGrounded() // Check Ground with Ray
    {
        RaycastHit hit;
        if(properties.enableDebug) Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.green);
        
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f, properties.groundLayer);
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                properties.direction.y = properties.jumpForce;
            }
        }
        else
        {
            properties.direction.y += properties.gravityForce * Time.deltaTime; // Gravity
        }
    }


}