using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;


//using System.Diagnostics;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //caching the rigid body component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed SPACE - Thrusting");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Rotating Left");
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Rotating Right");
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
