using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    public int turn_speed;
    private Boolean audioPlay;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Handle ship rotation
        Rotation();
        // Handle ship thrust
        Thrust();
	}

    // Process user input
    private void Rotation()
    {
        // Freese the rotation
        rigidBody.freezeRotation = true;

        // Check for rotation
        if (Input.GetKey(KeyCode.A))
        {
            print("Turning Left");
            transform.Rotate(Vector3.forward * turn_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * turn_speed * Time.deltaTime);
            print("Turning Right");
        }

        // Resume rotation 
        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        // Check for thrust
        if (Input.GetKey(KeyCode.Space))
        {
            //ridgidBody.AddRelativeForce(new Vector3(0, 1, 0));
            rigidBody.AddRelativeForce(Vector3.up);

            if (audioPlay == false)
            {
                // The audio source is probably already playing 
                // and does not need to be started again 
                audioSource.Play();
                audioSource.volume = 1;
                audioPlay = true;
            }
        }
        else
        {
            audioSource.volume = 0;
            audioPlay = false;
        }
    }
}
