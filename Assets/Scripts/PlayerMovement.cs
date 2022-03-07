using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public bool isSprinting = false;
    public float sprintSpeed = 24f;

    public bool isCrouching = false;
    public float crouchingSpeed = 6f;

    public float crouchingHeight = 1.25f;
    public float standingHeight = 3.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            speed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            speed = 6f;
        }
        else
        {
            controller.height = standingHeight;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 12f;
        }
    }
}
