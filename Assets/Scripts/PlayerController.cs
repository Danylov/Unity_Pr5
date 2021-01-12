using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float zBound = 9.5f;
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * verticalInput * Vector3.forward);
        playerRb.AddForce(speed * horizontalInput * Vector3.right);
    }

    void ConstrainPlayerPosition()
    {
        if (zBound < Math.Abs(transform.position.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                zBound * Math.Sign(transform.position.z));
        }
    }
}