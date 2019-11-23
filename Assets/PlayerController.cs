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
    public float jumpForce = 10;

    public float pullUp = 5.0f;

    public bool yInverse = false;
    public bool xInverse = false;
    bool onGround = true;
    bool onWallRight = false;
    bool onWallLeft = false;
    bool onWallFront = false;
    bool onWallFrontUp = false;

    public float moveSpeed = 10.0f;

    GameObject player;
    GameObject playerCamera;
    GameObject[] building;

    private Rigidbody rBody;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rBody = GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("Camera");
    }

   

    void FixedUpdate()
    {
        Look();
        Walk();
        WallRun();
        Grab();
        Jump();
        CheckGround();
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

        transform.Rotate(0, xrot, 0);
        playerCamera.transform.Rotate(yrot, 0, 0);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }

    public void Walk() 
    {
        
        if (onGround)
        {
            moveSpeed = 0;
            //set running
            if (Input.GetKey(KeyCode.LeftShift)&& (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                moveSpeed = RunSpeed;
            }
            //slide
           else if (Input.GetKeyDown(KeyCode.E)&&(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                moveSpeed = slideSpeed;

            }
            //walk
            else if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
            {
                moveSpeed = walkSpeed;
            }

            //forward
            if (Input.GetKey(KeyCode.W))
            {
                
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            }

            //back
            if (Input.GetKey(KeyCode.S))
            {
                
                transform.Translate(0, 0, moveSpeed * -1 * Time.deltaTime);
            }
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
    }

  

    public void WallRun()
    {

    }

    public void Grab()
    {
        if (Input.GetKeyDown(KeyCode.Q) && onWallFront && !onWallFrontUp)
        {
            rBody.velocity = new Vector3(0, 5f, 0.5f);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                rBody.AddForce(new Vector3(0, jumpForce * 100, 0));
                rBody.velocity = transform.forward * moveSpeed;
            }
            else if (onWallRight || onWallLeft)
            {
                rBody.AddForce(new Vector3(0, jumpForce * 100, 0));
                rBody.velocity = -rBody.velocity;
            }
        }
    }


    // Checks if the player is touching the ground
    private void CheckGround()
    {
        onGround = Physics.Raycast(transform.position, new Vector3(0, -1, 0), 1.05f);
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.05f, Color.red);

        onWallRight = Physics.Raycast(transform.position, new Vector3(1f, 0, 0), 0.55f);
        Debug.DrawRay(transform.position, transform.right * 0.55f, Color.red);

        onWallLeft = Physics.Raycast(transform.position, new Vector3(-1f, 0, 0), 0.55f);
        Debug.DrawRay(transform.position, -transform.right * 0.55f, Color.red);

        onWallFront = Physics.Raycast(transform.position, transform.forward, 0.55f);
        Debug.DrawRay(transform.position, transform.forward * 0.55f, Color.red);

        onWallFrontUp = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward, 0.7f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward * 0.7f, Color.red);
    }
}
