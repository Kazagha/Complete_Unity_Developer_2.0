using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f,0f,0f);
    [SerializeField] float period;

    // todo remove from the inspector later
    [Range(0, 1)]
    [SerializeField]
    float movementFactor; // 0 for not moved, 1 for fully moved

    // Store the original position of the game object
    private Vector3 startingPos;

    // Use this for initialization
    void Start () {
        // Record the starting position of the object
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Checking if floats are equal is unreliable 
        // Instead check if period is less than the smallest float value
        if(period <= Mathf.Epsilon) { return; }
        
        // Calculate movement factor
        movementFactor = calcMovementFactor();
        // Set the transform
        offsetTransform();
    }

    private void offsetTransform()
    {
        // Calculate the offset
        Vector3 offset = movementVector * movementFactor;
        // Move the object to the value of the offset
        transform.position = startingPos + offset;
    }

    private float calcMovementFactor()
    {
        // Cycles gradually grows as the game time advances
        // This is automatically frame rate independent
        float cycles = Time.time / period;

        // Twice the value of PI, full circle
        const float tau = Mathf.PI * 2;

        // Calculate the position on the sine wave curve 
        // Values between -1 and 1
        float rawSinWave = Mathf.Sin(cycles * tau);

        // Translate the sine wave into the movement factor
        // Values between 0 and 1
        movementFactor = (rawSinWave / 2f) + 0.5f;

        return movementFactor;
    }
}
