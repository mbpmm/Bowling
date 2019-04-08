using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canaletas : MonoBehaviour
{
    public GameObject bola;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bola")
        {
            bola= GameObject.Find("Bola");
            bowlingBall script = bola.GetComponent<bowlingBall>();
            script.intentos--;
            bola.transform.position = script.initPos;
            script.rig.velocity=Vector3.zero ;
            script.rig.angularVelocity = Vector3.zero;
            script.ballReleased = false;
            script.timer = 0.0f;
            script.onTrigger = false;
        }
    }
}

