using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCol : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        bowlingBall script = other.gameObject.GetComponent<bowlingBall>();
        script.onTrigger = true;
            //bola.transform.position = script.initPos;
            //script.rig.velocity = Vector3.zero;
            //script.rig.angularVelocity = Vector3.zero;
            //script.ballReleased = false;
      
    }
}
