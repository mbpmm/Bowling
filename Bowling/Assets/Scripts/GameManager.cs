using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bola;
    public float puntaje;
    public int cantPinos;
    public int intentos;
    public int pinosCaidos;

    private float winLoseDelay;

    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Bola");
        cantPinos = 10;
        pinosCaidos = 0;
        intentos = 3;
        winLoseDelay = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (intentos >= 0 && pinosCaidos == cantPinos)
        {
            if (bola.GetComponent<bowlingBall>().timerText > winLoseDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                puntaje = 0;
            }
        }
        if (intentos == 0 && pinosCaidos != cantPinos)
        {
            if (bola.GetComponent<bowlingBall>().timerText > winLoseDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                puntaje = 0;
            }
        }
    }
}
