using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 3f;
    [Tooltip("Max position in meters")][SerializeField] float xPositionMax = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Fetch the 'Horizontal' input
        // Integer between -1 and 1
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        // Determine the offset for the current frame 
        // Throw * Move Speed * Delta Time
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        print(xOffset);

        // Calculate the new X position 
        float rawNewXPos = transform.localPosition.x + xOffset;
        // Prevent the player going offscreen 
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xPositionMax, xPositionMax);
        // Move the ship to the new X position 
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
