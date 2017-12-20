using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody ridgidBody;
    public int turn_speed;

	// Use this for initialization
	void Start () {
        ridgidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    // Process user input
    private void ProcessInput()
    {
        // Check for thrust
        if(Input.GetKey(KeyCode.Space))
        {
            print("SPACE!!!!");
            //ridgidBody.AddRelativeForce(new Vector3(0, 1, 0));
            ridgidBody.AddRelativeForce(Vector3.up);
        } 

        // Check for rotation
        if(Input.GetKey(KeyCode.A))
        {
            print("Turning Left");
            transform.Rotate(Vector3.forward * turn_speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * turn_speed * Time.deltaTime);
            print("Turning Right");
        }
    }
}
