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
    public Text tirosText;
    public Text winText;
    public Text loseText;
    [HideInInspector]
    public bool ballReleased;
    [HideInInspector]
    public Vector3 initPos;
    [HideInInspector]
    public Rigidbody rig;
    public float timer;
    public float timerText;
    public bool reloadDelay;
    public bool onTrigger;
    public float timeLimit;
    private float limL;
    private float limR;
    private float maxPower;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 5.0f;
        maxPower = 6000.0f;
        rig = GetComponent<Rigidbody>();
        initPos = transform.position;
        ballReleased = false;
        onTrigger = false;
        limL = -1.790f;
        limR = 1.8189f;
        tirosText.text = "TIROS: " + intentos.ToString();
        winText.text = "GANASTE!!!";
        loseText.text = "PERDISTE :(";
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        timer = 0;
        pinosCaidos = 0;
        timerText = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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
        

        if (Input.GetKey(KeyCode.Space))
        {
            force += Time.deltaTime*3000;
            if (force>maxPower)
            {
                force = maxPower;
            }
        }
        else if(force>0)
        {
            force-= Time.deltaTime*10000;
        }

        Vector3 dir = new Vector3(0, 0, 1);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rig.AddForce(dir * force);
            ballReleased = true;
        }

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
            ballReleased = false;
            reloadDelay = true;
        }

        if (reloadDelay)
        {
            timerText += Time.deltaTime;
        }

        tirosText.text = "TIROS: " + intentos.ToString();

        if (intentos>0&&pinosCaidos==10)
        {
            winText.gameObject.SetActive(true);
            if (timerText>3.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (intentos==0&&pinosCaidos!=10)
        {
            loseText.gameObject.SetActive(true);
            if (timerText > 3.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    
}
