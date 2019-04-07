using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingBall : MonoBehaviour
{
    public float velocidad;
    public float force;
    private bool ballReleased;
    public Transform pinos;
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ballReleased = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (ballReleased==false)
        {
            transform.position = new Vector3(transform.position.x + horizontal * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            force += Time.deltaTime*100;
        }
        else if(force>0)
        {
            force-= Time.deltaTime*10;
        }

        Vector3 dir = new Vector3(0, 0, 1);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.AddForce(dir * force);
            ballReleased = true;
        }
    }
}
