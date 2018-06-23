using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 7f;
    [Tooltip("Max X position in meters")][SerializeField] float xPositionMax = 4f;
    [Tooltip("Max Y position in meters")] [SerializeField] float yPositionMax = 2.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Fetch the 'Horizontal' and 'Vertical' input
        // Integer between -1 and 1
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");        

        MovePlayer(xThrow, yThrow);
    }

    private void MovePlayer(float xThrow, float yThrow)
    {
        float xOffset = CalcOffset(xThrow);
        float yOffset = CalcOffset(yThrow);

        // Calculate the new X,Y position 
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rowNewYPos = transform.localPosition.y + yOffset;
        // Prevent the player going offscreen 
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xPositionMax, xPositionMax);
        float clampedYPos = Mathf.Clamp(rowNewYPos, -yPositionMax, yPositionMax);
        // Move the ship to the new X,Y position 
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);        
    }

    /*
     * Calculate the offset  
     */
    private float CalcOffset(float xThrow)
    {
        // Determine the offset for the current frame 
        // Throw * Move Speed * Delta Time
        return xThrow * xSpeed * Time.deltaTime;
    }
}
