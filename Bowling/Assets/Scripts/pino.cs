using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pino : MonoBehaviour
{
    public GameObject bola;
    public float timer;
    private float timerLim;
    private float puntos;
    public bool estaCaido;

    void Start()
    {
        puntos = 10.0f;
        timerLim = 3.0f;
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
        if (timer > timerLim)
        {
            this.gameObject.SetActive(false);
            script.pinosCaidos++;
            script.puntaje += puntos;
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
