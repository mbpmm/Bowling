using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public GameObject bola;
    public Text tirosText;
    public Text puntajeText;
    public Text winText;
    public Text loseText;

    void Start()
    {
        bola = GameObject.Find("Bola");
        tirosText.text = "TIROS: " + bola.GetComponent<bowlingBall>().intentos.ToString();
        winText.text = "GANASTE!!!";
        loseText.text = "PERDISTE :(";
        puntajeText.text = "PUNTOS: " + bola.GetComponent<bowlingBall>().puntaje.ToString();
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }
    void Update()
    {
        bowlingBall script = bola.GetComponent<bowlingBall>();
        slider.value = script.force;
    }
}
