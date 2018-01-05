using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float turn_speed;
    [SerializeField] float thrust_speed;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip levelWin;
    [SerializeField] AudioClip explosion;
    [SerializeField] float levelLoadDelay;
    private Boolean audioPlay;

    [SerializeField] ParticleSystem engineParticle;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem deathParticle; 

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (state == State.Alive)
        {
            // Handle ship rotation
            RespondToRotateInput();
            // Handle ship thrust
            RespondToThrustInput();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the player is not alive then return
        // Ignore further collisions
        if (state != State.Alive)   { return; }

        switch(collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                FailureSequence();
                break;
        }
    }

    private void FailureSequence()
    {
        state = State.Dying;
        deathParticle.Play();
        audioSource.Stop();
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(explosion);
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void SuccessSequence()
    {
        state = State.Transcending;
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(levelWin);
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Process user input
    private void RespondToRotateInput()
    {
        // Freese the rotation
        rigidBody.freezeRotation = true;
        float rotationThisFrame = turn_speed * Time.deltaTime;
        
        // Check for rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        // Resume rotation 
        rigidBody.freezeRotation = false;
    }

    private void RespondToThrustInput()
    {
        // Check for thrust
        if (Input.GetKey(KeyCode.Space))
        {
            //ridgidBody.AddRelativeForce(new Vector3(0, 1, 0));
            ApplyThrust();

            if (audioPlay == false)
            {
                // The audio source is probably already playing 
                // and does not need to be started again 
                audioSource.PlayOneShot(mainEngine);
                audioSource.volume = 1;
                audioPlay = true;
            }
        }
        else
        {
            audioSource.volume = 0;
            //audioSource.Stop();
            engineParticle.Stop(); 
            audioPlay = false;
        }
    }

    private void ApplyThrust()
    {
        engineParticle.Play();
        rigidBody.AddRelativeForce(Vector3.up * thrust_speed * Time.deltaTime);
    }
}
