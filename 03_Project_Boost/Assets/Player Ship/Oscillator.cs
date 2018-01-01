using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementSpeed; 

    // todo remove from the inspector later
    [Range(0, 1)]
    [SerializeField]
    float movementFactor; // 0 for not moved, 1 for fully moved

    private Vector3 startingPos;

    // Use this for initialization
    void Start () {
        // Record the starting position of the object
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movementFactor > 1)
        {
            movementSpeed = -movementSpeed;
        }
        else if (movementFactor < 0)
        {
            movementSpeed = -movementSpeed;
        }

        // Calculate movement factor
        movementFactor = calcMovementFactor(movementSpeed);
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

    private float calcMovementFactor(float speed)
    {
        return movementFactor + (speed * Time.deltaTime);
    }
}
