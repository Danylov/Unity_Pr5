using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private float zBound = 9;
    private Rigidbody playerRb;
    
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) Debug.Log("Player has collided with enemy.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")) Destroy(other.gameObject);
    }
}