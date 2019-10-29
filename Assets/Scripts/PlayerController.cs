using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // define variables
    public float speed;
    public float turnSpeed;
    public float jumpSpeed;
    public float horizontalInput;
    public float forwardInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Jump");


        // move vehicle on input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed * verticalInput);
    }
}
