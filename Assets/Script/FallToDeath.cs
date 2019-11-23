using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FallToDeath : MonoBehaviour
{
    public GameObject player;
    public float fallSpeed = 5.0f;
    private int currentLives;

    bool isDead;
    bool isFalling;
    private int playerLives;
    private Func<CapsuleCollider> CapsuleCollider;

    private void Awake()
    {
        CapsuleCollider = GetComponent<CapsuleCollider>;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            transform.Translate(Vector3.up * fallSpeed * Time.deltaTime);
        }
    }

     void LoseLife ()
    {
        if (isDead)
            return;

        currentLives -= playerLives;

        if(isFalling)
        {
            Death();
        }
     }

    void Death()
    {
        isDead = true;
    }

    void StartFalling()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        isFalling = true;

        Destroy(gameObject, 4f);
    }
}
