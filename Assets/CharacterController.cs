using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private CharacterController characterController;
    public float moveSpeed = 10.0f;
    GameObject player;
    void Start()
    {
       
    }

   
    void Update()
    {
        Look();
    }

    public void Look()
    {
        Vector3 move= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        
    }
}
