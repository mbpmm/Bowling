﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingBall : MonoBehaviour
{
    public float velocidad;
    public float force;
    private bool ballReleased;
    public int intentos;
    public Transform pinos;
    public Vector3 initPos;
    public Rigidbody rig;
    private float limL;
    private float limR;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        initPos = transform.position;
        ballReleased = false;
        limL = -1.790f;
        limR = 1.8189f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (ballReleased==false)
        {
            transform.position = new Vector3(transform.position.x + horizontal * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x<limL)
            {
                transform.position = new Vector3(limL, transform.position.y, transform.position.z);
            }
            if (transform.position.x > limR)
            {
                transform.position = new Vector3(limR, transform.position.y, transform.position.z);
            }
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            force += Time.deltaTime*1000;
        }
        else if(force>0)
        {
            force-= Time.deltaTime*1000;
        }

        Vector3 dir = new Vector3(0, 0, 1);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.AddForce(dir * force);
            ballReleased = true;
        }
    }
}
