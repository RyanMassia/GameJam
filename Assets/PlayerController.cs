using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float xSens = 1.0f;
    public float ySens = 1.0f;

    public float walkSpeed = 10.0f;
    public float RunSpeed = 15.0f;
    public float slideSpeed = 20.0f;

    public float pullUp = 5.0f;

    public bool yInverse = false;
    public bool xInverse = false;
    bool onGround = true;
    
    public float moveSpeed = 10.0f;
    GameObject player;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   

    void FixedUpdate()
    {
        Look();
        walk();
        slide();
        walllRun();
        Grab();
        jump();
        
    }

    public void LockMouse()
    {
        
    }

    public void Look()
    {
        float yrot = Input.GetAxis("Mouse Y") * ySens * -1;
        float xrot = Input.GetAxis("Mouse X") * xSens;

        yrot = yInverse ? yrot * -1 : yrot;
        xrot = xInverse ? xrot * -1 : xrot;

        transform.Rotate(yrot, xrot, 0);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }

    public void walk() 
    {
        if (onGround)
        {
            //set running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = RunSpeed;
            }
            //slide
            if (Input.GetKeyDown(KeyCode.E))
            {
                moveSpeed = slideSpeed;

            }
            //walk
            else
            {
                moveSpeed = walkSpeed;
            }
            //forward
            if (Input.GetKey(KeyCode.W))
            {

                transform.Translate(0, 0, moveSpeed * Time.deltaTime);

            }
            //left
            if (Input.GetKey(KeyCode.A))
            {

                transform.Translate(moveSpeed * -1 * Time.deltaTime, 0, 0);

            }
            //right
            if (Input.GetKey(KeyCode.D))
            {

                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

            }
            //back
            if (Input.GetKey(KeyCode.S))
            {

                transform.Translate(0, 0, moveSpeed * -1 * Time.deltaTime);

            }
        }
    }

    public void slide()
    {

    }

    public void walllRun()
    {

    }

    public void Grab()
    {

    }

    public void jump()
    {
        
    }
}
