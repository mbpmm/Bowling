using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class powerBar : MonoBehaviour
{
    public Slider slider;
    public GameObject bola;

    void Update()
    {
        bola = GameObject.Find("Bola");
        bowlingBall script = bola.GetComponent<bowlingBall>();
        slider.value = script.force;
    }
}
