using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCol : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        bowlingBall script = other.gameObject.GetComponent<bowlingBall>();
        script.onTrigger = true;
    }
}
