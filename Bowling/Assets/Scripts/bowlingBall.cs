﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bowlingBall : MonoBehaviour
{
    public float velocidad;
    public float force;
    public int intentos;
    public Text tirosText;
    [HideInInspector]
    public bool ballReleased;
    [HideInInspector]
    public Vector3 initPos;
    [HideInInspector]
    public Rigidbody rig;
    public float timer;
    public bool onTrigger;
    public float timeLimit;
    private float limL;
    private float limR;
    private float maxPower;


    
    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 5.0f;
        maxPower = 6000.0f;
        rig = GetComponent<Rigidbody>();
        initPos = transform.position;
        ballReleased = false;
        onTrigger = false;
        limL = -1.790f;
        limR = 1.8189f;
        tirosText.text = "TIROS: " + intentos.ToString();
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!ballReleased)
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
            force += Time.deltaTime*2000;
            if (force>maxPower)
            {
                force = maxPower;
            }
        }
        else if(force>0)
        {
            force-= Time.deltaTime*10000;
        }

        Vector3 dir = new Vector3(0, 0, 1);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.AddForce(dir * force);
            ballReleased = true;
        }

        if (onTrigger)
        {
            timer += Time.deltaTime;
        }

        if (timer>timeLimit)
        {
            intentos--;
            timer = 0.0f;
            onTrigger = false;
            transform.position = initPos;
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
            ballReleased = false;
        }

        tirosText.text = "TIROS: " + intentos.ToString();
    }

    
}
