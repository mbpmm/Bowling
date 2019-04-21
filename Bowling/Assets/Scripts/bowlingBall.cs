using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bowlingBall : MonoBehaviour
{
    public float pinosCaidos;
    public float velocidad;
    public float force;
    public int intentos;
    //public Text tirosText;
    //public Text puntajeText;
    //public Text winText;
    //public Text loseText;
    [HideInInspector]
    public bool ballReleased;
    [HideInInspector]
    public Vector3 initPos;
    [HideInInspector]
    public Rigidbody rig;
    [HideInInspector]
    public float puntaje;
    public float timer;
    public float timerText;
    public bool reloadDelay;
    public bool onTrigger;
    public float timeLimit;

    private float limL;
    private float limR;
    private float maxPower;
    private float forceMult;
    private float forceMultDecrease;
    private int cantPinos;
    private float winLoseDelay;

    // Start is called before the first frame update
    void Start()
    {
        winLoseDelay = 3.0f;
        cantPinos = 10;
        forceMult = 3000.0f;
        forceMultDecrease = 10000.0f;
        timeLimit = 5.0f;
        maxPower = 6000.0f;
        rig = GetComponent<Rigidbody>();
        initPos = transform.position;
        ballReleased = false;
        onTrigger = false;
        limL = -1.790f;
        limR = 1.8189f;
        //tirosText.text = "TIROS: " + intentos.ToString();
        //winText.text = "GANASTE!!!";
        //loseText.text = "PERDISTE :(";
        //puntajeText.text = "PUNTOS: " + puntaje.ToString();
        //winText.gameObject.SetActive(false);
        //loseText.gameObject.SetActive(false);
        timer = 0;
        pinosCaidos = 0;
        timerText = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //limites a izquierda y derecha
        if (!ballReleased)
        {
            transform.position = new Vector3(transform.position.x + horizontal * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x<limL)
            {
                transform.position = new Vector3(limL, transform.position.y, transform.position.z);
            }
            if (transform.position.x > limR)
            {
                transform.position = new Vector3(limR, transform.position.y, transform.position.z);
            }
        }
        
        if (Input.GetKey(KeyCode.Space)&&!ballReleased)
        {
            force += Time.deltaTime*forceMult;
            if (force>maxPower)
            {
                force = maxPower;
            }
        }
        else if(force>0)
        {
            force-= Time.deltaTime* forceMultDecrease;
            
        }

        Vector3 dir = new Vector3(0, 0, 1);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.AddForce(dir * force);
            ballReleased = true;
        }

        //timer para el turno
        if (onTrigger)
        {
            timer += Time.deltaTime;
            timerText = 0.0f;
        }

        if (timer>timeLimit)
        {
            intentos--;
            timer = 0.0f;
            onTrigger = false;
            transform.position = initPos;
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
            force = 0.0f;
            ballReleased = false;
            reloadDelay = true;
        }

        //timer para el reload de la escena
        if (reloadDelay)
        {
            timerText += Time.deltaTime;
        }

        //actualizacion de textos
        tirosText.text = "TIROS: " + intentos.ToString();
        puntajeText.text = "PUNTOS: " + puntaje.ToString();

        //condicion de derrota y victoria
        if (intentos>=0&&pinosCaidos== cantPinos)
        {
            winText.gameObject.SetActive(true);
            if (timerText> winLoseDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                puntaje = 0;
            }
        }
        if (intentos==0&&pinosCaidos!=cantPinos)
        {
            loseText.gameObject.SetActive(true);
            if (timerText > winLoseDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                puntaje = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }
}
