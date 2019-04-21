using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public GameObject gameManager;
    public GameObject bola;
    public Text tirosText;
    public Text puntajeText;
    public Text winText;
    public Text loseText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        bola = GameObject.Find("Bola");
        tirosText.text = "TIROS: " + gameManager.GetComponent<GameManager>().intentos.ToString();
        winText.text = "GANASTE!!!";
        loseText.text = "PERDISTE :(";
        puntajeText.text = "PUNTOS: " + gameManager.GetComponent<GameManager>().puntaje.ToString();
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        slider.value = bola.GetComponent<bowlingBall>().force;
    }
    void Update()
    {
        slider.value = bola.GetComponent<bowlingBall>().force;

        tirosText.text = "TIROS: " + gameManager.GetComponent<GameManager>().intentos.ToString();
        puntajeText.text = "PUNTOS: " + gameManager.GetComponent<GameManager>().puntaje.ToString();

        if (gameManager.GetComponent<GameManager>().intentos >= 0 &&
            gameManager.GetComponent<GameManager>().pinosCaidos == gameManager.GetComponent<GameManager>().cantPinos)
        {
            winText.gameObject.SetActive(true);
        }
        if (gameManager.GetComponent<GameManager>().intentos == 0 && 
            gameManager.GetComponent<GameManager>().pinosCaidos != gameManager.GetComponent<GameManager>().cantPinos)
        {
            loseText.gameObject.SetActive(true);
        }
    }
}
