using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class powerBar : MonoBehaviour
{

    public float fullHeight = 6000.0f;
    public Slider slider;
    public GameObject bola;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bola = GameObject.Find("Bola");
        bowlingBall script = bola.GetComponent<bowlingBall>();
        slider.value = script.force;
    }
}
