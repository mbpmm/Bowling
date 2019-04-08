using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinos : MonoBehaviour
{
    public GameObject bola;
    public float timer;
    public bool estaCaido;
    void Start()
    {
        timer = 0;
        estaCaido = false;
    }

    // Update is called once per frame
    void Update()
    {
        bowlingBall script = bola.gameObject.GetComponent<bowlingBall>();
        if (estaCaido)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3.0f)
        {
            this.gameObject.SetActive(false);
            script.pinosCaidos++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pista" || other.gameObject.name == "Piso")
        {
            estaCaido = true;
        }
    }
}
