using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pino : MonoBehaviour
{
    public GameObject gameManager;
    public float timer;
    public bool estaCaido;

    private float timerLim;
    private float puntos;

    void Start()
    {
        puntos = 10.0f;
        timerLim = 3.0f;
        timer = 0;
        estaCaido = false;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (estaCaido)
        {
            timer += Time.deltaTime;
        }
        if (timer > timerLim)
        {
            this.gameObject.SetActive(false);
            gameManager.GetComponent<GameManager>().pinosCaidos++;
            gameManager.GetComponent<GameManager>().puntaje += puntos;
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
