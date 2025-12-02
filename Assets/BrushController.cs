using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour

{
    Rigidbody rb;
    public float speed = 30.0f;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        // Wキー（前方移動）
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * speed;
        }
 
        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = - transform.up * speed;
        }
 
        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
 
        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * speed;
        }

        //↑押した時手前に10動かす
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = transform.forward * speed;
        }

        //↓押した時奥に10動かす
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = -transform.forward * speed;
        }
    }
}