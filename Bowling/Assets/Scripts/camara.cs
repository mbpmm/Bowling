using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target;
    Vector3 initialPos;
    public Vector3 offset;
    public Vector3 offsetRot;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.eulerAngles = offsetRot;
        if (transform.position.z>1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
        }
    }
}
