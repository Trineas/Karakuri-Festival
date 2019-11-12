using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // define variables
    public float moveSpeed;
    public float jumpSpeed;
    public float horizontalInput;
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
        verticalInput = Input.GetAxis("Jump");


        // move character on input
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed * verticalInput);
    }
}
